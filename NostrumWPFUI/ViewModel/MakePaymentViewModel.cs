using Entity;
using NostrumDB;
using Nostrum.UIEntity;
using Nostrum.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nostrum.ViewModel
{
    public class MakePaymentViewModel : BaseViewModel
    {
        MakePaymentView _makePaymentview;
        public MakePaymentViewModel(ClientPayment selectedClient, List<string> pendingInvoiceList)
        {
            SelectedClient = selectedClient;
            InvoiceList = pendingInvoiceList;
            Initialize();
        }

        private void Initialize()
        {
            InvoiceNumber = InvoiceList[0];
            PayDate = DateTime.Today;
        }

        #region Properties

        public string Header { get => "Payment made by " + SelectedClient.Client; set => SelectedClient.Client = value; }

        private ClientPayment _selectedClient;

        public ClientPayment SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value;this.RaisePropertyChange(); }
        }

        private List<string> _invoiceList;

        public List<string> InvoiceList
        {
            get { return _invoiceList; }
            set { _invoiceList = value; this.RaisePropertyChange(); }
        }

        public string InvoiceNumber
        {
            get { return SelectedClient.InvoiceNo; }
            set {
                string invoicNo = value;
                SelectedClient.OrderId = Convert.ToInt32(invoicNo.Substring(invoicNo.LastIndexOf('-') + 1));
                SelectedClient.FY = invoicNo.Substring(invoicNo.IndexOf('-')+1,4);
                this.RaisePropertyChange(); 
            }
        }

        private DateTime _payDate;
        public DateTime PayDate
        {
            get { return _payDate; }
            set { _payDate = value; this.RaisePropertyChange(); }
        }

        public int OutstandingBalance
        {
            get { return SelectedClient.Balance; }
            set { SelectedClient.Balance = value; this.RaisePropertyChange(); }
        }

        private double _paymentAmount;

        public double PaymentAmount
        {
            get { return _paymentAmount; }
            set {
                if (value <= 0)
                {
                    MessageBox.Show("Invalid Amount", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                { 
                    _paymentAmount = value; this.RaisePropertyChange();
                }
            }
        }

        #endregion

        #region Commands

        private DelegateCommand<object> _makepayment;
        public DelegateCommand<object> MakePaymentCommand =>
            _makepayment ?? (_makepayment = new DelegateCommand<object>(ExecuteMakePayment));

        public void ExecuteMakePayment(object param)
        {
            _makePaymentview = param as MakePaymentView;
            Payment payment = new Payment();
            payment.Order_ID = SelectedClient.OrderId;
            payment.FY = SelectedClient.FY;
            payment.PaymentMade = (int)Math.Round(PaymentAmount);
            payment.Pay_Date = PayDate;
            PaymentDAO paymentDAO = new PaymentDAO(new MySQLDBInterface());
            if(paymentDAO.AddPayment(payment))
            {
                MessageBox.Show("Payment Added Successfully", "Info", MessageBoxButton.OK,MessageBoxImage.Information);
                if (_makePaymentview != null)
                    _makePaymentview.Close();
            }
            else
            {
                MessageBox.Show("Unable to add payment", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
