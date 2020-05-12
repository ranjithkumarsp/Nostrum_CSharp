using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        public enum OrderType
        {
            SaleOrder,
            DonateOrder
        }

        public int Order_Id { get; set; }
        public string FY { get; set; }
        public DateTime Order_Date { get; set; }
        public string Dispatch_Mode { get; set; }
        public string Client_Name { get; set; }
        public int Amount { get; set; }
        public double Discount { get; set; }
        public string Payment_Terms { get; set; }
        public OrderType Order_Type { get; set; }
        public bool IsNewOrder { get; set; }

        public int Balance { get; set; }
    }
}
