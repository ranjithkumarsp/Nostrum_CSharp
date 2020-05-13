using Nostrum.Helpers;
using Nostrum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

using NostrumDB;
using Entity;


namespace Nostrum.ViewModel
{
    public class BillingViewModel : BaseViewModel
    {
        #region Properties

        private List<string> _clientsList;

        public List<string> ClientsList
        {
            get { return _clientsList; }
            set { _clientsList = value; this.RaisePropertyChange(); }
        }

        private bool _isBillingChecked;

        public bool IsBillingChecked
        {
            get { return _isBillingChecked; }
            set {
                _isBillingChecked = value;
                if(_isBillingChecked)
                {
                    CurrentOrder.Order_Type = Order.OrderType.SaleOrder;
                    _isDonationChecked = false;
                }
                this.RaisePropertyChange();
            }
        }

        private bool _isDonationChecked;

        public bool IsDonationChecked
        {
            get { return _isDonationChecked; }
            set {
                _isDonationChecked = value;
                if (_isDonationChecked)
                {
                    CurrentOrder.Order_Type = Order.OrderType.DonateOrder;
                    CurrentOrder.Payment_Terms = "-";
                    _isBillingChecked = false;
                }
                this.RaisePropertyChange();
            }
        }

        public string ClientName
        {
            get { return CurrentOrder.Client_Name; }
            set
            {
                CurrentOrder.Client_Name = value;
                this.RaisePropertyChange();
            }
        }

        public int InvoiceNumber
        {
            get { return CurrentOrder.Order_Id; }
            set
            {
                CurrentOrder.Order_Id = value;
                this.RaisePropertyChange();
            }
        }

        public string FinancialYear
        {
            get { return CurrentOrder.FY; }
            set
            {
                CurrentOrder.FY = value;
                this.RaisePropertyChange();
            }
        }

        public DateTime OrderDate
        {
            get { return CurrentOrder.Order_Date; }
            set
            {
                CurrentOrder.Order_Date = value;
                this.RaisePropertyChange();
            }
        }

        public string PaymentTerms
        {
            get { return CurrentOrder.Payment_Terms; }
            set
            {
                CurrentOrder.Payment_Terms = value;
                this.RaisePropertyChange();
            }
        }

        public string DispatchMode
        {
            get { return CurrentOrder.Dispatch_Mode; }
            set { CurrentOrder.Dispatch_Mode = value; this.RaisePropertyChange(); }
        }


        #endregion

        private Order _order;

        public Order CurrentOrder
        {
            get { return _order; }
            set { _order = value;  }
        }
        public BillingViewModel()
        {
            Initialize();
        }

        public ICommand BillingCommand { get; set; }
        public ICommand InvoiceEnterCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand ViewOldCommand { get; set; }

        public BillingView billview;
        public void Initialize()
        {
            BillingCommand = new CustomDelegateCommand(BillingMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
            ViewOldCommand = new CustomDelegateCommand(OpenViewOldPopUp);
            InvoiceEnterCommand = new CustomDelegateCommand(GenerateInvoiceNumber);

            CurrentOrder = new Order();
            
            GetClientsFromDB();
            ClearAll();
            GenerateInvoiceNumber(null);
        }

        private void Refresh(object param)
        {
            GetClientsFromDB();
            ClearAll();
            GenerateInvoiceNumber(null);
        }

        public void BillingMethod(object param)
        {
            if (String.IsNullOrWhiteSpace(ClientName))
            {
                MessageBox.Show("Add client first", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else 
            { 
                AddLineItemView addLineItemView = new AddLineItemView(CurrentOrder);
                addLineItemView.Owner = MainWindow;
                addLineItemView.ShowDialog();
                GenerateInvoiceNumber(null);
            }            
        }
        public void ClearMethod(object param)
        {
            ClearAll();
        }
        private void OpenViewOldPopUp(object obj)
        {
            ViewOldPopupView viewOldPopupView = new ViewOldPopupView();
            viewOldPopupView.Owner = MainWindow;
            viewOldPopupView.ShowDialog();
        }
        public void ClearAll()
        {
            OrderDate = DateTime.Today;
            PaymentTerms = "30";
            SetFinancialYear(DateTime.Today);
            InvoiceNumber = 0;
            if (ClientsList.Count > 0)
                ClientName = ClientsList.First<string>();
            IsBillingChecked = true;
            DispatchMode = string.Empty;        }
        private void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            ClientsList = dao.GetClients();
        }

        public void SetFinancialYear(DateTime date)
        {
            // Financial year will be of the form FY20(last two digit of the year).
            // For months before April, year will be considered as previous year.
            if (date.Month < 4)
                FinancialYear = "FY" + ((date.Year - 1) % 100); // Modulo dividing by 100 to convert the year to two digit.
            else
                FinancialYear = "FY" + (date.Year % 100); // Modulo dividing by 100 to convert the year to two digit.
        }

        public void GenerateInvoiceNumber(object o)
        {
            OrderDAO orderDAO = new OrderDAO(new MySQLDBInterface());
            InvoiceNumber = orderDAO.GetNextInvNo(FinancialYear);
        }
    }
}
