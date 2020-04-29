using Entity;
using NostrumDB;
using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class ViewOldPopupViewModel : BaseViewModel
    {
        #region Constructor

        public ViewOldPopupViewModel()
        {            
            WindowCloseCommand = new CustomDelegateCommand(WindowClosingMethod);
            EnterInvoiceCommand = new CustomDelegateCommand(FetchInvoiceNos);
            CancelRelayCommand = new RelayCommand<IClosable>(this.CancelMethod);
            OpenRelayCommand = new RelayCommand<IClosable>(this.OpenBillForm);
            _dbInterface = new MySQLDBInterface();

            Initialize();
        }

        private void Initialize()
        {
            GetClientsFromDB();
            FromDate = DateTime.Today.AddYears(-1);
            ToDate = DateTime.Today;
        }

        #endregion

        #region Properties

        public ICommand WindowCloseCommand { get; set; }
        public ICommand EnterInvoiceCommand { get; set; }
        public DelegateCommand<IClosable> CloseWindowCommand { get; set; }
        public RelayCommand<IClosable> OpenRelayCommand { get; private set; }
        public RelayCommand<IClosable> CancelRelayCommand { get; private set; }


        private List<string> _clientsList;

        public List<string> ClientsList
        {
            get { return _clientsList; }
            set { _clientsList = value; this.RaisePropertyChange(); }
        }

        private DateTime _fromDate;

        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; this.RaisePropertyChange(); }
        }

        private DateTime _toDate;

        public DateTime ToDate
        {
            get { return _toDate; }
            set
            {
                _toDate = value;
                this.RaisePropertyChange();
            }
        }

        private List<string> _invoiceList;

        public List<string> InvoiceList
        {
            get { return _invoiceList; }
            set { _invoiceList = value; this.RaisePropertyChange(); }
        }

        private string _selectedClient;
        private IDBInterface _dbInterface;

        public string SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                this.RaisePropertyChange();
            }
        }

        private string _selectedInvoice;

        public string SelectedInvoice
        {
            get { return _selectedInvoice; }
            set { _selectedInvoice = value; }
        }


        #endregion

        #region Methods

        private void FetchInvoiceNos(object obj)
        {
            if(!String.IsNullOrWhiteSpace(SelectedClient))
            {
                OrderDAO orderDAO = new OrderDAO(_dbInterface);
                InvoiceList = orderDAO.GetOrderIds(SelectedClient, FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));
            }
        }

        private void OpenBillForm(IClosable _viewOldPopupView)
        {
            if(String.IsNullOrWhiteSpace(SelectedInvoice))
            {
                MessageBox.Show("Select a valid Invoice number", "Error");
                return;
            }

            string fy = ExtractFY();
            int orderId = ExtractOrderId();

            OrderDAO orderDAO = new OrderDAO(_dbInterface);
            Order order = orderDAO.GetOrder(orderId, fy);

            LineItemDAO lineItemDAO = new LineItemDAO(_dbInterface);
            List<LineItem> lineItems = lineItemDAO.GetLineItems(orderId, fy);

            BillFormView _billFormView = new BillFormView(order, lineItems);
            _billFormView.Owner = MainWindow;
            _billFormView.ShowDialog();
        }

        private string ExtractFY()
        {
            string fy = "";
            int index = SelectedInvoice.IndexOf('-');
            fy = SelectedInvoice.Substring(index + 1, 4);
            return fy;
        }

        private int ExtractOrderId()
        {
            int orderId = 0;
            int index = SelectedInvoice.LastIndexOf('-');
            orderId = Convert.ToInt32(SelectedInvoice.Substring(index + 1));
            return orderId;
        }

        private void CancelMethod(IClosable _viewOldPopupView)
        {
            
            if (_viewOldPopupView != null)
            {
                _viewOldPopupView.HidePopupWindow();
            }
        }

        private void WindowClosingMethod(object obj)
        {
            
        }    

        public void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(_dbInterface);
            ClientsList = dao.GetClients();
        }

        #endregion

    }
}
