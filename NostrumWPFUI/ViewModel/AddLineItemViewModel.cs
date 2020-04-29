using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            set { _pack1 = value; this.RaisePropertyChange(); }
        }

        private int _pack2;

        public int Pack2
        {
            get { return _pack2; }
            set { _pack2 = value; this.RaisePropertyChange(); }
        }

        private int _off1;

        public int Off1
        {
            get { return _off1; }
            set { _off1 = value; this.RaisePropertyChange(); }
        }

        private int _off2;

        public int Off2
        {
            get { return _off2; }
            set { _off2 = value; this.RaisePropertyChange(); }
        }

        private int _qty;

        public int Qty
        {
            get { return _qty; }
            set { _qty = value; this.RaisePropertyChange(); }
        }

        private string _avlQtyToolTipString;
        public string AvailableQtyToolTipString
        {
            get { return _avlQtyToolTipString; }
            set { _avlQtyToolTipString = value; this.RaisePropertyChange(); }
        }

        private double _rate;

        public double Rate
        {
            get { return _rate; }
            set { _rate = value; this.RaisePropertyChange(); }
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

        private string _packingUnitText;

        public string PackingUnitText
        {
            get { return _packingUnitText; }
            set { _packingUnitText = value; this.RaisePropertyChange(); }
        }


        private bool _isPackingVisible;

        public bool IsPackingVisible
        {
            get { return _isPackingVisible; }
            set { _isPackingVisible = value; this.RaisePropertyChange(); }
        }


        #endregion

        int _sNo;
        Order _order;
        List<BillFormData> _orderLineItems;
        IDBInterface _dBInterface;
        int _availableQty;

        public ICommand AddNextCommand { get; set; }
        public ICommand GenBillCommand { get; set; }
        public ICommand QtyEnterCommand { get; set; }

        public AddLineItemViewModel(Order order)
        {
            _sNo = 0;
            _availableQty = 0;
            _order = order;
            _orderLineItems = new List<BillFormData>();
            _dBInterface = new MySQLDBInterface();
            AddNextCommand = new CustomDelegateCommand(AddNextMethod);
            GenBillCommand = new CustomDelegateCommand(GenBillMethod);
            QtyEnterCommand = new CustomDelegateCommand(OnEnteringQuantity);
            
            Initialize();
        }

        private void OnEnteringQuantity(object obj)
        {
            if (!String.IsNullOrWhiteSpace(SelectedProduct) && !(String.IsNullOrWhiteSpace(SelectedBatch)))
            {
                StockDAO stockDAO = new StockDAO(_dBInterface);
                _availableQty = stockDAO.GetStockQuantity(SelectedProduct, SelectedBatch);
                AvailableQtyToolTipString = "Available Quantity: " + _availableQty;
            }
        }

        private void GenBillMethod(object obj)
        {
            if (ValidateFields())
            {
                FillFormData();
                BillFormView bfm = new BillFormView(_order, _orderLineItems);
                bfm.Owner = MainWindow;
                bfm.ShowDialog();
            }
        }

        private void AddNextMethod(object obj)
        {
            if(ValidateFields())
            {
                FillFormData();
                ClearAll();
            }
            
        }

        private bool ValidateFields()
        {
            if(String.IsNullOrWhiteSpace(SelectedProduct))
            {
                MessageBox.Show("Select a Valid Product", "Error");
                return false;
            }
            if(String.IsNullOrWhiteSpace(SelectedBatch))
            {
                MessageBox.Show("Select a Valid Product", "Error");
                return false;
            }

            int reqQty = Qty;
            if(Off1 != 0)
            {
                reqQty = reqQty / Off1;
                reqQty = reqQty * (Off1 + Off2);
            }
            if(Pack2 != 0)
            {
                reqQty = reqQty * Pack1 * Pack2;
            }

            if (reqQty <= 0)
            {
                MessageBox.Show("Invalid Quantity", "Error");
                return false;
            }
            else if (reqQty > _availableQty)
            {
                MessageBox.Show("Required quantity(" + reqQty + ") is more than available quantity(" + _availableQty + ")", "Error");
                return false;
            }
            return true;
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
            _availableQty = 0;
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
            billFormData.ExpDate = product.Exp_Date.ToString("MMM-yy");
            billFormData.Amount = Rate * Qty;
            billFormData.CGST = product.CGST;
            billFormData.SGST = product.SGST;
            
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
            if (String.IsNullOrWhiteSpace(SelectedProduct))
            {
                Batches = null;
            }
            else
            { 
                FillBatchList();
                ProductDAO productDAO = new ProductDAO(_dBInterface);
                Product.DrugType type = productDAO.GetProductType(SelectedProduct);
                if (type == Product.DrugType.Syrup)
                {
                    //To-do: hide pack2 and change the x label to ml.
                    IsPackingVisible = false;
                    PackingUnitText = "ML";
                }
                else
                {
                    //Do the reverse.
                    IsPackingVisible = true;
                    PackingUnitText = "X";
                    
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
