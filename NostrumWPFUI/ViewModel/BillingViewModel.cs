using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using NostrumDB;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace NostrumWPFUI.ViewModel
{
    public class BillingViewModel : BaseViewModel
    {
        public BillingViewModel()
        {
            Initialize();
        }

        public ICommand BillingCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand GotFocusCommand { get; set; }
        public ICommand ViewOldCommand { get; set; }
        public RelayCommand<string> RadioButtonCheckedCommand { get;set;}
        ViewOldPopupView viewOldPopupView;
        ViewOldPopupViewModel _viewOldPopupViewModel;

        public void Initialize()
        {
            loadDefaults();
            BillingCommand = new CustomDelegateCommand(BillingMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
            GotFocusCommand = new CustomDelegateCommand(GotFocusMethod);
            ViewOldCommand = new CustomDelegateCommand(OpenViewOldPopUp);
            RadioButtonCheckedCommand = new RelayCommand<string>(RadioButtonChecked);

            GetClientsFromDB();
        }

        private void loadDefaults()
        {
            IsBillingChecked = true;
            BillingDonateCommandText = "Billing";
            PaymentTerms = 30;
            FinancialYear = "2020";
            BillDate = DateTime.Now.ToShortDateString();
        }
        private void RadioButtonChecked(string _radioBtn)
        {
            switch(_radioBtn)
            {
                case "BillingRadioBtn":
                    BillingDonateCommandText = "Billing";
                    break;
                case "DonationRadioBtn":
                    BillingDonateCommandText = "Donate";
                    break;
            }
        }

        private void OpenViewOldPopUp(object obj)
        {
            if (viewOldPopupView == null)
                viewOldPopupView = new ViewOldPopupView();
            if(_viewOldPopupViewModel== null)
             _viewOldPopupViewModel = new ViewOldPopupViewModel();
            viewOldPopupView.DataContext = _viewOldPopupViewModel;
            viewOldPopupView.Owner = MainWindow;
            viewOldPopupView.Show();
        }

        public void BillingMethod(object param)
        {
            BillFormView bfm = new BillFormView();
            bfm.Owner = MainWindow;
            bfm.ShowDialog();
        }
        public void ClearMethod(object param)
        {
            BillDate = string.Empty;
            InvoiceNumber = string.Empty;
            FinancialYear = string.Empty;
            PaymentTerms = 0;
        }

        private List<string> _clientsList;

        public List<string> ClientsList
        {
            get { return _clientsList; }
            set { _clientsList = value; this.RaisePropertyChange(); }
        }

        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private bool _isBillingChecked;

        public bool IsBillingChecked
        {
            get { return _isBillingChecked; }
            set { _isBillingChecked = value; this.RaisePropertyChange(); }
        }

        private bool _isDonationChecked;

        public bool IsDonationChecked
        {
            get { return _isDonationChecked; }
            set { _isDonationChecked = value; this.RaisePropertyChange(); }
        }

        private string _billingDonateCommandText;

        public string BillingDonateCommandText
        {
            get { return _billingDonateCommandText; }
            set { _billingDonateCommandText = value; this.RaisePropertyChange(); }
        }

        private string _financialYear;

        public string FinancialYear
        {
            get { return _financialYear; }
            set { _financialYear = value; this.RaisePropertyChange(); }
        }

        private string _invoiceNumber;

        public string InvoiceNumber
        {
            get { return _invoiceNumber; }
            set { _invoiceNumber = value; this.RaisePropertyChange(); }
        }

        private int _paymentTerms;

        public int PaymentTerms
        {
            get { return _paymentTerms; }
            set { _paymentTerms = value; this.RaisePropertyChange(); }
        }

        private string _billDate;

        public string BillDate
        {
            get { return _billDate; }
            set { _billDate = value; this.RaisePropertyChange(); }
        }



        public void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            ClientsList = dao.getClients();
        }

        public void SetFocus(object window,string controlname)
        {
            var parent = window as BillingView;
            if (parent != null)
            {               

            }
        }
        private void GotFocusMethod(object obj)
        {
           // InvoiceNumber = getInvoiceNumber(FinancialYear);
        }

        public string getInvoiceNumber(string _fy)
        {
            string invoiceNo = string.Empty;
            int invoice = 0;
           Entity.Order p = new Entity.Order();
            OrderDAO _orderDAO = new OrderDAO(new MySQLDBInterface());
            if(_fy != null)
            {
                invoice = _orderDAO.getNextInvNo(_fy);
            }
            else
            {
               invoice =  _orderDAO.getNextInvNo();                
            }
            invoiceNo = invoice.ToString();
            return invoiceNo;


        }

    }
}
