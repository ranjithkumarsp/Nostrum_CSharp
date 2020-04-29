using NostrumDB;
using NostrumWPFUI.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entity;
using Nostrum;
using System;

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

        private double _billValue;

        public double BillValue
        {
            get { return _billValue; }
            set { _billValue = value; this.RaisePropertyChange(); }
        }

        private double _discount;

        public double Discount
        {
            get { return _discount; }
            set { _discount = value; this.RaisePropertyChange(); }
        }

        private double _netValue;

        public double NetValue
        {
            get { return _netValue; }
            set { _netValue = value; this.RaisePropertyChange(); }
        }

        private double _cgst;

        public double CGST
        {
            get { return _cgst; }
            set { _cgst = value; this.RaisePropertyChange(); }
        }

        private double _sgst;

        public double SGST
        {
            get { return _sgst; }
            set { _sgst = value; this.RaisePropertyChange(); }
        }


        private double _total;

        public double Total
        {
            get { return _total; }
            set { _total = value; this.RaisePropertyChange(); }
        }

        private long _invoiceAmount;

        public long InvoiceAmount
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

        private ObservableCollection<BillFormData> _billFormDataSourceCollection;
        public ObservableCollection<BillFormData> BillFormDataSourceCollection
        {
            get { return _billFormDataSourceCollection; }
            set { _billFormDataSourceCollection = value; this.RaisePropertyChange(); }
        }

        #endregion

        private Order _order;
        private List<BillFormData> _orderLineItems;
        public ICommand DiscountModified { get; set; }

        public BillFormViewModel(Order order, List<BillFormData> billFormDatas)
        {
            _order = order;
            _orderLineItems = billFormDatas;
            DiscountModified = new CustomDelegateCommand(DiscountModifiedMethod);
            Initialize();
        }

        private void DiscountModifiedMethod(object obj)
        {
            CalculateInvoice();
        }

        private void CalculateInvoice()
        {
            NetValue = BillValue - Discount;
            Total = NetValue + CGST + SGST;
            InvoiceAmount = (long)Math.Round(Total);
            InvoiceAmountinWords = Nostrum.Utils.numInWords(InvoiceAmount, 0) + " Rupees only";
        }

        private void Initialize()
        {
            BillDate = _order.Order_Date.ToShortDateString();
            GenerateInvoiceNo();
            PaymentTerms = _order.Payment_Terms + " Days";
            FillClientDetails();
            BillFormDataSourceCollection = new ObservableCollection<BillFormData>(_orderLineItems);
            FillBillValues();
        }

        private void FillBillValues()
        {
            double total = 0;
            double cgst = 0;
            double sgst = 0;

            foreach(var item in _orderLineItems)
            {
                total += item.Amount;
                cgst += ((item.CGST * item.Amount) / 100);
                sgst += ((item.SGST * item.Amount) / 100);
            }

            BillValue = total;
            CGST = cgst;
            SGST = sgst;

            CalculateInvoice();
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
    }
}
