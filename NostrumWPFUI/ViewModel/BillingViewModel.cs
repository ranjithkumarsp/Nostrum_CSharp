using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
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


namespace NostrumWPFUI.ViewModel
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
            set { _isBillingChecked = value; this.RaisePropertyChange(); }
        }

        private bool _isDonationChecked;

        public bool IsDonationChecked
        {
            get { return _isDonationChecked; }
            set { _isDonationChecked = value; this.RaisePropertyChange(); }
        }

        private string _clientName;

        public string ClientName
        {
            get { return _clientName; }
            set
            {
                _clientName = value;
                this.RaisePropertyChange();
            }
        }

        private int _invNo;

        public int InvoiceNumber
        {
            get { return _invNo; }
            set
            {
                _invNo = value;
                this.RaisePropertyChange();
            }
        }

        private string _fy;

        public string FinancialYear
        {
            get { return _fy; }
            set
            {
                _fy = value;
                this.RaisePropertyChange();
            }
        }

        private DateTime _orderDate;

        public DateTime OrderDate
        {
            get { return _orderDate; }
            set
            {
                _orderDate = value;
                this.RaisePropertyChange();
            }
        }

        private int _paymentTerms;

        public int PaymentTerms
        {
            get { return _paymentTerms; }
            set
            {
                _paymentTerms = value;
                this.RaisePropertyChange();
            }
        }

        #endregion

        private Order _order;
        public BillingViewModel()
        {
            Initialize();
        }

        public ICommand BillingCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand ViewOldCommand { get; set; }
        public RelayCommand<string> RadioButtonCheckedCommand { get; set; }

        public BillingView billview;
        public void Initialize()
        {
            BillingCommand = new CustomDelegateCommand(BillingMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
            ViewOldCommand = new CustomDelegateCommand(OpenViewOldPopUp);

            _order = new Order();
            GetClientsFromDB();
            ClearAll();
            GenerateInvoiceNumber();
        }

        public void BillingMethod(object param)
        {
            _order.Client_Name = ClientName;
            _order.Order_Id = InvoiceNumber;
            _order.FY = FinancialYear;
            _order.Order_Type = IsBillingChecked ? Order.OrderType.SaleOrder : Order.OrderType.DonateOrder;
            _order.Order_Date = OrderDate;
            //_order.Dispatch_Mode //To-do: Need to understand the use of Dispatch mode.
            _order.Payment_Terms = PaymentTerms;

            AddLineItemView addLineItemView = new AddLineItemView(_order);
            addLineItemView.Owner = MainWindow;
            addLineItemView.ShowDialog();
        }
        public void ClearMethod(object param)
        {
            ClearAll();
        }
        private void OpenViewOldPopUp(object obj)
        {
            ViewOldPopupView viewOldPopupView = new ViewOldPopupView();
            viewOldPopupView.Owner = MainWindow;
            viewOldPopupView.Show();
        }
        public void ClearAll()
        {
            OrderDate = DateTime.Now;
            PaymentTerms = 30;
            SetFinancialYear(DateTime.Now);
            InvoiceNumber = 0;
            ClientName = "";
            IsBillingChecked = true;
        }
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

        public void GenerateInvoiceNumber()
        {
            OrderDAO orderDAO = new OrderDAO(new MySQLDBInterface());
            InvoiceNumber = orderDAO.GetNextInvNo(FinancialYear);
        }
    }
}
