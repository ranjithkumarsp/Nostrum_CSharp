using Entity;
using NostrumDB;
using Nostrum.Helpers;
using Nostrum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nostrum.ViewModel
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

        public void Initialize()
        {
            _dBInterface = new MySQLDBInterface();
            ShowCommand = new CustomDelegateCommand(ShowMethod);
            FromDate = DateTime.Today.AddYears(-1);
            ToDate = DateTime.Today;
            GetProductsFromDB();
        }

        public void ShowMethod(object param)
        {
            ProductDAO productDAO = new ProductDAO(_dBInterface);
            List<Product> purchasedStock = productDAO.GetProducts(SelectedProduct, FromDate, ToDate);

            StockDisplayPopupView stockdisplaypopupview = new StockDisplayPopupView(SelectedProduct, FromDate, ToDate);
            stockdisplaypopupview.Owner = MainWindow;
            stockdisplaypopupview.ShowDialog();
        }

        private void GetProductsFromDB()
        {
            ProductDAO productDAO = new ProductDAO(_dBInterface);
            Products = productDAO.GetProductNames();
        }
    }
}
