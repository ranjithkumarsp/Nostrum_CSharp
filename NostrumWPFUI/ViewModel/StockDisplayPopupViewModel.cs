using Entity;
using NostrumDB;
using Nostrum.UIEntity;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Nostrum.Helpers;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections;

namespace Nostrum.ViewModel
{
    public class StockDisplayPopupViewModel : BaseViewModel
    {
        private int _stock;
        private string txtProduct;
        private string txtFromTo;

        public int RemainingStock { get => _stock; set => _stock = value; }
        public string TxtProduct
        {
            get
            {
                return "Stock Register - " + txtProduct;
            }

            set => txtProduct = value;
        }
        public string TxtFromTo { get => txtFromTo; set => txtFromTo = value; }

        private DelegateCommand<object> _saveasPdf; 
        public DelegateCommand<object> SaveAsPDFCommand =>
           _saveasPdf ?? (_saveasPdf = new DelegateCommand<object>(ExecutePrintAsPDF));

        private void ExecutePrintAsPDF(object obj)
        {
            if (obj != null)
            {
                NostrumHelper.ExecutePrintAsPDF(obj);
            }

        }

        public StockDisplayPopupViewModel(string prod, DateTime from, DateTime to)
        {
            _dbInterface = new MySQLDBInterface();
            StockDisplayCollection = new ObservableCollection<StockDisplay>();
            TxtProduct = prod;
            TxtFromTo = from.ToString("dd-MMM-yyyy") + " to " + to.ToString("dd-MMM-yyyy");
            LoadStock(prod, from, to);
        }

        private void LoadStock(string product, DateTime from, DateTime to)
        {
            List<Product> purchasedStock = GetPurchaseList(product, from, to);
            foreach (var prod in purchasedStock)
            {
                FillPurchaseData(prod);
                FillSaleData(prod, from, to);
                FillExpiredData(prod);
            }
        }

        private List<Product> GetPurchaseList(string prod, DateTime from, DateTime to)
        {
            ProductDAO productDAO = new ProductDAO(_dbInterface);
            return productDAO.GetPurchasedProducts(prod, from, to);
        }

        private void FillPurchaseData(Product prod)
        {
            StockDisplay disp = new StockDisplay
            {
                Date = prod.Purchase_Date,
                InvoiceNo = prod.Purchase_Invoice,
                Manufacturer = prod.Manufacturer,
                BatchNo = prod.Batch,
                ManufactureDate = prod.Mfg_Date.ToString("MMM-yyyy"),
                ExpiryDate = prod.Exp_Date.ToString("MMM-yyyy")
            };
            int quantity;
            if (prod.Drug_Type == Product.DrugType.Suspension || prod.Drug_Type == Product.DrugType.Syrup)
            {
                quantity = prod.Quantity;
            }
            else
            {
                quantity = prod.Quantity * prod.Pack1 * prod.Pack2;
            }

            disp.PurchaseQty = quantity.ToString();
            disp.SaleQty = "-";
            disp.Stock = quantity;
            RemainingStock = quantity;
            StockDisplayCollection.Add(disp);
        }

        private void FillExpiredData(Product prod)
        {
            ProductDAO productDAO = new ProductDAO(_dbInterface);
            bool expired = productDAO.IsProductExpired(prod.Name, prod.Batch);

            if (expired && RemainingStock != 0)
            {
                StockDisplay disp = new StockDisplay
                {
                    Date = prod.Exp_Date,
                    InvoiceNo = "Expired",
                    Manufacturer = prod.Manufacturer,
                    BatchNo = prod.Batch,
                    ManufactureDate = prod.Mfg_Date.ToString("MMM-yyyy"),
                    ExpiryDate = prod.Exp_Date.ToString("MMM-yyyy"),
                    PurchaseQty = "-",
                    SaleQty = RemainingStock.ToString(),
                    Stock = 0
                };
                StockDisplayCollection.Add(disp);
            }

        }

        private void FillSaleData(Product prod, DateTime from, DateTime to)
        {
            OrderDAO orderDAO = new OrderDAO(_dbInterface);
            List<Product> products = orderDAO.GetSaleData(prod.Name, prod.Batch, from, to);

            foreach (var product in products)
            {
                StockDisplay disp = new StockDisplay
                {
                    Date = product.Purchase_Date,
                    InvoiceNo = product.Purchase_Invoice,
                    Manufacturer = product.Manufacturer,
                    BatchNo = product.Batch,
                    ManufactureDate = prod.Mfg_Date.ToString("MMM-yyyy"),
                    ExpiryDate = prod.Exp_Date.ToString("MMM-yyyy"),
                    PurchaseQty = "-",
                    SaleQty = product.Quantity.ToString(),
                    Stock = RemainingStock - product.Quantity
                };
                RemainingStock = disp.Stock;
                StockDisplayCollection.Add(disp);
            }
        }

        private ObservableCollection<StockDisplay> _stockDisplayCollection;
        private IDBInterface _dbInterface;

        public ObservableCollection<StockDisplay> StockDisplayCollection
        {
            get { return _stockDisplayCollection; }
            set { _stockDisplayCollection = value; this.RaisePropertyChange(); }
        }

    }
}
