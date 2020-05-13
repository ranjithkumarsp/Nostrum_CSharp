using log4net;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Newtonsoft.Json;
using Nostrum.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = Microsoft.Office.Interop.Excel.Application;
using Path = System.IO.Path;

namespace Nostrum.View
{
    /// <summary>
    /// Interaction logic for ExcelImportView.xaml
    /// </summary>
    public partial class ExcelImportView : UserControl
    {
        public ExcelImportView()
        {
            InitializeComponent();
           // xlApp = new Application();
        }



        #region GLOBAL VARIABLES
        string Filename = string.Empty;
        private static readonly ILog LOG = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public Application xlApp;
        Workbook xlWorkbook;
        _Worksheet xlSheet;
        List<ExcelProduct> _ExcelProduct = new List<ExcelProduct>();
        List<ExcelProduct> DataFromExel = new List<ExcelProduct>();
        List<ExcelProduct> DataFromExel3 = new List<ExcelProduct>();
        List<List<ExcelProduct>> DataFromExel1 = new List<List<ExcelProduct>>();
        List<InvoiceData> _invoiceDataList = new List<InvoiceData>();
        List<InvoiceData> _invoiceDataList1 = new List<InvoiceData>();
        List<BatchSheetData> BatchSheetDataList = new List<BatchSheetData>();
        List<string> FilesinFOlderLst = new List<string>();
        private ObservableCollection<List<ExcelProduct>> _excelProductCollection = new ObservableCollection<List<ExcelProduct>>();

        public ObservableCollection<List<ExcelProduct>> ExcelProductCollection
        {
            get { return _excelProductCollection; }
            set { _excelProductCollection = value; }
        }


        MessageBoxResult result = MessageBoxResult.None;
        string _productJson;
        string _invoiceJson;
        #endregion

        #region CONSTRUCTOR
        
        #endregion

        #region IMPORT

        public void ImportExcel()
        {
            #region FILEIMPORT       

            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            Debug.WriteLine(string.Format("{0} {1}", MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().Module));
            try
            {
                //Batch Processing

                System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
                //folderSector.ShowDialog();
                System.Windows.Forms.DialogResult result1 = folderBrowserDialog1.ShowDialog();
                if (result1 == System.Windows.Forms.DialogResult.OK)
                {
                    var folderName = folderBrowserDialog1.SelectedPath;
                    Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;

                    string[] filePaths = Directory.GetFiles(folderName, "*.xls", SearchOption.AllDirectories);

                    var filePaths00 = Directory.GetFiles(folderName, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx"));
                    FilesinFOlderLst = Directory.GetFiles(folderName, "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx")).ToList();

                    // of.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                    //if (!fileOpened)
                    //{
                    //    // No file is opened, bring up openFileDialog in selected path.
                    //    openFileDialog1.InitialDirectory = folderName;
                    //    openFileDialog1.FileName = null;
                    //    //openMenuItem.PerformClick();
                    //}
                }
                // xlApp = new Application();
                foreach (var _files in FilesinFOlderLst)
                {
                    ProcessReadExcel(_files);
                }

                //OpenFileDialog openFileDialog1 = new OpenFileDialog
                //{
                //    //InitialDirectory = @"D:\STUDY\Nostrum\ReadExcelWpf\",
                //    InitialDirectory = @"C:\",
                //    Title = "Browse Excel Files",

                //    CheckFileExists = true,
                //    CheckPathExists = true,

                //    DefaultExt = ".xls",
                //    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                //    FilterIndex = 2,
                //    RestoreDirectory = true,

                //    ReadOnlyChecked = true,
                //    ShowReadOnly = true
                //};

                //if (openFileDialog1.ShowDialog().Equals(true))
                //{

                //    if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                //    {
                //        Filename = openFileDialog1.FileName;
                //    }

                //}
                //else
                //{
                //    result = MessageBox.Show("Do you like to select the file?", "File Selection Confirmation", MessageBoxButton.YesNo);
                //}
                //if (result == MessageBoxResult.Yes)
                //{
                //    openFileDialog1.ShowDialog();
                //    if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                //    {
                //        Filename = openFileDialog1.FileName;
                //    }
                //}
                //if (result == MessageBoxResult.No)
                //{
                //    MessageBox.Show("No data to Show, Select file !!");
                //    result = MessageBoxResult.None;
                //   // System.Windows.Application.Current.Shutdown();

                //}

                //if (!string.IsNullOrEmpty(Filename) && !result.Equals(MessageBoxResult.No))
                //{
                //    xlApp = new Application();
                //    xlWorkbook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
                //    // process import
                //    ProcessReadExcel(Filename); //, xlWorkbook, xlApp
                //   // Display();
                //}
            }
            catch (NullReferenceException nullEx)
            {
                MessageBox.Show(nullEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(nullEx.StackTrace, nullEx);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(ex.StackTrace, ex);
            }
            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));
            #endregion   
        }
        #endregion

