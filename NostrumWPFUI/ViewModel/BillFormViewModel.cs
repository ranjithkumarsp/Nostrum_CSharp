using NostrumDB;
using NostrumWPFUI.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entity;
using Nostrum;

namespace NostrumWPFUI.ViewModel
{
    public class BillFormViewModel : BaseViewModel
    {
        #region Properties

        private string _buyerNameandAddress;

        public string BuyerNameandAddress
        {
            get { return _buyerNameandAddress; }
            set { _buyerNameandAddress = value; this.RaisePropertyChange(); }
        }

        private string _billDate;

        public string BillDate
        {
            get { return _billDate; }
            set { _billDate = value; this.RaisePropertyChange(); }
        }

        private string _invoiceNo;

        public string InvoiceNo
        {
            get { return _invoiceNo; }
            set { _invoiceNo = value; this.RaisePropertyChange(); }
        }

        private string _paymentTerms;

        public string PaymentTerms
        {
            get { return _paymentTerms; }
            set { _paymentTerms = value; this.RaisePropertyChange(); }
        }

        private string _buyersTINNo;

        public string BuyersTINNo
        {
            get { return _buyersTINNo; }
            set { _buyersTINNo = value; this.RaisePropertyChange(); }
        }

        private string _buyersDLNo;

        public string BuyersDLNo
        {
            get { return _buyersDLNo; }
            set { _buyersDLNo = value; this.RaisePropertyChange(); }
        }

        private string _billValue;

        public string BillValue
        {
            get { return _billValue; }
            set { _billValue = value; this.RaisePropertyChange(); }
        }

        private string _discount;

        public string Discount
        {
            get { return _discount; }
            set { _discount = value; this.RaisePropertyChange(); }
        }

        private string _netValue;

        public string NetValue
        {
            get { return _netValue; }
            set { _netValue = value; this.RaisePropertyChange(); }
        }

        private string _cgst;

        public string CGST
        {
            get { return _cgst; }
            set { _cgst = value; this.RaisePropertyChange(); }
        }

        private string _sgst;

        public string SGST
        {
            get { return _sgst; }
            set { _sgst = value; this.RaisePropertyChange(); }
        }


        private string _total;

        public string Total
        {
            get { return _total; }
            set { _total = value; this.RaisePropertyChange(); }
        }

        private string _invoiceAmount;

        public string InvoiceAmount
        {
            get { return _invoiceAmount; }
            set { _invoiceAmount = value; this.RaisePropertyChange(); }
        }

        private string _invoiceAmountinWords;

        public string InvoiceAmountinWords
        {
            get { return _invoiceAmountinWords; }
            set { _invoiceAmountinWords = value; this.RaisePropertyChange(); }
        }
        
        #endregion

        private Order _order;
        private LineItem _orderLineItem;

        private ObservableCollection<BillFormData> _billFormDataSourceCollection;
        public ICommand OnLoadedCmd { get; set; }
        public BillFormViewModel(Order order)
        {
            _order = order;
            _orderLineItem = new LineItem();
            Initialize();
        }

        private void Initialize()
        {
            BillDate = _order.Order_Date.ToShortDateString();
            GenerateInvoiceNo();
            PaymentTerms = _order.Payment_Terms + " Days";
            FillClientDetails();
            //ProductDAO productDao = new ProductDAO(new MySQLDBInterface());
            //List<string> manfactures = productDao.getManufacturers();
            //manfactures.ForEach(item => { ManfAutoCompleteCollection.Add(item); });
            OnLoadedCmd = new CustomDelegateCommand(this.OnLoadedMthd);
            BillFormDataSourceCollection = new ObservableCollection<BillFormData>();
            //BillFormDataSourceCollection.Add(new BillFormData { SNo = "", Product = "", BatchNo = "", Packing = "", Offer = "", ExpDate = "", Quantity = "", Rate = "", MRP = "", Amount = "" });
            //loadDummyData(_order);
        }
        private void OnLoadedMthd(object obj)
        {
        }
        
        private void GenerateInvoiceNo()
        {
            // Invoice number is of the format INV-001-FY20
            if (_order.Order_Type == Order.OrderType.SaleOrder)
                InvoiceNo = "INV-";
            else if (_order.Order_Type == Order.OrderType.DonateOrder)
                InvoiceNo = "DNT-";
            InvoiceNo += Nostrum.Utils.numToNdigitString(_order.Order_Id,3) + "-" + _order.FY;
        }

        private void FillClientDetails()
        {
            ClientDAO clientDAO = new ClientDAO(new MySQLDBInterface());
            Client client = clientDAO.GetClient(_order.Client_Name);
            BuyersTINNo = client.TIN_No;
            BuyersDLNo = client.DL_No;
        }

        private ObservableCollection<string> _manfAutoCompleteCollection = new ObservableCollection<string>();

        public ObservableCollection<string> ManfAutoCompleteCollection
        {
            get { return _manfAutoCompleteCollection; }
            set { _manfAutoCompleteCollection = value; this.RaisePropertyChange(); }
        }

        public ObservableCollection<BillFormData> BillFormDataSourceCollection
        {
            get { return _billFormDataSourceCollection; }
            set { _billFormDataSourceCollection = value; this.RaisePropertyChange(); }
        }

        public void loadDummyData(Order order)
        {
            BuyerNameandAddress = "";
            BillDate = System.DateTime.Today.ToShortDateString();
            InvoiceNo = "12345678";
            PaymentTerms = "30 Days";

            BuyersTINNo = "BuyersTin 1234";
            BuyersDLNo = "BuyersDL 1234";
            BillValue = "BillValue";
            Discount = "Discount";
            NetValue = "NetValue";
            CGST = "CGST";
            SGST = "SGST";
            Total = "Total";
            InvoiceAmount = "InvoiceAmount";

            InvoiceAmountinWords = "OneHundred and Fifty Five OneHundred and Fifty Five,,Five OneHundred and Fifty Five ";

        }


    }
}
