using Entity;
using NostrumWPFUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumWPFUI.Helpers
{
    public class BillFormData : BaseViewModel
    {
        private int _sno;

        public int SNo
        {
            get { return _sno; }
            set
            {
                _sno = value;
                this.RaisePropertyChange();
            }
        }

        private string _product;

        public string ProductName
        {
            get { return _product; }
            set
            {
                _product = value;
                this.RaisePropertyChange();
            }
        }

        private string _batchNo;

        public string BatchNo
        {
            get { return _batchNo; }
            set { _batchNo = value; this.RaisePropertyChange(); }
        }

        private Product.DrugType _drugType;

        public Product.DrugType DrugType
        {
            set
            {
                _drugType = value;
            }
        }

        private int _pack1;

        public int Pack1
        {
            get { return _pack1; }
            set { _pack1 = value; }
        }

        private int _pack2;

        public int Pack2
        {
            get { return _pack2; }
            set { _pack2 = value; }
        }

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

        private int _off1;

        public int Off1
        {
            get { return _off1; }
            set { _off1 = value; }
        }

        private int _off2;

        public int Off2
        {
            get { return _off2; }
            set { _off2 = value; }
        }

        private string _offer;

        public string Offer
        {
            get {
                if (Off1 == 0 || Off2 == 0)
                    return "Nett Rate!";
                else
                    return Off1 + " + " + Off2;
            }
        }

        private string _expDate;

        public string ExpDate
        {
            get { return _expDate; }
            set { _expDate = value; this.RaisePropertyChange(); }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; this.RaisePropertyChange(); }
        }

        private double _rate;

        public double Rate
        {
            get { return _rate; }
            set { _rate = value; this.RaisePropertyChange(); }
        }

        private double _mrp;

        public double MRP
        {
            get { return _mrp; }
            set { _mrp = value; this.RaisePropertyChange(); }
        }

        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; this.RaisePropertyChange(); }
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


    }
}
