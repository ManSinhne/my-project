using QuanLyChoThueXe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe.DAO
{
 public class TableBikeDAO
    {
        private static TableBikeDAO instance;

        internal static TableBikeDAO Instance
        {
            get { if (instance == null) instance = new TableBikeDAO(); return TableBikeDAO.instance; }
            private set { TableBikeDAO.instance = value; }
        }
        //lưu giá trị để sau này có thể dùng lại
        public static int TableWidth = 195;
        public static int TableHeight = 195;

        private TableBikeDAO() { }
        
        //hàm load danh sách xe
        public List<TableBike> LoadTableList()
        {
            List<TableBike> tableList = new List<TableBike>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList1");//lấy table lên
            foreach (DataRow item in data.Rows)//trong danh sách dòng lấy ra từng dòng trong danh sách data.row
            {
                TableBike tablebike = new TableBike(item);
                tableList.Add(tablebike);  
            }
            return tableList;
        }
    }
}
