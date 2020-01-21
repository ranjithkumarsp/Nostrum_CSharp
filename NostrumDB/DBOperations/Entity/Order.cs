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
        private string _orderId;
        private string _fy;
        private DateTime _orderDate;
        private string _dispatchMode;
        private string _clientName;
        private double _amount;
        private double _discount;
        private int _paymentTerms;
        private OrderType _orderType;
        public string Order_Id
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;
            }
        }
        public string FY
        {
            get
            {
                return _fy;
            }
            set
            {
                _fy = value;
            }
        }
        public DateTime Order_Date
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
            }
        }
        public string Dispatch_Mode
        {
            get
            {
                return _dispatchMode;
            }
            set
            {
                _dispatchMode = value;
            }
        }
        public string Client_Name
        {
            get
            {
                return _clientName;
            }
            set
            {
                _clientName = value;
            }
        }
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
            }
        }
        public int Payment_Terms
        {
            get
            {
                return _paymentTerms;
            }
            set
            {
                _paymentTerms = value;
            }
        }
        public OrderType Order_Type
        {
            get
            {
                return _orderType;
            }
            set
            {
                _orderType = value;
            }
        }
    }
}
