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
        private int _orderId;
        private string _fy;
        private DateTime _orderDate;
        private string _dispatchMode;
        private string _clientName;
        private int _amount;
        private int _balance;
        private double _discount;
        private int _paymentTerms;
        private OrderType _orderType;
        public int Order_Id
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
        public int Amount
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

        private bool _isNewOrder;
        public bool IsNewOrder
        {
            get { return _isNewOrder; }
            set
            {
                _isNewOrder = value;
            }
        }

        public int Balance { get => _balance; set => _balance = value; }
    }
}
