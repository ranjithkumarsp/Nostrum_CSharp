using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumWPFUI.UIEntity
{
    public class StockDisplay
    {
        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }

        private string _invoiceNo;

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set { _invoiceNo = value; }
        }

        private string _manufacturer;

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }

        private string _batchno;

        public string BatchNo
        {
            get { return _batchno; }
            set { _batchno = value; }
        }

        private string _manufacturedate;

        public string ManufactureDate
        {
            get { return _manufacturedate; }
            set { _manufacturedate = value; }
        }

        private string _expiryDate;

        public string ExpiryDate
        {
            get { return _expiryDate; }
            set { _expiryDate = value; }
        }

        private string _purchaseQty;

        public string PurchaseQty
        {
            get { return _purchaseQty; }
            set { _purchaseQty = value; }
        }

        private string _saleQty;

        public string SaleQty
        {
            get { return _saleQty; }
            set { _saleQty = value; }
        }

        private int _stock;

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        private string _remarks;

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
    }
}
