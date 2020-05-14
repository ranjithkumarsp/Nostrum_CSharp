using NostrumDB;
using Nostrum.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Entity;
using Nostrum;
using System;
using System.Windows;
using System.Windows.Controls;
using Nostrum.View;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using Prism.Commands;

namespace Nostrum.ViewModel
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

        private DelegateCommand<object> _fieldName;
        public DelegateCommand<object> PrintBillForm =>
           _fieldName ?? (_fieldName = new DelegateCommand<object>(ExecutePrintAsPDF));           

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

        #region PrintVisualRegion
        //private void _printBillForm(object obj)
        //{
        //    //BillFormView _billFormView = obj as BillFormView; // TODO : Convert full screen to pdf with out menu and scroll bars.
        //    Grid _gridtoprint = obj as Grid; 

        //    PrintDialog prnt = new PrintDialog();
        //    if (prnt != null)
        //    {
        //        Size pageSize = new Size(prnt.PrintableAreaWidth, prnt.PrintableAreaHeight);
        //        _gridtoprint.Measure(pageSize);
        //        _gridtoprint.Arrange(new Rect(25, 25, pageSize.Width, pageSize.Height));

        //        if (prnt.ShowDialog() == true)
        //        {
        //            prnt.PrintVisual(_gridtoprint, "Nostrum Billing");
        //        }
        //    }

        //}
        #endregion

        #region PrintAsPDF

        public void ExecutePrintAsPDF(object parameter)
        {
            FrameworkElement objectToPrint = parameter as FrameworkElement;
            BillFormView _billFormView = VisualHelpers.GetVisualParent<Window>(objectToPrint) as BillFormView;

            PrintDialog printDialog = new PrintDialog();
            if ((bool)printDialog.ShowDialog().GetValueOrDefault())
            {
                if (parameter is FrameworkElement)
                {
                    //FrameworkElement objectToPrint = parameter as FrameworkElement;
                    //PrintDialog printDialog = new PrintDialog();
                    //if ((bool)printDialog.ShowDialog().GetValueOrDefault())
                    //{
                    Mouse.OverrideCursor = Cursors.Wait;
                    System.Printing.PrintCapabilities capabilities =
                     printDialog.PrintQueue.GetPrintCapabilities(printDialog.PrintTicket);
                    double dpiScale = 300.0 / 96.0;
                    FixedDocument document = new FixedDocument();
                    try
                    {
                        // Change the layout of the UI Control to match the width of the printer page
                        objectToPrint.Width = capabilities.PageImageableArea.ExtentWidth;
                        objectToPrint.UpdateLayout();
                        objectToPrint.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                        Size size = new Size(capabilities.PageImageableArea.ExtentWidth,
                                             objectToPrint.DesiredSize.Height);
                        objectToPrint.Measure(size);
                        size = new Size(capabilities.PageImageableArea.ExtentWidth,
                                        objectToPrint.DesiredSize.Height);
                        objectToPrint.Measure(size);
                        objectToPrint.Arrange(new Rect(size));

                        // Convert the UI control into a bitmap at 300 dpi
                        double dpiX = 300;
                        double dpiY = 300;
                        RenderTargetBitmap bmp = new RenderTargetBitmap(Convert.ToInt32(
                          capabilities.PageImageableArea.ExtentWidth * dpiScale),
                          Convert.ToInt32(objectToPrint.ActualHeight * dpiScale),
                          dpiX, dpiY, PixelFormats.Pbgra32);
                        bmp.Render(objectToPrint);

                        // Convert the RenderTargetBitmap into a bitmap we can more readily use
                        PngBitmapEncoder png = new PngBitmapEncoder();
                        png.Frames.Add(BitmapFrame.Create(bmp));
                        System.Drawing.Bitmap bmp2;
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            png.Save(memoryStream);
                            bmp2 = new System.Drawing.Bitmap(memoryStream);
                        }
                        document.DocumentPaginator.PageSize =
                          new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);

                        // break the bitmap down into pages
                        int pageBreak = 0;
                        int previousPageBreak = 0;
                        int pageHeight =
                            Convert.ToInt32(capabilities.PageImageableArea.ExtentHeight * dpiScale);
                        while (pageBreak < bmp2.Height - pageHeight)
                        {
                            pageBreak += pageHeight;  // Where we thing the end of the page should be

                            // Keep moving up a row until we find a good place to break the page
                            while (!IsRowGoodBreakingPoint(bmp2, pageBreak))
                                pageBreak--;

                            PageContent pageContent = generatePageContent(bmp2, previousPageBreak,
                              pageBreak, document.DocumentPaginator.PageSize.Width,
                              document.DocumentPaginator.PageSize.Height, capabilities);
                            document.Pages.Add(pageContent);
                            previousPageBreak = pageBreak;
                        }

                        // Last Page
                        PageContent lastPageContent = generatePageContent(bmp2, previousPageBreak,
                          bmp2.Height, document.DocumentPaginator.PageSize.Width,
                          document.DocumentPaginator.PageSize.Height, capabilities);
                        document.Pages.Add(lastPageContent);
                    }
                    finally
                    {
                        // Scale UI control back to the original so we don't effect what is on the screen 
                        objectToPrint.Width = double.NaN;
                        objectToPrint.UpdateLayout();
                        objectToPrint.LayoutTransform = new ScaleTransform(1, 1);
                        Size size = new Size(capabilities.PageImageableArea.ExtentWidth,
                                             capabilities.PageImageableArea.ExtentHeight);
                        objectToPrint.Measure(size);
                        objectToPrint.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth,
                                              capabilities.PageImageableArea.OriginHeight), size));
                        Mouse.OverrideCursor = null;
                    }
                    printDialog.PrintDocument(document.DocumentPaginator, "Print Document Name"); 
                    // }
                }
            }
            else
            {
                //FrameworkElement objectToPrint = parameter as FrameworkElement;
                //BillFormView _billFormView = VisualHelpers.GetVisualParent<Window>(objectToPrint) as BillFormView;
                //_billFormView.SetRowDefinitions(true);
            }
            //Show Discount Column for success / Failure scenarios.
            _billFormView.SetRowDefinitions(true);

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
