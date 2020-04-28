using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entity;
using NostrumDB;
using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;

namespace NostrumWPFUI.ViewModel
{
    public class AddLineItemViewModel : BaseViewModel
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
                _selectedProduct = value;
                OnProductSelect();
                this.RaisePropertyChange();
            }
        }
        private int _pack1;

        public int Pack1
        {
            get { return _pack1; }
            set { _pack1 = value; }
        }

        private int _pack2;

        public int Pack2
        {
            get { return _pack2; }
            set { _pack2 = value; }
        }

        private int _off1;

        public int Off1
        {
            get { return _off1; }
            set { _off1 = value; }
        }

        private int _off2;

        public int Off2
        {
            get { return _off2; }
            set { _off2 = value; }
        }

        private int _qty;

        public int Qty
        {
            get { return _qty; }
            set { _qty = value; }
        }

        private double _rate;

        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        private List<string> _batchList;

        public List<string> Batches
        {
            get { return _batchList; }
            set { _batchList = value; this.RaisePropertyChange(); }
        }

        private string _selectedBatch;

        public string SelectedBatch
        {
            get { return _selectedBatch; }
            set
            {
                _selectedBatch = value;
                this.RaisePropertyChange();
            }
        }

        #endregion

        int _sNo;
        Order _order;
        List<BillFormData> _orderLineItems;
        IDBInterface _dBInterface;
        public ICommand AddNextCommand { get; set; }
        public ICommand GenBillCommand { get; set; }

        public AddLineItemViewModel(Order order)
        {
            _sNo = 0;
            _order = order;
            _orderLineItems = new List<BillFormData>();
            _dBInterface = new MySQLDBInterface();
            AddNextCommand = new CustomDelegateCommand(AddNextMethod);
            GenBillCommand = new CustomDelegateCommand(GenBillMethod);
            
            Initialize();
        }

        private void GenBillMethod(object obj)
        {
            FillFormData();
            BillFormView bfm = new BillFormView(_order, _orderLineItems);
            bfm.Owner = MainWindow;
            bfm.ShowDialog();
        }

        private void AddNextMethod(object obj)
        {
            FillFormData();
            ClearAll();
        }

        private void ClearAll()
        {
            SelectedBatch = "";
            SelectedProduct = ""; 
            Batches = null;
            Pack1 = 0;
            Pack2 = 0;
            Off1 = 0;
            Off2 = 0;
            Qty = 0;
            Rate = 0;
        }

        private void FillFormData()
        {
            ProductDAO productDao = new ProductDAO(_dBInterface);
            Product product = productDao.GetProduct(SelectedProduct, SelectedBatch);

            BillFormData billFormData = new BillFormData();
            billFormData.SNo = ++_sNo;
            billFormData.Product = SelectedProduct;
            billFormData.BatchNo = SelectedBatch;
            if (product.Drug_Type == Product.DrugType.Syrup)
                billFormData.Packing = Pack1 + " ml";
            else if (product.Drug_Type == Product.DrugType.Tablet)
                billFormData.Packing = Pack1 + " x " + Pack2;
            if (Off1 == 0 || Off2 == 0)
                billFormData.Offer = "Nett Rate!";
            else
                billFormData.Offer = Off1 + " + " + Off2;
            billFormData.Quantity = Qty;
            billFormData.Rate = Rate;
            billFormData.MRP = product.MRP;
            billFormData.ExpDate = product.Exp_Date.ToString();
            billFormData.Amount = Rate * Qty;
            
            _orderLineItems.Add(billFormData);
        }

        private void Initialize()
        {
            GetProductsFromDB();
        }

        public void GetProductDetails()
        {
            ProductDAO productDAO = new ProductDAO(_dBInterface);
            productDAO.GetProduct(SelectedProduct, SelectedBatch);
        }

        private void OnProductSelect()
        {
            if(!String.IsNullOrWhiteSpace(SelectedProduct))
            {
                FillBatchList();
                ProductDAO productDAO = new ProductDAO(_dBInterface);
                Product.DrugType type = productDAO.GetProductType(SelectedProduct);
                if (type == Product.DrugType.Syrup)
                {
                    //To-do: hide pack2 and change the x label to ml.
                }
                else
                {
                    //Do the reverse.
                }
            }
        }

        private void FillBatchList()
        {
            StockDAO stockDAO = new StockDAO(_dBInterface);
            Batches = stockDAO.GetBatchNos(SelectedProduct);
        }

        private void GetProductsFromDB()
        {
            ProductDAO productDAO = new ProductDAO(_dBInterface);
            Products = productDAO.GetProductNames();
        }
    }
}
