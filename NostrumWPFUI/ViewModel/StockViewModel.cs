using Entity;
using NostrumDB;
using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class StockViewModel : BaseViewModel
    {
        #region Properties
        private List<string> _productList;

        public List<string> Products
        {
            get { return _productList; }
            set { _productList = value; this.RaisePropertyChange(); }
        }

        private string _selectedProduct;
        public string SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct= value;
                this.RaisePropertyChange();
            }
        }

        private DateTime _fromDate;
        public DateTime FromDate
        {
            get { return _fromDate; }
            set
            {
                _fromDate = value;
                this.RaisePropertyChange();
            }
        }

        private DateTime _todate;
        private IDBInterface _dBInterface;

        public DateTime ToDate
        {
            get { return _todate; }
            set
            {
                _todate = value;
                this.RaisePropertyChange();
            }
        }

        #endregion


        #region CONSTRUCTOR
        public StockViewModel()
        {
            Initialize();
        }        
        #endregion
        public ICommand ShowCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public void Initialize()
        {
            _dBInterface = new MySQLDBInterface();
            ShowCommand = new CustomDelegateCommand(ShowMethod);
            RefreshCommand = new CustomDelegateCommand(Refresh);
            FromDate = DateTime.Today.AddYears(-1);
            ToDate = DateTime.Today;
            GetProductsFromDB();
        }

        private void Refresh(object obj)
        {
            GetProductsFromDB();
        }

        public void ShowMethod(object param)
        {
            StockDisplayPopupView stockdisplaypopupview = new StockDisplayPopupView(SelectedProduct, FromDate, ToDate);
            stockdisplaypopupview.Owner = MainWindow;
            stockdisplaypopupview.ShowDialog();
        }

        private void GetProductsFromDB()
        {
            ProductDAO productDAO = new ProductDAO(_dBInterface);
            Products = productDAO.GetProductNames();
            if(Products.Count > 0)
            {
                SelectedProduct = Products.First<string>();
            }    
        }
    }
}
