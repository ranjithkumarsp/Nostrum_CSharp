using NostrumWPFUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumWPFUI.UIEntity
{
    public class ClientPayment :BaseViewModel
    {
        private string _invoiceNo;

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set { _invoiceNo = value; this.RaisePropertyChange(); }
        }

        private string _client;

        public string Client
        {
            get { return _client; }
            set { _client = value; this.RaisePropertyChange(); }
        }

        private string _datet;

        public string Date
        {
            get { return _datet; }
            set { _datet = value; this.RaisePropertyChange(); }
        }

        private double _amount;

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; this.RaisePropertyChange(); }
        }

        private double _balance;

        public double Balance
        {
            get { return _balance; }
            set { _balance = value; this.RaisePropertyChange(); }
        }

    }
}
