using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DTO
{
  public class Menu
    {
        public Menu(string khachName,int cmnd,int sdt,string diachi, int count, DateTime? DateCheckIn, float price, float totalPrice = 0)
        {
            this.KhachName = khachName;
            this.Cmnd = cmnd;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }
        public Menu(DataRow row)
        {
            this.KhachName = row["Name"].ToString();
            this.Cmnd = (int) row["cmnd"];
            this.Sdt = (int)row["sdt"];
            this.Diachi = row["diachi"].ToString();
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        private string khachName;

        public string KhachName
        {
            get { return khachName; }
            set { khachName = value; }
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
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        private DateTime? DateCheckIn;

        public DateTime? DateCheckin
        {
            get { return DateCheckIn; }
            set { DateCheckIn = value; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private float totalPrice;

        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        

        
    }
}
