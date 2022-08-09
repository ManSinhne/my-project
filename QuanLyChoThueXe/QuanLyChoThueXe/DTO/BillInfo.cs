using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DTO
{
  public class BillInfo//lưu trữ những thông tin thuộc tính của bill
    {
        public BillInfo(int id, int billID, int KhachID, int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.KhachID = khachID;
            this.Count = count;
        }
        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.KhachID = (int)row["idkhach"];
            this.Count = (int)row["count"];
        }

        private int count;//foodcount không phải đếm số lượng

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int khachID;

        public int KhachID
        {
            get { return khachID; }
            set { khachID = value; }
        }
        private int billID;

        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