        #region PROCESSEXCEL

        public void ProcessReadExcel(string filename) //, Workbook xlWorkbook, Application xlApp
        {
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            try
            {

                xlWorkbook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
                xlWorkbook = xlApp.Workbooks.Open(filename);
                xlSheet = xlWorkbook.Sheets[1];
                InvoiceData _invoicedata = new InvoiceData();
                string startCell;
                string endCell;
                Array EntireSheetData = xlSheet.Range["A1", "K100"].Cells.Value2;
                _invoicedata = GetInvoiceData(EntireSheetData);
                _invoiceDataList.Add(_invoicedata);
                GetProductRange(EntireSheetData, out startCell, out endCell);
                Array xlRange = xlSheet.Range[startCell, endCell].Cells.Value2;
                int numberOfRows = xlRange.GetLength(0);
                int numberOfCols = xlRange.GetLength(1);
                ExcelProduct exproduct = new ExcelProduct();
                DataFromExel = new List<ExcelProduct>();
                string cellvalue = string.Empty;
                string batchNo = string.Empty;

                for (int row = 1; row <= numberOfRows; row++)
                {
                    //string value = xlRange.GetValue(row, column) != null ? xlRange.GetValue(row, column).ToString() : string.Empty;
                    //checking for empty row
                    if (xlRange.GetValue(row, 1) == null && xlRange.GetValue(row, 2) == null)
                    {
                        //set column no as max to skip the empty row
                        // column = numberOfCols;
                        //do assign operation or clear product 1 here.
                        if (!IsAnyNullOrEmpty(exproduct))
                        {
                            DataFromExel.Add(exproduct);
                            LOG.Info(string.Format("Record {0} Added to DataFromExelList", DataFromExel.Count));
                        }

                        exproduct = new ExcelProduct();
                        continue;

                    }
                    else if (xlRange.GetValue(row, 2) != null && xlRange.GetValue(row, 2).ToString().Equals("H & L Medicine ") || xlRange.GetValue(row, 2).ToString().Equals("Harmless Medicines"))
                    {
                        break;
                    }
                    //if (xlRange.GetValue(row, column) != null && !string.IsNullOrWhiteSpace(value))
                    //{                       
                    // string _celldata = xlRange.GetValue(row, column).ToString();

                    if (xlRange.GetValue(row, 1) != null)
                    {
                        exproduct.S_No = xlRange.GetValue(row, 1).ToString();
                    }

                    if (string.IsNullOrWhiteSpace(exproduct.Product) && xlRange.GetValue(row, 2) != null)
                    {
                        exproduct.Product = xlRange.GetValue(row, 2).ToString();
                        // continue;
                    }
                    if (xlRange.GetValue(row, 2) != null && !string.IsNullOrWhiteSpace(exproduct.Product) && string.IsNullOrWhiteSpace(exproduct.Offer) && xlRange.GetValue(row, 1) == null)
                    {
                        exproduct.Offer = xlRange.GetValue(row, 2).ToString();
                    }
                    if (xlRange.GetValue(row, 2) != null && !string.IsNullOrWhiteSpace(exproduct.Product) && !string.IsNullOrWhiteSpace(exproduct.Offer)
                        && xlRange.GetValue(row, 1) == null && xlRange.GetValue(row - 1, 1) == null)
                    {
                        exproduct.HSNCODE = xlRange.GetValue(row, 2).ToString();
                        continue;
                    }

                    if (xlRange.GetValue(row, 4) != null)
                    {
                        exproduct.Packing = xlRange.GetValue(row, 4).ToString();
                    }
                    //Getting two set of Batch numeber
                    if (xlRange.GetValue(row, 5) != null)
                    {
                        batchNo = xlRange.GetValue(row, 5).ToString();
                    }

                    if (!string.IsNullOrWhiteSpace(batchNo) && !string.IsNullOrWhiteSpace(exproduct.Batch_No))
                    {
                        exproduct.Batch_No = string.Format("{0}{1}", exproduct.Batch_No, batchNo);
                        batchNo = null;
                    }
                    else
                    {
                        exproduct.Batch_No = batchNo;
                    }
                    if (xlRange.GetValue(row, 6) != null)
                    {
                        exproduct.EXP_Date = String.Format("{0:MM/dd/yyyy}", xlRange.GetValue(row, 6).ToString());

                    }

                    if (xlRange.GetValue(row, 7) != null)
                    {
                        exproduct.MRP = xlRange.GetValue(row, 7).ToString();
                    }

                    if (xlRange.GetValue(row, 8) != null)
                    {
                        exproduct.Qty = xlRange.GetValue(row, 8).ToString();
                    }

                    if (xlRange.GetValue(row, 9) != null)
                    {
                        exproduct.Rate = xlRange.GetValue(row, 9).ToString();
                    }

                    if (xlRange.GetValue(row, 10) != null && !string.IsNullOrWhiteSpace(xlRange.GetValue(row, 10).ToString()))
                    {
                        exproduct.Amount = xlRange.GetValue(row, 10).ToString();
                    }
                    // }
                    //}

                }
                //Add invoice data to ExcelData
                BatchSheetDataList.Add(new BatchSheetData { FileName = Path.GetFileNameWithoutExtension(filename), InvoiceDetails = _invoicedata, ProductList = DataFromExel });
                //_invoicedata = new InvoiceData();
                //DataFromExel.Clear();
                //GC.Collect();
                //GC.WaitForPendingFinalizers();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(ex.StackTrace, ex);
            }
            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));
        }

        #region ********** GET PRODUCT ROWS RANGE
        //Method to get Range of product
        public void GetProductRange(Array excelData, out string startCell, out string endCell)
        {
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            startCell = string.Empty;
            endCell = string.Empty;
            try
            {
                for (int row = 1; row <= excelData.GetLength(0); row++)
                {
                    for (int column = 1; column <= excelData.GetLength(1); column++)
                    {
                        if (excelData.GetValue(row, column) != null)
                        {
                            if (excelData.GetValue(row, column).ToString().Equals("S.No"))
                            {
                                //adding row+2 to skip headers
                                startCell = string.Format("{0}{1}", GetExcelColumnName(column), row + 2);
                            }
                            else if (excelData.GetValue(row, column).ToString().Trim().Equals("H & L Medicine"))
                            {
                                endCell = string.Format("{0}{1}", GetExcelColumnName(excelData.GetLength(1)), row);
                                //skipping all rows
                                row = excelData.GetLength(0);
                                break;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(ex.StackTrace, ex);
            }
            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));

        }
        #endregion

        #region ********** GET INVOICE DATA

        public InvoiceData GetInvoiceData(Array excelData)
        {
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));

            InvoiceData localInvoiceData = new InvoiceData();
            try
            {
                string cellData = string.Empty;
                StringBuilder celldataBuilder = new StringBuilder();


                for (int row = 1; row <= excelData.GetLength(0); row++)
                {
                    for (int column = 1; column <= excelData.GetLength(1); column++)
                    {
                        if (excelData.GetValue(row, column) != null)
                        {
                            cellData = excelData.GetValue(row, column).ToString();

                            if (cellData.Equals(NostrumConstants.GSTIN) || cellData.StartsWith(NostrumConstants.GSTIN))
                            {
                                localInvoiceData.GSTIN = cellData;
                            }
                            else if (cellData.Equals(NostrumConstants.DATE) && excelData.GetValue(row, column + 1) != null)
                            {
                                localInvoiceData.Date = String.Format("{0:MM/dd/yyyy}", excelData.GetValue(row, column + 1).ToString());

                            }
                            else if (cellData.Equals(NostrumConstants.INVOICE))
                            {
                                localInvoiceData.InvoiceNo = excelData.GetValue(row, column + 1).ToString();
                            }
                            else if (cellData.Equals(NostrumConstants.NAMEANDADDRESSOFBUYER))
                            {
                                //read next row
                                int newi = row + 1;
                                for (int i = newi; i <= excelData.GetLength(0); i++)
                                {
                                    if (excelData.GetValue(i, 1) != null)
                                    {
                                        if (excelData.GetValue(i, 1).ToString().Equals(NostrumConstants.SNo))
                                        {
                                            localInvoiceData.NameAndAddressOfBuyer = celldataBuilder.ToString();
                                            celldataBuilder.Clear();
                                            break;
                                        }
                                        celldataBuilder.Append(excelData.GetValue(i, 1).ToString());
                                        celldataBuilder.Append(",");
                                    }
                                }

                            }
                            else if (cellData.Equals(NostrumConstants.DISPATCHMODE) || cellData.StartsWith(NostrumConstants.DISPATCHMODE))
                            {
                                //(check next cell isempty, if !empty assign that value ,else substring the same cell)
                                localInvoiceData.DispatchMode = cellData;
                            }
                            else if (cellData.Equals(NostrumConstants.PAYMENTTERMS) || cellData.StartsWith(NostrumConstants.PAYMENTTERMS))
                            {
                                localInvoiceData.PaymentTerms = cellData;
                            }
                            else if (cellData.Trim().Equals(NostrumConstants.OURDRUGLICENSENO))
                            {
                                int newi = row + 1;
                                for (int i = newi; i <= excelData.GetLength(0); i++)
                                {
                                    if (excelData.GetValue(i, 1) != null) // ADDED IN EDIT
                                    {
                                        if (excelData.GetValue(i, 1).ToString().Trim().Equals(NostrumConstants.BUYERLICENSENO))
                                        {
                                            localInvoiceData.OurDrugLicense = celldataBuilder.ToString();
                                            celldataBuilder.Clear();
                                            break;
                                        }
                                        celldataBuilder.Append(excelData.GetValue(i, 1).ToString());
                                        celldataBuilder.Append(",");
                                    }
                                }

                            }
                            else if (cellData.Equals(NostrumConstants.VALUE))
                            {
                                localInvoiceData.BillValue = excelData.GetValue(row, column + 2).ToString();
                            }
                            else if (cellData.Equals(NostrumConstants.CGST))
                            {
                                localInvoiceData.CGSTPercentage = excelData.GetValue(row, column + 1).ToString();

                                localInvoiceData.CGSTValue = excelData.GetValue(row, column + 2).ToString();
                            }
                            else if (cellData.Equals(NostrumConstants.SGST))
                            {

                                localInvoiceData.SGSTPercentage = excelData.GetValue(row, column + 1).ToString();
                                localInvoiceData.SGSTValue = excelData.GetValue(row, column + 2).ToString();

                            }
                            else if (cellData.Equals(NostrumConstants.IGST))
                            {
                                localInvoiceData.IGSTPercentage = excelData.GetValue(row, column + 1).ToString();
                                localInvoiceData.IGSTValue = excelData.GetValue(row, column + 2).ToString();
                            }
                            else if (cellData.Equals(NostrumConstants.TOTAL))
                            {
                                localInvoiceData.BillTotal = excelData.GetValue(row, column + 2).ToString();
                            }
                            else if (cellData.Equals(NostrumConstants.BUYERLICENSENO))
                            {
                                int newi = row + 1;
                                for (int i = newi; i <= excelData.GetLength(0); i++)
                                {
                                    if (excelData.GetValue(i, 1) != null) // ADDED IN EDIT
                                    {
                                        if (excelData.GetValue(i, 1).ToString().Equals(NostrumConstants.INVOICEAMOUNTINWORDS))
                                        {
                                            localInvoiceData.BuyerLicenseNo = celldataBuilder.ToString();
                                            celldataBuilder.Clear();
                                            break;
                                        }
                                        celldataBuilder.Append(excelData.GetValue(i, 1).ToString());
                                        celldataBuilder.Append(",");
                                    }
                                }
                            }

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(ex.StackTrace, ex);
            }
            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));
            return localInvoiceData;
        }
        #endregion

        #endregion

        #region DISPLAY
        public void Display()
        {
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            try
            {
                string directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string fileName = System.IO.Path.Combine(directory, "_productJson.txt");

                DisplayExcelValues.ItemsSource = DataFromExel;
                DisplayInvoiceData.ItemsSource = _invoiceDataList;
                DisplayInvoiceData.AutoGenerateColumns = true;
                DisplayInvoiceData.IsReadOnly = true;
                DisplayExcelValues.AutoGenerateColumns = true;
                DisplayExcelValues.IsReadOnly = true;
                _productJson = JsonConvert.SerializeObject(DataFromExel, Formatting.Indented);
                _invoiceJson = JsonConvert.SerializeObject(_invoiceDataList, Formatting.Indented);
                File.WriteAllText(fileName, _productJson.ToString());
                LOG.Info(string.Format("Product details write successfull to: {0} with filename {1} ", directory, fileName));
                File.WriteAllText(System.IO.Path.Combine(directory, "_invoiceJson.txt"), _invoiceJson.ToString());
                LOG.Info(string.Format("Invoice details write successfull to: {0} with filename {1} ", directory, System.IO.Path.Combine(directory, "_invoiceJson.txt")));
                string finaljson = JsonConvert.SerializeObject(DataFromExel, Formatting.Indented);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.Message", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(ex.StackTrace, ex);
            }

            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));


        }
        #endregion

        public void Disp()
        {
            if (BatchSheetDataList != null && BatchSheetDataList.Count > 0)
            {
                DisplayExcelValues.ItemsSource = BatchSheetDataList.FirstOrDefault().ProductList.ToList();
                //DisplayInvoiceData.ItemsSource = BatchSheetDataList.Where(x => x.InvoiceDetails != null).Select(x => x.InvoiceDetails).ToList();
                _invoiceDataList1 = BatchSheetDataList.Select(x => (InvoiceData)x.InvoiceDetails).ToList();
                DisplayInvoiceData.ItemsSource = _invoiceDataList1;
            }
        }

        #region RE-OPEN EXCEL
        private void OpenAnotherExcel_Click(object sender, RoutedEventArgs e)
        {
            LOG.Info("OpenAnotherExcel Button Press:");
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            try
            {
                CLEAN(false);
                //ImportExcel();
                SingleExcelProcess();
                //Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(ex.StackTrace, ex);
            }
            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));
        }
        #endregion

        #region CLEANUP
        public void CLEAN(bool _canExcelAppQuit)
        {
            object misValue = System.Reflection.Missing.Value;
            ClearDataSources();
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            try
            {
                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();
                if (xlSheet != null && xlWorkbook != null && xlWorkbook != null && xlApp != null)
                {
                    Marshal.ReleaseComObject(xlSheet);
                    //close and release                
                    //xlWorkbook.Close();
                    xlWorkbook.Close(false, misValue, misValue); //added (false, misValue, misValue) to disable savedialog while closing excel document
                    Marshal.ReleaseComObject(xlWorkbook);
                    //quit and release
                    if (_canExcelAppQuit)
                        xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                }
                LOG.Info(MethodBase.GetCurrentMethod().DeclaringType + ": ENDS");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                LOG.Error(ex.StackTrace, ex);
            }
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));

        }

        public void QuitExcel()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if(xlApp != null)
            xlApp.Quit();
        }
        #endregion

        #region HELPER METHODS
        //Method to check for any null property
        public bool IsAnyNullOrEmpty(object myObject)
        {
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));
            return false;
        }

        public string GetExcelColumnName(int columnNumber)
        {

            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (dividend - modulo) / 26;
            }

            return columnName;
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
            CLEAN(true);
            LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));
            LOG.Info("        =============  Ended Logging  =============        ");
        }

        #endregion

        #region TEMP CODES

        public void DoProcessing()
        {
            TraceMessage("Something happened.");
        }

        public void TraceMessage(string message,
                [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
                [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
                [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            System.Diagnostics.Trace.WriteLine("message: " + message);
            System.Diagnostics.Trace.WriteLine("member name: " + memberName);
            System.Diagnostics.Trace.WriteLine("source file path: " + sourceFilePath);
            System.Diagnostics.Trace.WriteLine("source line number: " + sourceLineNumber);
        }

        #endregion

        #region NEW CHANGES

        private void BatchDisplayCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ExcelProductCollection.Clear();
            DataFromExel3.Clear(); DataFromExel1.Clear();
            // DisplayExcelValues.ItemsSource = BatchSheetDataList.Where(x => x.FileName.Equals("")).Select(x => x.ProductList).ToList();
            var _selectedFilename = ((Nostrum.Helpers.BatchSheetData)((System.Windows.Controls.Primitives.Selector)sender).SelectedValue).FileName;
            DataFromExel1 = BatchSheetDataList.Where(x => x.FileName.Equals(_selectedFilename)).Select(x => x.ProductList).ToList();

            DisplayExcelValues.ItemsSource = DataFromExel1.FirstOrDefault().ToList();
            DisplayInvoiceData.ItemsSource = BatchSheetDataList.Where(x => x.FileName.Equals(_selectedFilename)).Select(x => x.InvoiceDetails).ToList();


            //DisplayInvoiceData.AutoGenerateColumns = true;
            //DisplayInvoiceData.IsReadOnly = true;
            //DisplayExcelValues.AutoGenerateColumns = true;
            //DisplayExcelValues.IsReadOnly = true;
        }

        public void ClearDataSources()
        {
            DataFromExel1.Clear();
            BatchSheetDataList.Clear();
            FilePath.Text = string.Empty;
            FolderPath.Text = string.Empty;
        }

        private void FileSelector_Click(object sender, RoutedEventArgs e)
        {
            ClearDataSources();
            SingleExcelProcess();
            BatchDisplayCombo.IsEnabled = false;
            //BatchDisplayCombo.ItemsSource = null;
            Disp();
            // CLEAN(false);
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void FolderSelector_Click(object sender, RoutedEventArgs e)
        {
            ClearDataSources();
            BatchExcelProcess();
            BatchDisplayCombo.IsEnabled = true;
            BatchDisplayCombo.ItemsSource = BatchSheetDataList;
            Disp();
            //CLEAN(false);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void BatchExcelProcess()
        {
            StartExcel();
            //Batch Processing
            string folderName = string.Empty;
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            //folderSector.ShowDialog();
            System.Windows.Forms.DialogResult result1 = folderBrowserDialog1.ShowDialog();
            if (result1 == System.Windows.Forms.DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;

                string[] filePaths = Directory.GetFiles(folderName, "*.xls", SearchOption.AllDirectories);

                var filePaths00 = Directory.GetFiles(folderName, "*.*", SearchOption.AllDirectories)
        .Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx"));
                FilesinFOlderLst = Directory.GetFiles(folderName, "*.*", SearchOption.AllDirectories)
        .Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx")).ToList();

                // of.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

                //if (!fileOpened)
                //{
                //    // No file is opened, bring up openFileDialog in selected path.
                //    openFileDialog1.InitialDirectory = folderName;
                //    openFileDialog1.FileName = null;
                //    //openMenuItem.PerformClick();
                //}
            }
            // xlApp = new Application();
            foreach (var _files in FilesinFOlderLst)
            {
                ProcessReadExcel(_files);
            }
            FolderPath.Text = folderName;
        }

        public void SingleExcelProcess()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = @"D:\STUDY\Nostrum\ReadExcelWpf\",
                InitialDirectory = @"C:\",
                Title = "Browse Excel Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = ".xls",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog().Equals(true))
            {

                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    Filename = openFileDialog1.FileName;
                }

            }
            else
            {
                result = MessageBox.Show("Do you like to select the file?", "File Selection Confirmation", MessageBoxButton.YesNo);
            }
            if (result == MessageBoxResult.Yes)
            {
                openFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                {
                    Filename = openFileDialog1.FileName;
                }
            }
            if (result == MessageBoxResult.No)
            {
                MessageBox.Show("No data to Show, Select file !!");
                result = MessageBoxResult.None;
                // System.Windows.Application.Current.Shutdown();

            }

            if (!string.IsNullOrEmpty(Filename) && !result.Equals(MessageBoxResult.No))
            {
                //if(xlApp == null)
                //xlApp = new Application();
                //xlWorkbook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
                StartExcel();
                //// process import
                ProcessReadExcel(Filename); //, xlWorkbook, xlApp
                                            // Display();
            }
            FilePath.Text = Filename;
        }

        public void StartExcel()
        {
            if (xlApp == null)
                xlApp = new Application();
            xlWorkbook = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
        }

        #endregion

    }
}
