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

        public string SelectedProduct
        {
            get { return CurrentLineItem.Product_Name; }
            set
            {
                CurrentLineItem.Product_Name = value;
                OnProductSelect();
                this.RaisePropertyChange();
            }
        }

        private bool _saleOrder;

        public bool SaleOrder
        {
            get { return _saleOrder; }
        }

        private string _avlQtyToolTipString;
        public string AvailableQtyToolTipString
        {
            get { return _avlQtyToolTipString; }
            set { _avlQtyToolTipString = value; this.RaisePropertyChange(); }
        }

        private List<string> _batchList;

        public List<string> Batches
        {
            get { return _batchList; }
            set { _batchList = value; this.RaisePropertyChange(); }
        }

        private string _packingUnitText;

        public string PackingUnitText
        {
            get { return _packingUnitText; }
            set { _packingUnitText = value; this.RaisePropertyChange(); }
        }


        private bool _isProductSolid;

        public bool IsProductSolid
        {
            get { return _isProductSolid; }
            set { _isProductSolid = value; this.RaisePropertyChange(); }
        }

        private LineItem _lineItem;

        public LineItem CurrentLineItem
        {
            get { return _lineItem; }
            set { _lineItem = value; this.RaisePropertyChange(); }
        }

        #endregion

        Order _order;
        List<LineItem> _orderLineItems;
        IDBInterface _dBInterface;
        int _availableQty;

        public ICommand AddNextCommand { get; set; }
        public ICommand GenBillCommand { get; set; }
        public ICommand QtyEnterCommand { get; set; }

        public AddLineItemViewModel(Order order)
        {
            _availableQty = 0;
            _order = order;
            _saleOrder = (order.Order_Type == Order.OrderType.SaleOrder);
            _lineItem = new LineItem();
            _orderLineItems = new List<LineItem>();
            _dBInterface = new MySQLDBInterface();
            AddNextCommand = new CustomDelegateCommand(AddNextMethod);
            GenBillCommand = new CustomDelegateCommand(GenBillMethod);
            QtyEnterCommand = new CustomDelegateCommand(OnEnteringQuantity);
            
            Initialize();
        }

        private void OnEnteringQuantity(object obj)
        {
            if (!String.IsNullOrWhiteSpace(SelectedProduct) && !(String.IsNullOrWhiteSpace(CurrentLineItem.Batch)))
            {
                StockDAO stockDAO = new StockDAO(_dBInterface);
                int tmpQty = 0;
                _availableQty = stockDAO.GetStockQuantity(SelectedProduct, CurrentLineItem.Batch);
                tmpQty = _availableQty;
                if (IsProductSolid)
                {
                    if(CurrentLineItem.Pack1 !=0 && CurrentLineItem.Pack2 != 0)
                        tmpQty = tmpQty / (CurrentLineItem.Pack1 * CurrentLineItem.Pack2);
                }
                if ((CurrentLineItem.Offer1!=0) && ((CurrentLineItem.Offer1 + CurrentLineItem.Offer2) != 0))
                {
                    tmpQty = tmpQty / CurrentLineItem.Offer1;
                    tmpQty = tmpQty / (CurrentLineItem.Offer1 + CurrentLineItem.Offer2);
                }
                AvailableQtyToolTipString = "Available Quantity: " + tmpQty;
            }
        }

        private void GenBillMethod(object obj)
        {
            AddLineItemView _addlineItemView = obj as AddLineItemView;
            
            if (!String.IsNullOrWhiteSpace(CurrentLineItem.Batch))
            {
                if(ValidateFields())
                {
                    FillFormData();
                    ClearAll();
                }
                else { return; }
            }
            if (_orderLineItems.Count > 0)
            {
                _order.IsNewOrder = true;
                _addlineItemView.Close();
                BillFormView bfm = new BillFormView(_order, _orderLineItems);
                bfm.Owner = MainWindow;
                bfm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Add at least one product to generate Bill", "Error");
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
            if(String.IsNullOrWhiteSpace(SelectedProduct) || String.IsNullOrWhiteSpace(CurrentLineItem.Batch))
            {
                MessageBox.Show("Select a Valid Product & Batch", "Error");
                return false;
            }

            int reqQty = CurrentLineItem.Quantity;
            if(CurrentLineItem.Offer1 != 0)
            {
                reqQty = reqQty / CurrentLineItem.Offer1;
                reqQty = reqQty * (CurrentLineItem.Offer1 + CurrentLineItem.Offer2);
            }
            if(CurrentLineItem.Pack2 != 0)
            {
                reqQty = reqQty * CurrentLineItem.Pack1 * CurrentLineItem.Pack2;
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
            CurrentLineItem = new LineItem();
            CurrentLineItem.ClearAll();
            Batches = null;
            _availableQty = 0;
        }

        private void FillFormData()
        {
            CurrentLineItem.S_No = _orderLineItems.Count + 1;
            CurrentLineItem.FillRemainingFields();
            _orderLineItems.Add(CurrentLineItem);
        }

        private void Initialize()
        {
            GetProductsFromDB();
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
                if (type == Product.DrugType.Syrup || type == Product.DrugType.Suspension)
                {
                    IsProductSolid = false;
                    PackingUnitText = "ML";
                }
                else
                {
                    IsProductSolid = true;
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
