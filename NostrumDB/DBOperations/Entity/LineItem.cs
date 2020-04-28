using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LineItem
    {
        private int _orderId;
        private string _fy;
        private int _sNo;
        private string _productName;
        private string _batch;
        private int _offer1;
        private int _offer2;
        private int _pack1;
        private int _pack2;
        private int _quantity;
        private double _rate;

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
        public int S_No
        {
            get
            {
                return _sNo;
            }
            set
            {
                _sNo = value;
            }
        }
        public string Product_Name
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }
        public string Batch
        {
            get
            {
                return _batch;
            }
            set
            {
                _batch = value;
            }
        }
        public int Offer1
        {
            get
            {
                return _offer1;
            }
            set
            {
                _offer1 = value;
            }
        }
        public int Offer2
        {
            get
            {
                return _offer2;
            }
            set
            {
                _offer2 = value;
            }
        }
        public int Pack1
        {
            get
            {
                return _pack1;
            }
            set
            {
                _pack1 = value;
            }
        }
        public int Pack2
        {
            get
            {
                return _pack2;
            }
            set
            {
                _pack2 = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        public double Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                _rate = value;
            }
        }
    }
}
