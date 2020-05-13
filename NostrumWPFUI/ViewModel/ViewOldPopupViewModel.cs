using Entity;
using NostrumDB;
using Nostrum.Helpers;
using Nostrum.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nostrum.ViewModel
{
    public class ViewOldPopupViewModel : BaseViewModel
    {
        #region Constructor

        public ViewOldPopupViewModel()
        { 
            EnterInvoiceCommand = new CustomDelegateCommand(FetchInvoiceNos);
            OpenCommand = new CustomDelegateCommand(OpenBillForm);
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

        public ICommand EnterInvoiceCommand { get; set; }
        public ICommand OpenCommand { get; private set; }


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
            //To-Do: Think of a better place to have this. If the cursor is in combobox and user shifts to and fro across different windows, this will call that many number of DB calls.
            if(!String.IsNullOrWhiteSpace(SelectedClient))
            {
                OrderDAO orderDAO = new OrderDAO(_dbInterface);
                InvoiceList = orderDAO.GetOrderIds(SelectedClient, FromDate, ToDate);
            }
        }

        private void OpenBillForm(object obj)
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
            order.IsNewOrder = false;

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

        public void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(_dbInterface);
            ClientsList = dao.GetClients();
        }

        #endregion

    }
}
