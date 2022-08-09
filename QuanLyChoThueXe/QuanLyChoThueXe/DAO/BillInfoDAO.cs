using QuanLyChoThueXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DAO
{
  public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

      

        public List<BillInfo> GetListBillInfo(int id)//id của cái bill
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo1 WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        //
        public void InsertBillInfo(int idBill, int idKhach, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo1 @idBill , @idKhachHang , @count", new object[] { idBill, idKhach, count });
        }
        //
        public void DeleteBillInfoByKhachID(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfo1 WHERE idKhachHang = " + id);
        }
    }
}
