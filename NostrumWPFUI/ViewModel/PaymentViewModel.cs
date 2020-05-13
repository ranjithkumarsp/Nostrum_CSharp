using Entity;
using NostrumDB;
using Nostrum.Helpers;
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
using System.Windows.Input;

namespace Nostrum.ViewModel
{
    public class PaymentViewModel : BaseViewModel
    {
        public PaymentViewModel()
        {
            Initialize();
        }
        public ICommand InvoiceDetailsCommand { get; set; }
        public ICommand OutStandingDetailsCommand { get; set; }

        private ObservableCollection<ClientPayment> _clientPaymentList;

        public ObservableCollection<ClientPayment> ClientPaymentCollection
        {
            get { return _clientPaymentList; }
            set { _clientPaymentList = value; this.RaisePropertyChange(); }
        }

        private List<string> _pendingInvoiceList;
        public List<string> PendingInvoiceList { get => _pendingInvoiceList; set => _pendingInvoiceList = value; }

        private List<string> _clientsList;

        public List<string> ClientsList
        {
            get { return _clientsList; }
            set { _clientsList = value; this.RaisePropertyChange(); }
        }

        private string _selectedClient;

        public string SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; }
        }


        private bool _isGridVisible;

        public bool IsGridVisible
        {
            get { return _isGridVisible; }
            set { _isGridVisible = value; this.RaisePropertyChange(); }
        }

        private DateTime _fromDate;

        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        private DateTime _toDate;

        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }

        public void Initialize()
        {
            IsGridVisible = false;
            FromDate = DateTime.Today.AddYears(-1);
            ToDate = DateTime.Today;
            _dbInterface = new MySQLDBInterface();

            InvoiceDetailsCommand = new CustomDelegateCommand(LoadInvoiceDetailsMethod);
            OutStandingDetailsCommand = new CustomDelegateCommand(OutStandingDetailsMethod);
            ClientPaymentCollection = new ObservableCollection<ClientPayment>();
            PendingInvoiceList = new List<string>();

            GetClientsFromDB();
        }

        private void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(_dbInterface);
            ClientsList = dao.GetClients();
            if(ClientsList.Count > 0)
            {
                SelectedClient = ClientsList[0];
            }
        }

        public void LoadInvoiceDetailsMethod(object param)
        { 
            IsGridVisible = true;
            ClientPaymentCollection.Clear();
            PendingInvoiceList.Clear();

            List<Order> paymentList = GetOrderDetailsFromDB(SelectedClient, FromDate, ToDate);

            if(paymentList.Count > 0)
            {
                foreach (var item in paymentList)
                {
                    ClientPayment clientPayment = new ClientPayment();
                    clientPayment.OrderId = item.Order_Id;
                    clientPayment.FY = item.FY;
                    clientPayment.Client = item.Client_Name;
                    clientPayment.Date = item.Order_Date.ToString("dd-MMM-yyyy");
                    clientPayment.Amount = item.Amount;
                    clientPayment.Balance = item.Balance;
                    ClientPaymentCollection.Add(clientPayment);
                    if(clientPayment.Balance != 0)
                    {
                        PendingInvoiceList.Add(clientPayment.InvoiceNo);
                    }
                }
            }
            else
            {
                IsGridVisible = false;
                MessageBox.Show("No Sale order available for the selected client for the selected period", "Info");
            }
        }

        private List<Order> GetOrderDetailsFromDB(string selectedClient, DateTime fromDate, DateTime toDate)
        {
            List<Order> orders = new List<Order>();
            if (String.IsNullOrWhiteSpace(SelectedClient))
            {
                MessageBox.Show("Select Client", "Error");
                return orders;
            }
            else
            {
                OrderDAO orderDAO = new OrderDAO(_dbInterface);
                orders = orderDAO.GetPaymentDetails(SelectedClient, FromDate, ToDate);
            }
            return orders;
        }

        private List<Order> GetPendingOrdersFromDB(string selectedClient, DateTime fromDate, DateTime toDate)
        {
            List<Order> orders = new List<Order>();
            if (String.IsNullOrWhiteSpace(SelectedClient))
            {
                MessageBox.Show("Select Client", "Error");
                return orders;
            }
            else
            {
                OrderDAO orderDAO = new OrderDAO(_dbInterface);
                orders = orderDAO.GetPendingPayments(SelectedClient, FromDate, ToDate);
            }
            return orders;
        }

        public void OutStandingDetailsMethod(object param)
        {
            List<Order> paymentList = GetPendingOrdersFromDB(SelectedClient, FromDate, ToDate);
            if(paymentList.Count > 0)
            {
                OutStandingPaymentPopupView outstandingPaymentPopup = new OutStandingPaymentPopupView(paymentList);
                outstandingPaymentPopup.Owner = MainWindow;
                outstandingPaymentPopup.ShowDialog();
            }
            else
            {
                MessageBox.Show("No outstanding for the selected client", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }

        private DelegateCommand<ClientPayment> _fieldName;
        private IDBInterface _dbInterface;

        public DelegateCommand<ClientPayment> SelectedCommand =>
            _fieldName ?? (_fieldName = new DelegateCommand<ClientPayment>(ExecuteSelectedCommand));

        private void ExecuteSelectedCommand(ClientPayment selectedClient)
        {
            if (selectedClient != null && selectedClient.Balance == 0)
            {
                MessageBox.Show("No Outstanding for this bill.", "Info");
                return;
            }
            MakePaymentView makePaymentView = new MakePaymentView(selectedClient, PendingInvoiceList);
            makePaymentView.Owner = MainWindow;
            makePaymentView.ShowDialog();
            LoadInvoiceDetailsMethod(null);
        }
    }
}
