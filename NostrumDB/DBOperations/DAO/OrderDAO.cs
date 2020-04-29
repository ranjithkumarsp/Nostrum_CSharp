using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace NostrumDB
{
    public class OrderDAO : IOrderDAO
    {
        IDBInterface _dbInterface;
        public OrderDAO(IDBInterface dbInterface)
        {
            _dbInterface = dbInterface;
            _dbInterface.InitializeDB();
        }
        public bool AddOrder(Order order)
        {
            int nRowsAffected = 0;
            string type = "";
            if (order.Order_Type == Order.OrderType.DonateOrder)
                type = "Donate";
            else
                type = "Sale";
            string query = "Insert into orders values('" + order.Order_Id + "','" + order.FY + "','" + order.Order_Date.ToString("yyyy-MM-dd") + "','" + order.Dispatch_Mode + "','" + order.Client_Name + "','" + order.Amount + "','" + order.Discount+ "','" + order.Payment_Terms + "','" + type + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteOrder(string orderId, string fy)
        {
            int nRowsAffected = 0;
            string query = "Delete from orders where Order_Id = '" + orderId + "' and fy = '" + fy + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public Order GetOrder(string orderId, string fy)
        {
            Order order = new Order();
            string query = "Select * from orders where Order_Id ='" + orderId + "' and fy = '" + fy + "';";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow reader = dataTable.Rows[0];
                order.Order_Id = (int)reader["Order_Id"];
                order.FY = reader["FY"].ToString();
                order.Order_Date = (DateTime) reader["Order_Date"];
                order.Dispatch_Mode = reader["Dispatch_Mode"].ToString();
                order.Client_Name = reader["Client_Name"].ToString();
                order.Amount = (double)reader["Amount"];
                order.Discount = (double)reader["Discount"];
                order.Payment_Terms = (int)reader["Payment_Terms"];
            }
            else
            {
                Console.WriteLine("Get Order returns 0 rows..!");
            }

            return order;
        }

        public int GetNextInvNo(string FY)
        {
            int invNo = 0;
            string query = "Select max(Order_Id) as invoiceNo from orders where fy = '" + FY + "';";

            object obj = _dbInterface.ExecuteScalar(query);
            if (obj != null && obj != DBNull.Value)
                invNo = Convert.ToInt32(obj);
            return ++invNo;
        }

        public int GetNextInvNo()
        {
            int invNo = 0;
            string fy;
            string query = "Select FY from orders order by FY desc;";
            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow reader = dataTable.Rows[0];
                fy = reader["FY"].ToString();
                invNo = GetNextInvNo(fy);
            }
            else
            {
                Console.WriteLine("Get Invoice No returns 0 rows..!");
            }
            return ++invNo;
        }

        public List<string> GetOrderIds()
        {
            // To-do: Format for invoice number has INV or DNT in it. Need to add it.
            List<string> orderIds = new List<string>();
            string query = "Select Order_Id, FY from orders;";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                string orderId = dr["Order_Id"].ToString();
                orderId += "-" + dr["FY"].ToString();
                orderIds.Add(orderId);
            }

            return orderIds;
        }

        public bool UpdateOrder(Order order)
        {
            int nRowsAffected = 0;
            string type = "";
            if (order.Order_Type == Order.OrderType.DonateOrder)
                type = "Donate";
            else
                type = "Sale";
            string query = "Update orders set Order_Date = '" + order.Order_Date.ToString("yyyy-MM-dd") + "', Dispatch_Mode = '" + order.Dispatch_Mode + "', Client_Name = '" + order.Client_Name + "', Amount = '" + order.Amount + "', Discount = '" + order.Discount + "', Payment_Terms = '" + order.Payment_Terms + "', Order_Type = '" + type +  "' where Order_Id = '" + order.Order_Id + "' and FY = '" + order.FY + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }
    }
}
