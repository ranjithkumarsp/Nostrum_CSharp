using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace NostrumDB
{
    public class LineItemDAO : ILineItemDAO
    {
        IDBInterface _dbInterface;
        public LineItemDAO(IDBInterface dbInterface)
        {
            _dbInterface = dbInterface;
            _dbInterface.InitializeDB();
        }
        public bool AddLineItem(LineItem lineItem)
        {
            int nRowsAffected = 0;
            string query = "Insert into order_line_items values('" + lineItem.Order_Id + "','" + lineItem.FY + "','" + lineItem.S_No + "','" + lineItem.Product_Name + "','" + lineItem.Batch + "','" + lineItem.Offer1 + "','" + lineItem.Offer2 + "','" + lineItem.Pack1 + "','" + lineItem.Pack2 + "','" + lineItem.Quantity + "','" + lineItem.Rate + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteLineItem(int orderId, string fy, int sNo)
        {
            int nRowsAffected = 0;
            string query = "Delete from order_line_items where Order_Id = '" + orderId + "' and fy = '" + fy + "' and S_No = '"+ sNo +"';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteAllLineItems(int orderId, string fy)
        {
            int nRowsAffected = 0;
            string query = "Delete from order_line_items where Order_Id = '" + orderId + "' and fy = '" + fy + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public List<LineItem> GetLineItems(int orderId, string fy)
        {
            List<LineItem> lineItems = new List<LineItem>();
            string query = "Select * from order_line_items where Order_Id = '" + orderId + "' and FY = '" + fy + "';";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                LineItem lineItem = new LineItem();
                lineItem.Order_Id = (int)dr["Order_Id"];
                lineItem.FY = dr["FY"].ToString();
                lineItem.S_No = (int)dr["S_No"];
                lineItem.Product_Name = dr["Product_Name"].ToString();
                lineItem.Batch = dr["Batch"].ToString();
                lineItem.Offer1 = (int)dr["Offer1"];
                lineItem.Offer2 = (int)dr["Offer2"];
                lineItem.Pack1 = (int)dr["Pack1"];
                lineItem.Pack2 = (int)dr["Pack2"];
                lineItem.Quantity = (double)dr["Quantity"];
                lineItem.Rate = (double)dr["Rate"];
                lineItem.FillRemainingFields();
                lineItems.Add(lineItem);
            }

            return lineItems;
        }

        public bool UpdateLineItem(LineItem lineItem)
        {
            DeleteLineItem(lineItem.Order_Id, lineItem.FY, lineItem.S_No);
            return AddLineItem(lineItem);
        }
    }
}
