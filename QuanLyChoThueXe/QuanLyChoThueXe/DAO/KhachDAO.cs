using QuanLyChoThueXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DAO
{
  public class KhachDAO
    {
        private static KhachDAO instance;

        public static KhachDAO Instance
        {
            get { if (instance == null) instance = new KhachDAO(); return KhachDAO.instance; }
            private set { KhachDAO.instance = value; }
        }
        private KhachDAO() { }
        //
        
        //hàm lấy danh sách Khách
        public List<Khach> GetListKhach()
        {
            List<Khach> list = new List<Khach>();

            string query = "select * from KhachHang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            {
                foreach (DataRow item in data.Rows)
                {
                    Khach khach = new Khach(item);
                    list.Add(khach);
                }
            }

            return list;
        }
        //
        public Khach GetKhachByID(int id)
        {
            Khach khach = null;

            string query = "select * from dbo.Khachhang where id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                khach = new Khach(item);
                return khach;
            }
            return khach;
        }

        //hàm tiềm kiếm Khach
        public List<Khach> SearchKhachByName(string name)//tim ten khách
        {
            List<Khach> list = new List<Khach>();

            string query = string.Format("SELECT * FROM dbo.KhachHang WHERE dbo.fuConvertToUnsign1(name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%' ", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Khach khach = new Khach(item);
                list.Add(khach);
            }

            return list;
        }

        //hàm thêm Khach
        public bool InsertKhach(string name, int cmnd,int sdt,string gioitinh,string diachi,float price)
        {
            string query = string.Format("INSERT dbo.KhachHang ( name, CMND, SDT,GioiTinh,DiaChi,price )VALUES  ( N'{0}', {1}, {2}, N'{3}', N'{4}',{5})", name, cmnd,sdt,gioitinh,diachi,price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //hàm sửa Khach
        public bool UpdateKhach(string name , int cmnd, int sdt, string gioitinh, string diachi, int idKhach)
        {
            string query = string.Format("UPDATE dbo.KhachHang SET name = N'{0}', cmnd = {1}, sdt = {2}, gioitinh= N'{3}', diachi= N'{4}' WHERE id = {5}", name, cmnd, sdt, gioitinh, diachi, idKhach);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //hàm xóa Khách
        public bool DeleteKhach(int idKhachHang)
        {
            string query = string.Format("Delete KhachHang where id= {0} ", idKhachHang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
