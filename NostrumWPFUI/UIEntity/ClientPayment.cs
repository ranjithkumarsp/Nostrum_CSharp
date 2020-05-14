using Nostrum.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nostrum.UIEntity
{
    public class ClientPayment :BaseViewModel
    {

        private int _orderId;

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        private string _fy;

        public string FY
        {
            get { return _fy; }
            set { _fy = value; }
        }

        public string InvoiceNo
        {
            get { return "INV-"+FY+"-"+OrderId; }
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

        private int _amount;

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; this.RaisePropertyChange(); }
        }

        private int _balance;

        public int Balance
        {
            get { return _balance; }
            set { _balance = value; this.RaisePropertyChange(); }
        }

    }
}
