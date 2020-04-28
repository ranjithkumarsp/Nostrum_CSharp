using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Payment
    {
        private string _paymentId;
        private int _orderId;
        private string _fy;
        private double _amount;
        private DateTime _payDate;

        public string Payment_ID
        {
            get
            {
                return _paymentId;
            }
            set
            {
                _paymentId = value;
            }
        }
        public int Order_ID
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
        public DateTime Pay_Date
        {
            get
            {
                return _payDate;
            }
            set
            {
                _payDate = value;
            }
        }
    }
}
