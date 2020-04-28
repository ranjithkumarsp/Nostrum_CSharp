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
        public bool addOrder(Order order)
        {
            int nRowsAffected = 0;
            string query = "Insert into orders values('" + order.Order_Id + "','" + order.FY + "','" + order.Order_Date.ToString("yyyy-MM-dd") + "','" + order.Dispatch_Mode + "','" + order.Client_Name + "','" + order.Amount + "','" + order.Discount+ "','" + order.Payment_Terms + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool deleteOrder(string orderId, string fy)
        {
            int nRowsAffected = 0;
            string query = "Delete from orders where Order_Id = '" + orderId + "' and fy = '" + fy + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public Order getOrder(string orderId, string fy)
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

        public int getNextInvNo(string FY)
        {
            int invNo = 0;
            string query = "Select max(Order_Id) as invoiceNo from orders where fy = '" + FY + "';";

            invNo = (int)_dbInterface.ExecuteScalar(query);
            return ++invNo;
        }

        public int getNextInvNo()
        {
            int invNo = 0;
            string fy;
            string query = "Select FY from orders order by FY desc;";
            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow reader = dataTable.Rows[0];
                fy = reader["FY"].ToString();
                invNo = getNextInvNo(fy);
            }
            else
            {
                Console.WriteLine("Get Invoice No returns 0 rows..!");
            }
            return ++invNo;
        }

        public List<string> getOrderIds()
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

        public bool updateOrder(Order order)
        {
            int nRowsAffected = 0;
            string query = "Update orders set Order_Date = '" + order.Order_Date.ToString("yyyy-MM-dd") + "', Dispatch_Mode = '" + order.Dispatch_Mode + "', Client_Name = '" + order.Client_Name + "', Amount = '" + order.Amount + "', Discount = '" + order.Discount + "', Payment_Terms = '" + order.Payment_Terms + "' where Order_Id = '" + order.Order_Id + "' and FY = '" + order.FY + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }
    }
}
