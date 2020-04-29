using NostrumDB;
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

        private Product.DrugType _drugType;
        public string Packing
        {
            get
            {
                if (Product.DrugType.Syrup == _drugType)
                {
                    return Pack1 + " ml";
                }
                else
                {
                    return Pack1 + " x " + Pack2;
                }
            }
        }

        public string Offer
        {
            get
            {
                if (Offer1 == 0 || Offer2 == 0)
                    return "Nett Rate!";
                else
                    return Offer1 + " + " + Offer2;
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
        private string _expDate;

        public string ExpDate
        {
            get { return _expDate; }
            set { _expDate = value; }
        }

        private double _mrp;

        public double MRP
        {
            get { return _mrp; }
            set { _mrp = value; }
        }

        public double Amount
        {
            get { return Rate * Quantity; }
        }

        private double _cgst;

        public double CGST
        {
            get { return _cgst; }
            set { _cgst = value; }
        }

        private double _sgst;

        public double SGST
        {
            get { return _sgst; }
            set { _sgst = value; }
        }

        public void ClearAll()
        {
            Order_Id = 0;
            FY = "";
            S_No = 0;
            Product_Name = "";
            Batch = "";
            Pack1 = 0;
            Pack2 = 0;
            Offer1 = 0;
            Offer2 = 0;
            Quantity = 0;
            Rate = 0;

            MRP = 0;
            ExpDate = "";
            _drugType = Product.DrugType.Tablet;
            CGST = 0;
            SGST = 0;
        }
        public void FillRemainingFields()
        {
            ProductDAO productDao = new ProductDAO(new MySQLDBInterface());
            Product product = productDao.GetProduct(Product_Name, Batch);

            MRP = product.MRP;
            ExpDate = product.Exp_Date.ToString("MMM-yy");
            _drugType = product.Drug_Type;
            CGST = product.CGST;
            SGST = product.SGST;
        }
    }
}
