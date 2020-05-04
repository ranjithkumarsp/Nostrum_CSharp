using NostrumWPFUI.Helpers;
using NostrumWPFUI.UIEntity;
using NostrumWPFUI.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class PaymentViewModel : BaseViewModel
    {
        MakePaymentView _makePaymentView;
        MakePaymentViewModel _makePaymentViewModel;
        public PaymentViewModel()
        {
            Initialize();
        }
        public ICommand InvoiceDetailsCommand { get; set; }
        public ICommand OutStandingDetailsCommand { get; set; }

        private bool _isClientInvoiceGridVisible;

        public bool IsClientInvoiceGridVisible
        {
            get { return _isClientInvoiceGridVisible; }
            set { _isClientInvoiceGridVisible = value; this.RaisePropertyChange(); }
        }


        private ObservableCollection<ClientPayment> _clientPaymentCollection;

        public ObservableCollection<ClientPayment> ClientPaymentCollection
        {
            get { return _clientPaymentCollection; }
            set { _clientPaymentCollection = value; this.RaisePropertyChange(); }
        }


        public void Initialize()
        {
            InvoiceDetailsCommand = new CustomDelegateCommand(InvoiceDetailsMethod);
            OutStandingDetailsCommand = new CustomDelegateCommand(OutStandingDetailsMethod);
            IsClientInvoiceGridVisible = false;
            LoadDummydata();
           
        }

        public void InvoiceDetailsMethod(object param)
        {
            IsClientInvoiceGridVisible = true;
        }
        public void OutStandingDetailsMethod(object param)
        {
            OutStandingPaymentPopupView outstandingPaymentPopup = new OutStandingPaymentPopupView();
            OutStandingPaymentPopupViewModel _outStandingPaymentPopupViewModel = new OutStandingPaymentPopupViewModel();
            outstandingPaymentPopup.DataContext = _outStandingPaymentPopupViewModel;
            outstandingPaymentPopup.Owner = MainWindow;
            outstandingPaymentPopup.ShowDialog();
        }

        public void LoadDummydata()
        {
            ClientPaymentCollection = new ObservableCollection<ClientPayment>();
            ClientPaymentCollection.Add(new ClientPayment { InvoiceNo = "001", Client = "raj", Date = "13/02/2020", Amount = 1500, Balance = 500 });
            ClientPaymentCollection.Add(new ClientPayment { InvoiceNo = "002", Client = "kamal", Date = "10/02/2020", Amount = 1500, Balance = 0 });
            ClientPaymentCollection.Add(new ClientPayment { InvoiceNo = "003", Client = "abi", Date = "13/01/2020", Amount = 2500, Balance = 2500 });
            ClientPaymentCollection.Add(new ClientPayment { InvoiceNo = "004", Client = "ranji", Date = "1/02/2020", Amount = 4500, Balance = 0 });
        }

        private DelegateCommand<ClientPayment> _fieldName;
        public DelegateCommand<ClientPayment> SelectedCommand =>
            _fieldName ?? (_fieldName = new DelegateCommand<ClientPayment>(ExecuteSelectedCommand));

        private void ExecuteSelectedCommand(ClientPayment _selectedClient)
        {
            ClientPayment _selectedClientfromView = _selectedClient;
            //if (_makePaymentView == null)
                _makePaymentView = new MakePaymentView();
            //if (_makePaymentViewModel == null)
                _makePaymentViewModel = new MakePaymentViewModel();
            _makePaymentView.DataContext = _makePaymentViewModel;
            _makePaymentViewModel.SelectedClient = _selectedClient;
            _makePaymentView.Owner = MainWindow;
            _makePaymentView.ShowDialog();


            //Have to check on usage of TriggerParameterPath="AddedItems"
            //prism:InvokeCommandAction
            //ClientPayment rw1 = ((object[])obj)[0] as ClientPayment;

        }
    }
}
