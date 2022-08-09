using QuanLyChoThueXe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DAO
{
   public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }
        }
        private NhanVienDAO() { }

        //hàm lấy danh sách Nhân Viên
        public List<NhanVien> GetListNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();

            string query = "select id,UserName,CMND,SDT,NgaySinh,GioiTinh,QueQuan from Nhanvien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanvien = new NhanVien(item);
                list.Add(nhanvien);
            }

            return list;
        }
        //
        public NhanVien GetNhanVienByID(int id)
        {
            NhanVien nhanvien = null;

            string query = "select * from dbo. Nhanvien where id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                nhanvien = new NhanVien(item);
                return nhanvien;
            }
            return nhanvien;
        }
        //hàm thêm nhân viên
        public bool InsertNhanVien( string UserName, int CMND, int SDT, string NgaySinh, string GioiTinh, string QueQuan)
        {
            string query = string.Format("INSERT dbo.Nhanvien ( UserName, CMND, SDT,NgaySinh, GioiTinh ,QueQuan ) VALUES  (  N'{0}', {1}, {2}, N'{3}', N'{4}', N'{5}' )", UserName, CMND, SDT, NgaySinh, GioiTinh, QueQuan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //hàm sửa Nhân viên
        public bool UpdateNhanVien(string UserName, int CMND, int SDT, string NgaySinh, string GioiTinh, string QueQuan, int idNhanvien)
        {
            string query = string.Format("UPDATE dbo.Nhanvien SET UserName = N'{0}', CMND = {1}, SDT = {2},NgaySinh =N'{3}', GioiTinh= N'{4}', QueQuan= N'{5}' WHERE id = {6}", UserName, CMND, SDT, NgaySinh, GioiTinh, QueQuan, idNhanvien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        //hàm xóa Nhân Viên
        public bool DeleteNhanVien(int idNhanvien)
        {
            string query = string.Format("Delete Nhanvien where id= {0}", idNhanvien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
