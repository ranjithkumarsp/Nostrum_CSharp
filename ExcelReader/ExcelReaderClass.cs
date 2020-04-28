using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using Application = Microsoft.Office.Interop.Excel.Application;


namespace NostrumExcelReader
{
    public class ExcelReaderClass
    {

        Application xlApp;
        // Workbook xlWorkbook;
        // _Worksheet xlSheet;
        
        string Filename = string.Empty;
        List<ExcelProduct> _ExcelProduct = new List<ExcelProduct>();
        List<ExcelProduct> DataFromExel = new List<ExcelProduct>();
        List<ExcelProduct> DataFromExel3 = new List<ExcelProduct>();
        List<List<ExcelProduct>> DataFromExel1 = new List<List<ExcelProduct>>();
        List<InvoiceData> _invoiceDataList = new List<InvoiceData>();
        List<InvoiceData> _invoiceDataList1 = new List<InvoiceData>();
        List<BatchSheetData> BatchSheetDataList = new List<BatchSheetData>();
        List<string> FilesinFOlderLst = new List<string>();

        public ExcelReaderClass()
        {
            xlApp = new Application();
        }
        private ObservableCollection<List<ExcelProduct>> _excelProductCollection = new ObservableCollection<List<ExcelProduct>>();

        public ObservableCollection<List<ExcelProduct>> ExcelProductCollection
        {
            get { return _excelProductCollection; }
            set { _excelProductCollection = value; }
        }
        public void Initialize()
        {
                      
    }

        public void ImportExcel()
        {
            #region FILEIMPORT       

          //  LOG.Info(string.Format("{0} Method : BEGIN ", MethodBase.GetCurrentMethod().Name));
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
                   // ProcessReadExcel(_files);
                }

                
            }
            catch (NullReferenceException nullEx)
            {
                MessageBox.Show(nullEx.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
              //  LOG.Error(nullEx.StackTrace, nullEx);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               // LOG.Error(ex.StackTrace, ex);
            }
          //  LOG.Info(string.Format("{0} Method : END ", MethodBase.GetCurrentMethod().Name));
            #endregion   
        }

        public void SingleFileProcess()
        {

        }
    }
}

