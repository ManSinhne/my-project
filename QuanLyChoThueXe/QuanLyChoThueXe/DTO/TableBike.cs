using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DTO
{
  public class TableBike
    {
        public TableBike(int id, string name, string status, string bienso , string brand , string battery , float price)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.Bienso = bienso;
            this.Brand = brand;
            this.Battery = battery;
            this.price = price;
        }

        public TableBike(DataRow row)//hàm dựng để xử lý datarow
        {
            this.ID = (int)row["id"];//lấy ra trường id
            this.Name = row["name"].ToString();
            this.Bienso = row["bienso"].ToString();
            this.Brand = row["brand"].ToString();
            this.Battery = row["battery"].ToString();
            this.Status = row["status"].ToString();
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        
        private string bienso;
        public string Bienso
        {
            get { return bienso; }
            set { bienso = value; }
        }
           
        private string battery;
        public string Battery
        {
            get { return battery; }
            set { battery = value; }    
        }
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string brand;
        public string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
            }
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

    }
}
