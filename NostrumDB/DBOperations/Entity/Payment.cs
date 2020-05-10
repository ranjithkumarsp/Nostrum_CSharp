using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Payment
    {
        private int _orderId;
        private string _fy;
        private int _payment;
        private DateTime _payDate;

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

        public int PaymentMade
        {
            get
            {
                return _payment;
            }
            set
            {
                _payment = value;
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
