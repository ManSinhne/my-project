using QuanLyChoThueXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DAO
{
  public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        public int GetUncheckBillIDByBikeID(int id)//trả ra 1 id của bill dựa vào id Bike và status
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTableBike = " + id + " AND status = 0");//lấy ra data table
            if (data.Rows.Count > 0)//nêu số trường nó trả về > 0 thì thực hiện câu lệnh bên trong
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;//lấy được id bill
            }

            return -1;// có nghĩa là id =-1 có nghĩa là không có gì hết
        }

        public void CheckOut(int id, float totalPrice=0) //xd checkout cho bill
        {   
            string query = "UPDATE dbo.Bill SET dateCheckOut = CURRENT_TIMESTAMP, status = 1, totalprice= 0 WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        //hàm thêm bill
        public void InsertBill(int id1 , int id2)
        {
           DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTableBike , @idKhachHang", new object[] { id1, id2 });
        }
        //hàm lấy danh sách bill theo ngày
        public DataTable GetListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate1 @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        //lấy tổng số bill
        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
