using Nostrum.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nostrum.UIEntity
{
    public class OutstandingPayment : BaseViewModel
    {
        private string _serailno;

        public string SerialNo
        {
            get { return _serailno; }
            set { _serailno = value;this.RaisePropertyChange(); }
        }

        private string _invoiceDate;

        public string InvoiceDate
        {
            get { return _invoiceDate; }
            set { _invoiceDate = value; this.RaisePropertyChange(); }
        }

        private string _invoiceNo;

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set { _invoiceNo = value; this.RaisePropertyChange(); }
        }

        private int _invoiceAmount;

        public int InvoiceAmount
        {
            get { return _invoiceAmount; }
            set { _invoiceAmount = value; this.RaisePropertyChange(); }
        }

    }
}
