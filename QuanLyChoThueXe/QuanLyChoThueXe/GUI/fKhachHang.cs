using QuanLyChoThueXe.DAO;
using QuanLyChoThueXe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueXe
{
    public partial class fKhachHang : Form
    { 
         BindingSource khachList = new BindingSource();
        private readonly object mmTienThue;

        public fKhachHang()
        {
            InitializeComponent();
            dtgvKhach.DataSource = khachList;
            LoadListKhach();
            AddKhachBinding();
            LoadGioiTinh();
        }

        //tim kiem khách bằng tên
        List<Khach> SearchKhachByName(string name)
        {
            List<Khach> listKhach = KhachDAO.Instance.SearchKhachByName(name);

            return listKhach;
        }

        //kỹ thuật biding trong c#
        void AddKhachBinding()
        {   
            txbKhachName.DataBindings.Add(new Binding("Text", dtgvKhach.DataSource, "Name", true, DataSourceUpdateMode.Never));//gias tri của text sẽ thay đôi theo gia tri cua Name trong DataSource
            nmKhachID.DataBindings.Add(new Binding("Text", dtgvKhach.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmCmnd.DataBindings.Add(new Binding("Value", dtgvKhach.DataSource, "CMND", true, DataSourceUpdateMode.Never));
            nmSdt.DataBindings.Add(new Binding("Value", dtgvKhach.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            cbxGioiTinh.DataBindings.Add(new Binding("Text", dtgvKhach.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            txbDiachi.DataBindings.Add(new Binding("Text", dtgvKhach.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
        }
        //load Khách
        void LoadListKhach()
        {
            khachList.DataSource = KhachDAO.Instance.GetListKhach();
        }

        //load giới tính
        void LoadGioiTinh()
            {
                cbxGioiTinh.Items.Add("Nam");
                cbxGioiTinh.Items.Add("Nữ");
            }
       
        //event thêm khách
        private void btnAddKhach_Click(object sender, EventArgs e)
        {
            string name = txbKhachName.Text;
            int cmnd = (int)nmCmnd.Value;
            int sdt = (int)nmSdt.Value;
            string gioitinh = cbxGioiTinh.Text;
            string diachi = txbDiachi.Text;
            float price = (float)nmTienThue.Value;
            if (KhachDAO.Instance.InsertKhach(name,cmnd,sdt,gioitinh, diachi,price))
            {
                MessageBox.Show("Thêm khách thành công");
                LoadListKhach();
                if (insertKhach != null)
                    insertKhach(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm khách");
            }
        }
        //
        private void btnShowKhach_Click(object sender, EventArgs e)
        {
            LoadListKhach();
        }
        //
        private void btnSearchKhach_Click(object sender, EventArgs e)
        {
            khachList.DataSource = SearchKhachByName(txbSearchKhachName.Text);
        }
        //event sửa khách
        private void btnEditKhach_Click(object sender, EventArgs e)
        {
            string name = txbKhachName.Text;
            int cmnd = (int)nmCmnd.Value;
            int sdt = (int)nmSdt.Value;
            string gioitinh = cbxGioiTinh.Text;
            string diachi = txbDiachi.Text;
            int id = Convert.ToInt32(nmKhachID.Text);
            float price = (float)nmTienThue.Value;


            if (KhachDAO.Instance.UpdateKhach(name, cmnd, sdt, gioitinh, diachi, id))
            {
                MessageBox.Show("Sửa Khách thành công");
                LoadListKhach();
                if (updateKhach != null)
                    updateKhach(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa Khách");
            }
        }
        //event xóa khach
        private void btnDeleteKhach_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(nmKhachID.Text);

           
            
            if (MessageBox.Show(string.Format(" Khách Hàng có id {0} này không?",id),"Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (KhachDAO.Instance.DeleteKhach(id))
                {
                    MessageBox.Show("Xóa Khách thành công");
                    LoadListKhach();
                    if (deleteKhach != null)
                        deleteKhach(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa Khách");
                }
            }

        }
        private void Mouse_Click(object sender, FormClosingEventArgs e)
        {
            
        }
        // Khai báo những event
        private event EventHandler insertKhach;
        public event EventHandler InsertKhach
        {
            add { insertKhach += value; }
            remove { insertKhach -= value; }
        }

        private event EventHandler deleteKhach;
        public event EventHandler DeleteKhach
        {
            add { deleteKhach += value; }
            remove { deleteKhach -= value; }
        }

        private event EventHandler updateKhach;
        public event EventHandler UpdateKhach
        {
            add { updateKhach += value; }
            remove { updateKhach -= value; }
        }

        private void nmTienThue_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
