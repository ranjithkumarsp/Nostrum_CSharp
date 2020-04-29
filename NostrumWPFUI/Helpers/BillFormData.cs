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

        public string Product
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

        private string _packing;

        public string Packing
        {
            get { return _packing; }
            set { _packing = value; this.RaisePropertyChange(); }
        }

        private string _offer;

        public string Offer
        {
            get { return _offer; }
            set { _offer = value; this.RaisePropertyChange(); }
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
