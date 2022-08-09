using QuanLyChoThueXe.DAO;
using QuanLyChoThueXe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueXe.GUI
{
    public partial class fAdmin : Form
    {
       

        BindingSource accountList = new BindingSource();

        BindingSource nhanvienList = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            dtgvNhanvien.DataSource = nhanvienList;
            dtgvAccount.DataSource = accountList;
            LoadAccount();
            LoadNhanVien();
            LoadGioiTinh();
            LoadDateTimePickerBill();
            AddAccountBinding();
            AddNhanVienBinding();
        }

        #region methods
        
        //them tai khoan
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        //load tai khoan
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;//load datetime ngay hom nay
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);//chuyen datetimepicker ve ngay dau thang
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);//them vao 1 thang va tru 1 ngay la thanh cuoi thang hien tai
        }

        //Thêm nhân viên
        void AddNhanVienBinding()
        {
            txbName.DataBindings.Add(new Binding("Text", dtgvNhanvien.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbNVID.DataBindings.Add(new Binding("Text", dtgvNhanvien.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmCMND.DataBindings.Add(new Binding("Text", dtgvNhanvien.DataSource, "CMND", true, DataSourceUpdateMode.Never));
            nmSDT.DataBindings.Add(new Binding("Text", dtgvNhanvien.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            tbxDate.DataBindings.Add(new Binding("Text", dtgvNhanvien.DataSource, "NgaySinh", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dtgvNhanvien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            txbAddress.DataBindings.Add(new Binding("Text", dtgvNhanvien.DataSource, "QueQuan", true, DataSourceUpdateMode.Never));
        }
       
        //them tai khoan
        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }
        //edit tai khoan
        void EditAccount(string userName, string displayName, int type)//sua tai khoan
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }
        //xoa tai khoan
        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng không xóa tài khoản đang đăng nhập");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }


        #endregion

        #region events
         //event thêm tài khoản
        private void btnAddAcount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;

            AddAccount(userName, displayName, type);
        }
        //event xóa tài khoản
        private void btnDeleteAcount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }
        //event sửa tài khoản
        private void btnEditAcount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            EditAccount(userName, displayName, type);
        }
        //
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPass(userName);
        }
        //load Nhân viên
        void LoadNhanVien()
        {
            nhanvienList.DataSource = NhanVienDAO.Instance.GetListNhanVien();
        }
        void LoadGioiTinh()
        {
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
        }
        //event thêm nhân viên
        private void btnAddNV_Click(object sender, EventArgs e)
        {
            string UserName = txbName.Text;
            int CMND = (int)nmCMND.Value;
            int SDT = (int)nmSDT.Value;
            string NgaySinh = tbxDate.Text;
            string GioiTinh = cbGioiTinh.Text;
            string QueQuan = txbAddress.Text;
            if (NhanVienDAO.Instance.InsertNhanVien(UserName, CMND, SDT, NgaySinh, GioiTinh, QueQuan))
            {
                MessageBox.Show("Thêm nhân viên thành công");
                LoadNhanVien();
                if (insertNhanVien != null)
                    insertNhanVien(this, new EventArgs());

            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhân viên");
            }
        }


        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            int idNhanvien = Convert.ToInt32(txbNVID.Text);

            if (NhanVienDAO.Instance.DeleteNhanVien(idNhanvien))
            {
                MessageBox.Show("Xóa nhân viên thành công");
                LoadNhanVien();
                if (deleteNhanVien != null)
                    deleteNhanVien(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên");
            }
        }

        private void btnEditNV_Click(object sender, EventArgs e)
        {
            string UserName = txbName.Text;
            int CMND = (int)nmCMND.Value;
            int SDT = (int)nmSDT.Value;
            string NgaySinh = tbxDate.Text;
            string GioiTinh = cbGioiTinh.Text;
            string QueQuan = txbAddress.Text;
            int idNhanvien = Convert.ToInt32(txbNVID.Text);
            //int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            //float price = (float)nmFoodPrice.Value;

            if (NhanVienDAO.Instance.UpdateNhanVien(UserName, CMND, SDT, NgaySinh, GioiTinh, QueQuan, idNhanvien))
            {
                MessageBox.Show("Sửa nhân viên thành công");
                LoadNhanVien();
                if (updateNhanVien != null)
                    updateNhanVien(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa nhân viên");
            }
        }

        private event EventHandler insertNhanVien;
        public event EventHandler InsertNhanVien
        {
            add { insertNhanVien += value; }
            remove { insertNhanVien -= value; }
        }
        
        private event EventHandler deleteNhanVien;
        public event EventHandler DeleteNhanVien
        {
            add { deleteNhanVien += value; }
            remove { deleteNhanVien -= value; }
        }

        private event EventHandler updateNhanVien;
        public event EventHandler UpdateNhanVien
        {
            add { updateNhanVien += value; }
            remove { updateNhanVien -= value; }
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txbtotal_TextChanged(object sender, EventArgs e)
        {

        }

        void LoadListBillByDate(DateTime checkIn, DateTime CheckOut)
        {
            dtgvBill.DataSource= BillDAO.Instance.GetListBillByDate(checkIn, CheckOut);
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbxDate_TextChanged(object sender, EventArgs e)
        {

        }
    }



    #endregion


}


