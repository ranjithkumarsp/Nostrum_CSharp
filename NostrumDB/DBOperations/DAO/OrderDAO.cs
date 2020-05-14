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
            string query = "Insert into orders values('" + order.Order_Id + "','" + order.FY + "','" + order.Order_Date.ToString("yyyy-MM-dd") + "','" + type + "','" + order.Client_Name + "','" + order.Amount + "','" + order.Balance + "','" + order.Discount+ "','" + order.Payment_Terms + "','" + order.Dispatch_Mode + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteOrder(int orderId, string fy)
        {
            int nRowsAffected = 0;
            string query = "Delete from orders where Order_Id = '" + orderId + "' and fy = '" + fy + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public Order GetOrder(int orderId, string fy)
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
                order.Amount = (int)reader["Amount"];
                order.Balance = (int)reader["Balance"];
                order.Discount = (double)reader["Discount"];
                order.Payment_Terms = reader["Payment_Terms"].ToString();
                if (reader["Order_Type"].ToString().Equals("Donate"))
                {
                    order.Order_Type = Order.OrderType.DonateOrder;
                }
                else
                {
                    order.Order_Type = Order.OrderType.SaleOrder;
                }
            }
            else
            {
                Console.WriteLine("Get Order returns 0 rows..!");
            }

            return order;
        }

        public List<Order> GetPaymentDetails(string name, DateTime from, DateTime to)
        {
            string query = "SELECT Order_Id, FY, Client_Name, Order_Date, Amount, Balance from Orders where Order_type = 'Sale' and Client_Name = '" + name + "' and Order_date between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "' order by Order_Date, Order_Id;";
            return GetPaymentDetailsInternal(query);
        }

        public List<Order> GetPendingPayments(string name, DateTime from, DateTime to)
        {
            string query = "SELECT Order_Id, FY, Client_Name, Order_Date, Amount, Balance from Orders where Order_type = 'Sale' and Client_Name = '" + name + "' and Order_date between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "' and Balance > 0 order by Order_Date, Order_Id;";
            return GetPaymentDetailsInternal(query);
        }

        private List<Order> GetPaymentDetailsInternal(string query)
        {
            List<Order> orderList = new List<Order>();

            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            foreach (DataRow dr in dataTable.Rows)
            {
                Order order = new Order();
                order.Order_Id = (int)dr["Order_Id"];
                order.FY = dr["FY"].ToString();
                order.Client_Name = dr["Client_Name"].ToString();
                order.Order_Date = (DateTime)dr["Order_Date"];
                order.Amount = (int)dr["Amount"];
                order.Balance = (int)dr["Balance"];
                orderList.Add(order);
            }
            return orderList;
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

        public List<Product> GetSaleData(string name, string batch, DateTime from, DateTime to)
        {
            List<Product> productList = new List<Product>();
            string query = "SELECT Orders.Order_Date as date, Orders.Order_Type as type, Orders.Order_Id as id, Orders.fy as fy, Orders.Client_Name as client, order_line_items.batch as batch, order_line_items.quantity as qty, order_line_items.offer1 as off1, order_line_items.offer2 as off2, order_line_items.pack1 as pack1, order_line_items.pack2 as pack2 FROM Orders inner join order_line_items where Orders.Order_Id=order_line_items.order_id and Orders.fy=order_line_items.fy and order_line_items.product_name='" + name + "' and order_line_items.batch='"+batch+"' and Orders.Order_date between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "' order by Orders.Order_Date;";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            List<string> orderIds = new List<string>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Product prod = new Product();
                prod.Name = name;
                prod.Batch = dr["batch"].ToString();
                prod.Manufacturer = dr["client"].ToString();
                prod.Purchase_Date = (DateTime)dr["date"];
                int off1 = (int)dr["off1"];
                int off2 = (int)dr["off2"];
                int pack1 = (int)dr["pack1"];
                int pack2 = (int)dr["pack2"];
                int qty = (int)dr["qty"];

                int saleQty = qty;

                if (off1 != 0 && off2 != 0)
                    saleQty = (qty / off1) * (off1 + off2);

                if (pack2 != 0 && pack1 != 0)
                {
                    saleQty = saleQty * pack1 * pack2;
                }
                
                prod.Quantity = saleQty;
                string invNo = "";
                if (dr["type"].ToString().Equals("Donate"))
                {
                    invNo = "Donated";
                }
                else
                {
                    invNo = "INV-";
                    invNo += dr["fy"].ToString();
                    invNo += "-" + dr["id"].ToString();
                }                
                prod.Purchase_Invoice = invNo;
                productList.Add(prod);
            }
            return productList;
        }

        public List<string> GetOrderIds()
        {
            string query = "Select Order_Id, FY, Order_Type from orders;";
            return GetOrderIdsInternal(query);
        }
        public List<string> GetOrderIds(string clientName, DateTime fromDate, DateTime toDate)
        {
            string query = "Select Order_Id, FY, Order_Type from orders where Client_Name='" + clientName + "' and Order_Date between '" + fromDate.ToString("yyyy-MM-dd") + "' and '" + toDate.ToString("yyyy-MM-dd") + "';";
            return GetOrderIdsInternal(query);
        }

        private List<string> GetOrderIdsInternal(string query)
        {
            // Invoice will be generated in the format INV-FY20-1

            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            List<string> orderIds = new List<string>();
            foreach (DataRow dr in dataTable.Rows)
            {
                string orderId = "";
                if(dr["Order_Type"].ToString().Equals("Donate"))
                {
                    orderId = "DNT-";
                }
                else
                {
                    orderId = "INV-";
                }
                orderId += dr["FY"].ToString();
                orderId += "-" + dr["Order_Id"].ToString();
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
            string query = "Update orders set Order_Date = '" + order.Order_Date.ToString("yyyy-MM-dd") + "', Order_Type = '" + type + "', Client_Name = '" + order.Client_Name + "', Amount = '" + order.Amount + "', Balance = '" + order.Balance + "', Discount = '" + order.Discount + "', Payment_Terms = '" + order.Payment_Terms + "', Dispatch_Mode = '" + order.Dispatch_Mode + "' where Order_Id = '" + order.Order_Id + "' and FY = '" + order.FY + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }
    }
}
