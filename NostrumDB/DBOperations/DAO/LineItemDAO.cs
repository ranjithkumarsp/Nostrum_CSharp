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
            string query = "Insert into order_line_items values('" + lineItem.Order_Id + "','" + lineItem.FY + "','" + lineItem.S_No + "','" + lineItem.Product_Name + "','" + lineItem.Batch + "','" + lineItem.Offer1 + "','" + lineItem.Offer2 + "','" + lineItem.Pack1 + "','" + lineItem.Pack2 + "','" + lineItem.Quantity + "','" + lineItem.Rate + "');";
            int nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteLineItem(double orderId, string fy, int sNo)
        {
            string query = "Delete from order_line_items where Order_Id = '" + orderId + "' and fy = '" + fy + "' and S_No = '"+ sNo +"';";
            int nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteAllLineItems(double orderId, string fy)
        {
            string query = "Delete from order_line_items where Order_Id = '" + orderId + "' and fy = '" + fy + "';";
            int nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public List<LineItem> GetLineItems(double orderId, string fy)
        {
            List<LineItem> lineItems = new List<LineItem>();
            string query = "Select * from order_line_items where Order_Id = '" + orderId + "' and FY = '" + fy + "';";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                LineItem lineItem = new LineItem
                {
                    Order_Id = (double)dr["Order_Id"],
                    FY = dr["FY"].ToString(),
                    S_No = (int)dr["S_No"],
                    Product_Name = dr["Product_Name"].ToString(),
                    Batch = dr["Batch"].ToString(),
                    Offer1 = (int)dr["Offer1"],
                    Offer2 = (int)dr["Offer2"],
                    Pack1 = (int)dr["Pack1"],
                    Pack2 = (int)dr["Pack2"],
                    Quantity = (double)dr["Quantity"],
                    Rate = (double)dr["Rate"]
                };
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
