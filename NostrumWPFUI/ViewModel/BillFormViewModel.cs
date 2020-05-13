using NostrumDB;
using NostrumWPFUI.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entity;
using Nostrum;
using System;
using System.Windows;
using System.Windows.Controls;
using NostrumWPFUI.View;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using Prism.Commands;

namespace NostrumWPFUI.ViewModel
{
    public class BillFormViewModel : BaseViewModel
    {
        #region Properties

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

        public bool IsOldOrder
        {
            get { return !CurrentOrder.IsNewOrder; }
        }

        private string _addr;

        public string Address
        {
            get { return _addr; }
            set { _addr = value; this.RaisePropertyChange(); }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; this.RaisePropertyChange(); }
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

        public double Discount
        {
            get { return CurrentOrder.Discount; }
            set { CurrentOrder.Discount = value; this.RaisePropertyChange(); }
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

        public int InvoiceAmount
        {
            get { return CurrentOrder.Amount; }
            set 
            { 
                CurrentOrder.Amount = value;
                CurrentOrder.Balance = value;
                this.RaisePropertyChange(); 
            }
        }

        private string _invoiceAmountinWords;

        public string InvoiceAmountinWords
        {
            get { return _invoiceAmountinWords; }
            set { _invoiceAmountinWords = value; this.RaisePropertyChange(); }
        }

        private ObservableCollection<LineItem> _lineItemSourceCollection;
        public ObservableCollection<LineItem> LineItemSourceCollection
        {
            get { return _lineItemSourceCollection; }
            set { _lineItemSourceCollection = value; this.RaisePropertyChange(); }
        }

        //DispatchMode
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
            set
            {
                _order = value;
            }
        }
        private List<LineItem> _orderLineItems;
        private IDBInterface _dbInterface;

        public ICommand DiscountModified { get; set; }
        public ICommand SaveBillForm { get; set; }
        public ICommand DeleteBillForm { get; set; }
        public ICommand PrintBillForm { get; set; }

        public ICommand SaveAsPDF { get; set; }
        public ICommand SaveAsExcel { get; set; }
        public ICommand SaveAsImage { get; set; }
        public RelayCommand<IClosable> CloseBillFormWindowCommand { get; private set; }
        public string lblDLNo { get; private set; }

        public BillFormViewModel(Order order, List<LineItem> LineItems)
        {
            CurrentOrder = order;
            _orderLineItems = LineItems;
            _dbInterface = new MySQLDBInterface();
            DiscountModified = new CustomDelegateCommand(DiscountModifiedMethod);
            SaveBillForm = new CustomDelegateCommand(SaveForm);
            DeleteBillForm = new CustomDelegateCommand(DeleteForm);
            SaveAsPDF = new CustomDelegateCommand(SaveAsPDFMethod);
            CloseBillFormWindowCommand = new RelayCommand<IClosable>(this.CloseBillForm);
            
            Initialize();
        }

        private void SaveAsPDFMethod(object obj)
        {

            throw new NotImplementedException();
        }

        private void CloseBillForm(IClosable billFormWindow)
        {
            MessageBoxResult result = MessageBox.Show("Save changes?", "Exit",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
            if(result == MessageBoxResult.Yes)
            {
                SaveForm(null);
                billFormWindow.ClosePopupWindow();
            }
            else if(result == MessageBoxResult.No)
            {
                billFormWindow.ClosePopupWindow();
            }
        }

        private void DiscountModifiedMethod(object obj)
        {
            CalculateInvoice();
        }

        private void CalculateInvoice()
        {
            NetValue = BillValue - Discount;
            Total = Math.Round(NetValue + CGST + SGST, 2);
            InvoiceAmount = (int)Math.Round(Total);
            InvoiceAmountinWords = Nostrum.Utils.numInWords(InvoiceAmount, 0) + " Rupees only";
        }

        private void Initialize()
        {
            BillDate = CurrentOrder.Order_Date.ToShortDateString();
            GenerateInvoiceNo();
            PaymentTerms = CurrentOrder.Payment_Terms + " Days";
            FillClientDetails();
            LineItemSourceCollection = new ObservableCollection<LineItem>(_orderLineItems);
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
            // Invoice number is of the format INV-FY20-1
            if (CurrentOrder.Order_Type == Order.OrderType.SaleOrder)
                InvoiceNo = "INV-";
            else if (CurrentOrder.Order_Type == Order.OrderType.DonateOrder)
                InvoiceNo = "DNT-";
            InvoiceNo += CurrentOrder.FY + "-"+ CurrentOrder.Order_Id;
        }

        private void FillClientDetails()
        {
            ClientDAO clientDAO = new ClientDAO(_dbInterface);
            Client client = clientDAO.GetClient(CurrentOrder.Client_Name);
            ClientName = client.Name;
            Address = client.Address;
            Phone = client.Phone;
            BuyersTINNo = client.TIN_No;
            BuyersDLNo = client.DL_No;
            if(client.Type.Equals("Doctor"))
            {
                lblDLNo = "Regn No.";
            }
            else
            {
                lblDLNo = "Drug License No.";
            }
        }

        private void SaveForm(object obj)
        {
            if(CurrentOrder.IsNewOrder)
            {
                if(SaveToDataBase())
                {
                    MessageBox.Show("Successfully saved the bill", "Info");
                }
            }
            else
            {
                if(UpdateToDatabase())
                {
                    MessageBox.Show("Successfully updated the changes", "Info");
                }
            }
            
        }

        private void DeleteForm(object window)
        {
            BillFormView billFormView = window as BillFormView;
            MessageBoxResult result = MessageBox.Show("Deleting the order will permanently remove the entries from DB. Want to Continue?", "Delete",
               MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if(result == MessageBoxResult.Yes)
            {
                DeleteFromDatabase();
                billFormView.Close();
            }    
        }

        private bool UpdateToDatabase()
        {
            try
            {
                OrderDAO orderDAO = new OrderDAO(_dbInterface);
                orderDAO.UpdateOrder(CurrentOrder);

                LineItemDAO lineItemDAO = new LineItemDAO(_dbInterface);

                foreach (var item in _orderLineItems)
                {
                    item.Order_Id = CurrentOrder.Order_Id;
                    item.FY = CurrentOrder.FY;
                    lineItemDAO.UpdateLineItem(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            
            return true;
        }

        private bool SaveToDataBase()
        {
            try
            {
                OrderDAO orderDAO = new OrderDAO(_dbInterface);
                orderDAO.AddOrder(CurrentOrder);

                LineItemDAO lineItemDAO = new LineItemDAO(_dbInterface);

                foreach (var item in _orderLineItems)
                {
                    item.Order_Id = CurrentOrder.Order_Id;
                    item.FY = CurrentOrder.FY;
                    lineItemDAO.AddLineItem(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            return true;
        }

        private bool DeleteFromDatabase()
        {
            try
            {
                OrderDAO orderDAO = new OrderDAO(_dbInterface);
                orderDAO.DeleteOrder(CurrentOrder.Order_Id, CurrentOrder.FY);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            
            return true;
        }
    }
}
