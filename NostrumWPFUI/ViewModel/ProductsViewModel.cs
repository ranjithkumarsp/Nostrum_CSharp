using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using NostrumDB;
using Entity;
using System.Windows;
using NostrumWPFUI.View;
using System.Collections.ObjectModel;

namespace NostrumWPFUI.ViewModel
{
    public class ProductsViewModel:BaseViewModel
    {
        #region Properties

        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; this.RaisePropertyChange(); }
        }
        private bool _tablet;

        public bool Tablet
        {
            get { return _tablet; }
            set { _tablet = value; this.RaisePropertyChange(); }
        }

        private bool _syrup;

        public bool Syrup
        {
            get { return _syrup; }
            set { _syrup = value; this.RaisePropertyChange(); }
        }

        private string _batchNo;

        public string BatchNo
        {
            get { return _batchNo; }
            set { _batchNo = value; this.RaisePropertyChange(); }
        }

        private DateTime _mfgDate;

        public DateTime MfgDate
        {
            get { return _mfgDate; }
            set { _mfgDate = value; this.RaisePropertyChange(); }
        }

        private DateTime _expDate;

        public DateTime ExpDate
        {
            get { return _expDate; }
            set { _expDate = value; this.RaisePropertyChange(); }
        }

        private int _qty;

        public int Quantity
        {
            get { return _qty; }
            set { _qty = value; this.RaisePropertyChange(); }
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

        private double _mrp;

        public double MRP
        {
            get { return _mrp; }
            set { _mrp = value; this.RaisePropertyChange(); }
        }

        private string _mfr;

        public string Manufacturer
        {
            get
            {
                return _mfr;
            }
            set
            {
                _mfr = NostrumHelpers.UppercaseFirst(value); 
                
                this.RaisePropertyChange();
            }
        }

        private DateTime _purchaseDate;

        public DateTime PurchaseDate
        {
            get { return _purchaseDate; }
            set { _purchaseDate = value; this.RaisePropertyChange(); }
        }

        private string _invNo;

        public string PurchaseInvoiceNo
        {
            get { return _invNo; }
            set { _invNo = value; this.RaisePropertyChange(); }
        }

        private ObservableCollection<string> _manfAutoCompleteCollection = new ObservableCollection<string>();

        public ObservableCollection<string> ManfAutoCompleteCollection
        {
            get { return _manfAutoCompleteCollection; }
            set { _manfAutoCompleteCollection = value;this.RaisePropertyChange(); }
        }

        #endregion

        public ProductsViewModel()
        {
            Initialize();
        }
        public ICommand SubmitCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        

        public void Initialize()
        {
            SubmitCommand = new CustomDelegateCommand(SubmitMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
            EditProductCommand = new CustomDelegateCommand(EditProductMethod);
            MfgDate = DateTime.Today;
            ExpDate = DateTime.Today;
            PurchaseDate = DateTime.Today;
            ProductDAO productDao = new ProductDAO(new MySQLDBInterface());
            List<string> manfactures = productDao.getManufacturers();
            manfactures.ForEach(item => { ManfAutoCompleteCollection.Add(item); });
           // ManfAutoCompleteCollection.Add(); 
        }

        private void EditProductMethod(object obj)
        {
            EditProductPopUpView editproductPopup = new EditProductPopUpView();
            EditProductPopUpViewModel _editProductPopUpViewModel = new EditProductPopUpViewModel();
            editproductPopup.DataContext = _editProductPopUpViewModel;
            editproductPopup.Owner = MainWindow;
            editproductPopup.ShowDialog();
            
        }

        private Entity.Product CreateProduct()
        {
            Product p = new Product();
            p.Name = ProductName;
            p.Batch = BatchNo;
            if (Tablet)
                p.Drug_Type = Product.DrugType.Tablet;
            else if (Syrup)
                p.Drug_Type = Product.DrugType.Syrup;
            p.Mfg_Date = MfgDate;
            p.Exp_Date = ExpDate;
            p.Quantity = Quantity;
            p.CGST = CGST;
            p.SGST = SGST;
            p.MRP = MRP;
            p.Manufacturer = Manufacturer;
            p.Purchase_Date = PurchaseDate;
            p.Purchase_Invoice = PurchaseInvoiceNo;
            return p;
        }
        public void SubmitMethod(object param)
        {
            ProductDAO productDao = new ProductDAO(new MySQLDBInterface());
            try
            {
                if(productDao.addProduct(CreateProduct()))
                {
                    MessageBox.Show("Product successfully Added!");
                    ClearMethod(null);
                }
                else
                {
                    MessageBox.Show("Unable to add client!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void ClearMethod(object param)
        {
            ProductName = String.Empty;
            BatchNo = String.Empty;
            Tablet = false;
            Syrup = false;
            MfgDate = DateTime.Today;
            ExpDate = DateTime.Today;
            Quantity = 0;
            CGST = 0;
            SGST = 0;
            MRP = 0;
            Manufacturer = String.Empty;
            PurchaseDate = DateTime.Today;
            PurchaseInvoiceNo = String.Empty;
        }
    }
}
