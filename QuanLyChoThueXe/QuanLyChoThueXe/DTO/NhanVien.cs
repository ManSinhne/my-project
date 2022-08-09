using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DTO
{
   public class NhanVien
    {
        public NhanVien(int id,string userName, string ngaySinh,string gioiTinh, int cmnd,int sdt, string queQuan)
        {
            this.ID = id;
            this.UserName = userName;
            this.Cmnd = cmnd;
            this.Sdt = sdt;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.QueQuan = queQuan;
        }

        public NhanVien(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.UserName = row["userName"].ToString();
            this.Cmnd = (int)row["cmnd"];
            this.Sdt = (int)row["sdt"];
            this.NgaySinh = row["ngaySinh"].ToString();
            this.GioiTinh = (string)row["gioitinh"];
            this.QueQuan = row["queQuan"].ToString();
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private int cmnd;

        public int Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }

        private int sdt;

        public int Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private string ngaySinh;

        public string NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        private string gioiTinh;

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        private string queQuan;

        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }

       

       
    }
}
