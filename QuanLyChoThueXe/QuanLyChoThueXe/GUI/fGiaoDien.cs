using QuanLyChoThueXe.DAO;
using QuanLyChoThueXe.DTO;
using QuanLyChoThueXe.GUI;
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
using Menu = QuanLyChoThueXe.DTO.Menu;

namespace QuanLyChoThueXe
{
    public partial class fGiaoDien : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount.Type); }
        }

        public fGiaoDien(Account acc)
        {
            InitializeComponent();// Hàm để khởi tạo các đối tượng có trên form
            this.LoginAccount = acc;//truyền tài khoản đăng nhập
            LoadTableBike();
            LoadKhach();
        }


      
        //Hàm kiểm tra xem tài khoản thuộc loại nào, nếu tài khoản là loại 0 (admin) thì mới có quyền truy cập vào chức năng quản lý
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 0;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        void LoadTableBike()//Load table bike lên
        {
            flpTableBike.Controls.Clear();
            List<TableBike> tableList = TableBikeDAO.Instance.LoadTableList();//lấy được danh sách tablebike

            foreach (TableBike item in tableList)//với mỗi xe nằm trong cái table list sẽ tạo ra 1 cái buton
            {
                Button btn = new Button() { Width = TableBikeDAO.TableWidth, Height = TableBikeDAO.TableHeight };
                btn.Text = item.Name + " " + item.Brand + Environment.NewLine + "Biển số:" + item.Bienso + "-" + item.Status + Environment.NewLine + "Giá 1h:" +item.Price;//tên xe + trạng thái của xe
                btn.Click += btn_Click;//event click
                btn.Tag = item;//gắn tablebike id (lưu luôn tablebike vào)
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.AntiqueWhite;
                        break;
                    case "Xe Đang sửa chữa":
                        btn.BackColor = Color.Red;
                        break;
                    default:
                        btn.BackColor = Color.SaddleBrown;
                        break;
                }

                flpTableBike.Controls.Add(btn);
            }
        }

        //hàm show bill
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<QuanLyChoThueXe.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTableBike(id);//lấy ra ListBillInfo
            float totalPrice = 0;
            foreach (Menu item in listBillInfo)//cho mỗi cái menu nằm trong listbillinfo
            {
                ListViewItem lsvItem = new ListViewItem(item.KhachName.ToString());//tạo ra listviewitem
                lsvItem.SubItems.Add(item.Cmnd.ToString());
                lsvItem.SubItems.Add(item.Sdt.ToString());
                lsvItem.SubItems.Add(item.Diachi.ToString());
                lsvItem.SubItems.Add(item.DateCheckin.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;

                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            //Thread.CurrentThread.CurrentCulture = culture; hiện ra đơn vị tiền vnđ

            txbToltalPrrice.Text = totalPrice.ToString("c", culture);//hiển thị tổng tiền ở textbox tổng tiền c viet tat là currency: đơn vị tiền
        }
        //hàm load danh sach khach
        void LoadKhach()//load ten khach vao combobox
        {
            List<Khach> listKhach = KhachDAO.Instance.GetListKhach();
            cbKhach.DataSource = listKhach;
            cbKhach.DisplayMember = "Name";
        }

        //
        void LoadKhachByID(int id)
        {
            List<Khach> listKhach = KhachDAO.Instance.GetListKhach();
            cbKhach.DataSource = listKhach;
            cbKhach.DisplayMember = "Name";
        }
   
        //event Đặt xe
        private void btnAddBike_Click(object sender, EventArgs e)
        {
            TableBike tableBike = lsvBill.Tag as TableBike;// lấy ra cái danh sách xe hiện tại

            if (tableBike == null)//
            {
                MessageBox.Show("Xin hãy chọn xe!");
                return;
            }

            int idBill = BillDAO.Instance.GetUncheckBillIDByBikeID(tableBike.ID);
            int KhachID = (cbKhach.SelectedItem as Khach).ID;
            int count = (int)nmTimeCount.Value;

            if (idBill == -1)//nếu idbill =-1 là ko có bill nào hết chúng ta phải tiến hành thêm bill
            {
                BillDAO.Instance.InsertBill(tableBike.ID, KhachID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), KhachID, count);
            }
            else//ngược lại!=-1 thì nó có cái id bill vừa query ra r thêm khách dô 
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, KhachID, count);
            }
            ShowBill(tableBike.ID);

            LoadTableBike();
        }
        //even thanh toán
        private void btnCheckOut_Click(object sender, EventArgs e) // khi minh chon thanh toan se checkout
        {
            TableBike tableBike = lsvBill.Tag as TableBike;//lay table hien tai
            int idBill = BillDAO.Instance.GetUncheckBillIDByBikeID(tableBike.ID); //lay idbill ra
            
            double toltalPrice = Convert.ToDouble(txbToltalPrrice.Text.Split(',')[0].Replace(".", ""));//xử lý chuỗi và cắt chuỗi lấy ra phần đầu tiên
            double tienthutruoc = (100000);
            double finalTotalPrice = toltalPrice - tienthutruoc;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho {0} !\n ***Tổng tiền là {1} \n  = {2}đ( đã thu trước 100k) \n số tiền cần phải thu là {3}  ", tableBike.Name, toltalPrice, finalTotalPrice,finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, (float)finalTotalPrice);
                    ShowBill(tableBike.ID);

                    LoadTableBike();
                }

            }
        }
      
        private void btn_Click(object sender, EventArgs e)//khi nhấn vào sẽ show hóa đơn
        {
            int BikeID = ((sender as Button).Tag as TableBike).ID;//lấy id của table
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(BikeID);
        }
        //
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
           
            f.ShowDialog();
        }
        
        void f_UpdateKhach(object sender, EventArgs e)
        {
            LoadKhachByID((cbKhach.SelectedItem as Khach).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as TableBike).ID);
        }
        //
        void f_DeleteKhach(object sender, EventArgs e)
        {
            LoadKhachByID((cbKhach.SelectedItem as Khach).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as TableBike).ID);
            LoadTableBike();
        }
        //
        void f_InsertKhach(object sender, EventArgs e)
        {
            LoadKhachByID((cbKhach.SelectedItem as Khach).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as TableBike).ID);
        }
        
        private void cbKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 1;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;
            Khach selected = cb.SelectedItem as Khach;
            id = selected.ID;
            LoadKhachByID(id);//load danh sách
        }

        private void quanLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhachHang f = new fKhachHang();
            f.InsertKhach += f_InsertKhach;
            f.DeleteKhach += f_DeleteKhach;
            f.UpdateKhach += f_UpdateKhach;
            f.ShowDialog();
        }
       

        //Load tablebike vao combobox
        /*void LoadComboboxTableBike(ComboBox cb)
        {
            cb.DataSource = TableBikeDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }*/
        //Hàm Hủy Đặt Xe
        private void btnHuy_Click(object sender, EventArgs e)
        {
            TableBike tablebike = lsvBill.Tag as TableBike;//lay table hien tai
            int idBill = BillDAO.Instance.GetUncheckBillIDByBikeID(tablebike.ID); //lay idbill ra


            double toltalPrice = Convert.ToDouble(txbToltalPrrice.Text.Split(',')[0].Replace(".", ""));//xử lý chuỗi và cắt chuỗi lấy ra phần đầu tiên
            double finalTotalPrice = toltalPrice * (0.1) ;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc chắn hủy hóa đơn đặt xe cho {0} !\n ***Tổng tiền 10% từ {1} = {2}đ ", tablebike.Name, toltalPrice, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, (float)finalTotalPrice);
                    ShowBill(tablebike.ID);

                    LoadTableBike();
                }

            }
        }
       
        private void flpTableBike_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbKhach_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
