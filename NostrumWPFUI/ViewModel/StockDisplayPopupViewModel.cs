using Entity;
using NostrumDB;
using NostrumWPFUI.UIEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class StockDisplayPopupViewModel :BaseViewModel
    {
        private int _stock;
        private string txtProduct;
        private string txtFromTo;

        public int RemainingStock { get => _stock; set => _stock = value; }
        public string TxtProduct {
            get
            {
                return "Stock Register - " + txtProduct;
            }

            set => txtProduct = value;
        }
        public string TxtFromTo { get => txtFromTo; set => txtFromTo = value; }
        public ICommand SaveAsPDFCommand { get; set; }
        public StockDisplayPopupViewModel(string prod, DateTime from, DateTime to)
        {
            _dbInterface = new MySQLDBInterface();
            StockDisplayCollection = new ObservableCollection<StockDisplay>();
            TxtProduct = prod;
            TxtFromTo = from.ToString("dd-MMM-yyyy") + " to " + to.ToString("dd-MMM-yyyy");
            LoadStock(prod, from , to);
            SaveAsPDFCommand = new NostrumWPFUI.Helpers.PrintCommand();
        }

        private void LoadStock(string product, DateTime from, DateTime to)
        {
            List<Product> purchasedStock = GetPurchaseList(product, from, to);
            foreach(var prod in purchasedStock)
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
            int quantity = 0;
            StockDisplay disp = new StockDisplay();
            disp.Date = prod.Purchase_Date.ToString("dd-MMM-yyyy");
            disp.InvoiceNo = prod.Purchase_Invoice;
            disp.Manufacturer = prod.Manufacturer;
            disp.BatchNo = prod.Batch;
            disp.ManufactureDate = prod.Mfg_Date.ToString("MMM-yyyy");
            disp.ExpiryDate = prod.Exp_Date.ToString("MMM-yyyy");
            if(prod.Drug_Type == Product.DrugType.Suspension || prod.Drug_Type == Product.DrugType.Syrup)
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

            if(expired)
            {
                StockDisplay disp = new StockDisplay();
                disp.Date = prod.Purchase_Date.ToString("dd-MMM-yyyy");
                disp.InvoiceNo = "Expired";
                disp.Manufacturer = prod.Manufacturer;
                disp.BatchNo = prod.Batch;
                disp.ManufactureDate = prod.Mfg_Date.ToString("MMM-yyyy");
                disp.ExpiryDate = prod.Exp_Date.ToString("MMM-yyyy");
                disp.PurchaseQty = "-";
                disp.SaleQty = RemainingStock.ToString();
                disp.Stock = 0;
                StockDisplayCollection.Add(disp);
            }
            
        }

        private void FillSaleData(Product prod, DateTime from, DateTime to)
        {
            OrderDAO orderDAO = new OrderDAO(_dbInterface);
            List<Product> products = orderDAO.GetSaleData(prod.Name, prod.Batch, from, to);

            foreach(var product in products)
            {
                StockDisplay disp = new StockDisplay();
                disp.Date = product.Purchase_Date.ToString("dd-MMM-yyyy");
                disp.InvoiceNo = product.Purchase_Invoice;
                disp.Manufacturer = product.Manufacturer;
                disp.BatchNo = product.Batch;
                disp.ManufactureDate = prod.Mfg_Date.ToString("MMM-yyyy");
                disp.ExpiryDate = prod.Exp_Date.ToString("MMM-yyyy");
                disp.PurchaseQty = "-";
                disp.SaleQty = product.Quantity.ToString();
                disp.Stock = RemainingStock - product.Quantity;
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
