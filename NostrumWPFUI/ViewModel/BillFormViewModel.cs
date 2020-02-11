using NostrumDB;
using NostrumWPFUI.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class BillFormViewModel : BaseViewModel
    {
        private ObservableCollection<BillFormData> _billFormDataSourceCollection;
        public ICommand OnLoadedCmd { get; set; }
        public BillFormViewModel()
        {
            ProductDAO productDao = new ProductDAO(new MySQLDBInterface());
            List<string> manfactures = productDao.getManufacturers();
            manfactures.ForEach(item => { ManfAutoCompleteCollection.Add(item); });
            OnLoadedCmd = new CustomDelegateCommand(this.OnLoadedMthd);
            _billFormDataSourceCollection = new ObservableCollection<BillFormData>();
            BillFormDataSourceCollection.Add(new BillFormData { SNo = "1", Product = "CYRA-D", BatchNo = "111", Packing = "1+1", Offer = "1+2", ExpDate = "feb18", Quantity = "100", Rate = "123", MRP = "100", Amount = "343" });
            loadDummyData();
        }

        private void OnLoadedMthd(object obj)
        {

        }

        #region Properties

        private string _buyerNameandAddress;

        public string BuyerNameandAddress
        {
            get { return _buyerNameandAddress; }
            set { _buyerNameandAddress = value; this.RaisePropertyChange(); }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; this.RaisePropertyChange(); }
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

        private ObservableCollection<string> _manfAutoCompleteCollection = new ObservableCollection<string>();

        public ObservableCollection<string> ManfAutoCompleteCollection
        {
            get { return _manfAutoCompleteCollection; }
            set { _manfAutoCompleteCollection = value; this.RaisePropertyChange(); }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set
            {
                myVar = value;
                this.RaisePropertyChange();
            }
        }


        public ObservableCollection<BillFormData> BillFormDataSourceCollection
        {
            get { return _billFormDataSourceCollection; }
            set { _billFormDataSourceCollection = value; this.RaisePropertyChange(); }
        }

        public void loadDummyData()
        {
            BuyerNameandAddress = "";
            Date = System.DateTime.Today.ToShortDateString();
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
