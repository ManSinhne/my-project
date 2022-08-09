using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DTO
{
  public class Khach
    {
        public Khach(int id, string name, float price,int cmnd,int sdt,string gioitinh,string diachi)
        {
            this.ID = id;
            this.Name = name;
            this.Cmnd = cmnd;
            this.Sdt = sdt;
            this.Gioitinh = gioitinh;
            this.Diachi = diachi;
            this.Price = price;
        }

        public Khach(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Name = row["name"].ToString();
            this.Cmnd = (int)Convert.ToInt64(row["cmnd"].ToString());
            this.Sdt = (int)Convert.ToInt64(row["sdt"].ToString());
            this.Gioitinh = (string)row["gioitinh"];
            this.Diachi = (string)row["diachi"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());

        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
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
        
        private string gioitinh;

        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
