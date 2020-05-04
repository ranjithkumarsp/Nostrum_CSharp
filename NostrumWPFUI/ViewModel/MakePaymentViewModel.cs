using NostrumWPFUI.UIEntity;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumWPFUI.ViewModel
{
    public class MakePaymentViewModel : BaseViewModel
    {
        public MakePaymentViewModel()
        {

        }

        #region Properties

        private ClientPayment _selectedClient;

        public ClientPayment SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value;this.RaisePropertyChange(); }
        }


        private string _invoiceNumber;

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { SelectedClient.InvoiceNo = value;this.RaisePropertyChange(); }
        }

        private string _outstandingBalance;

        public string OutstandingBalance
        {
            get { return _outstandingBalance; }
            set { _outstandingBalance = value; this.RaisePropertyChange(); }
        }

        private double _paymentAmount;

        public double PaymentAmount
        {
            get { return _paymentAmount; }
            set { _paymentAmount = value; this.RaisePropertyChange(); }
        }



        #endregion

        #region Commands

        private DelegateCommand _makepayment;
        public DelegateCommand MakePaymentCommand =>
            _makepayment ?? (_makepayment = new DelegateCommand(ExecuteMakePayment));
              

        public void ExecuteMakePayment()
        {

        }

        #endregion
    }
}
