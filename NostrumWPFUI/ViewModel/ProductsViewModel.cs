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

        public string ProductName
        {
            get { return CurrentProduct.Name; }
            set
            {
                CurrentProduct.Name = NostrumHelper.UppercaseFirst(value);
                this.RaisePropertyChange();
            }
        }

        private bool _tablet;

        public bool Tablet
        {
            get { return _tablet; }
            set
            {
                _tablet = value;
                if(_tablet)
                {
                    CurrentProduct.Drug_Type = Product.DrugType.Tablet;
                    _syrup = false;
                }                
                this.RaisePropertyChange();
            }
        }

        private bool _syrup;

        public bool Syrup
        {
            get { return _syrup; }
            set
            {
                _syrup = value;
                if(_syrup)
                {
                    CurrentProduct.Drug_Type = Product.DrugType.Syrup;
                    _tablet = false;
                }                
                this.RaisePropertyChange();
            }
        }

        public string BatchNo
        {
            get { return CurrentProduct.Batch; }
            set { CurrentProduct.Batch = value; this.RaisePropertyChange(); }
        }

        public DateTime MfgDate
        {
            get { return CurrentProduct.Mfg_Date; }
            set { CurrentProduct.Mfg_Date = value; this.RaisePropertyChange(); }
        }

        public DateTime ExpDate
        {
            get { return CurrentProduct.Exp_Date; }
            set { CurrentProduct.Exp_Date = value; this.RaisePropertyChange(); }
        }

        public int Quantity
        {
            get { return CurrentProduct.Quantity; }
            set { CurrentProduct.Quantity = value; this.RaisePropertyChange(); }
        }

        public double CGST
        {
            get { return CurrentProduct.CGST; }
            set { CurrentProduct.CGST = value; this.RaisePropertyChange(); }
        }

        public double SGST
        {
            get { return CurrentProduct.SGST; }
            set { CurrentProduct.SGST = value; this.RaisePropertyChange(); }
        }
        public double MRP
        {
            get { return CurrentProduct.MRP; }
            set { CurrentProduct.MRP = value; this.RaisePropertyChange(); }
        }

        public string Manufacturer
        {
            get
            {
                return CurrentProduct.Manufacturer;
            }
            set
            {
                CurrentProduct.Manufacturer = NostrumHelper.UppercaseFirst(value); 
                this.RaisePropertyChange();
            }
        }

        public DateTime PurchaseDate
        {
            get { return CurrentProduct.Purchase_Date; }
            set { CurrentProduct.Purchase_Date = value; this.RaisePropertyChange(); }
        }

        public string PurchaseInvoiceNo
        {
            get { return CurrentProduct.Purchase_Invoice; }
            set { CurrentProduct.Purchase_Invoice = value; this.RaisePropertyChange(); }
        }

        private ObservableCollection<string> _manfAutoCompleteCollection = new ObservableCollection<string>();

        public ObservableCollection<string> ManfAutoCompleteCollection
        {
            get { return _manfAutoCompleteCollection; }
            set { _manfAutoCompleteCollection = value;this.RaisePropertyChange(); }
        }

        private bool _isNewProduct;

        public bool IsNewProduct
        {
            get { return _isNewProduct; }
            set
            {
                _isNewProduct = value;
                if (_isNewProduct)
                    SubmitButtonText = "Add Product";
                else
                    SubmitButtonText = "Update Product";
            }
        }

        private string _submitButtonText;

        public string SubmitButtonText
        {
            get { return _submitButtonText; }
            set { _submitButtonText = value; this.RaisePropertyChange(); }
        }

        private Product _currentProduct;
        private IDBInterface _dbInterface;

        public Product CurrentProduct
        {
            get { return _currentProduct; }
            set { _currentProduct = value; }
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
            CurrentProduct = new Product();
            _dbInterface = new MySQLDBInterface();
            ClearMethod(null);
        }

        private void EditProductMethod(object obj)
        {
            EditProductPopUpView editproductPopup = new EditProductPopUpView();
            editproductPopup.Owner = MainWindow;
            if(editproductPopup.ShowDialog() == true)
            {
                IsNewProduct = false;
                string product, batch;
                editproductPopup.GetSelectedValues(out product, out batch);
                FillProduct(product, batch);
            }
        }

        private void FillProduct(string product, string batch)
        {
            ProductDAO productDAO = new ProductDAO(_dbInterface);
            Product prod = productDAO.GetProduct(product, batch);
            ProductName = prod.Name;
            BatchNo = prod.Batch;
            if (prod.Drug_Type == Product.DrugType.Tablet)
                Tablet = true;
            else
                Syrup = true;
            MfgDate = prod.Mfg_Date;
            ExpDate = prod.Exp_Date;
            Quantity = prod.Quantity;
            CGST = prod.CGST;
            SGST = prod.SGST;
            MRP = prod.MRP;
            Manufacturer = prod.Manufacturer;
            PurchaseDate = prod.Purchase_Date;
            PurchaseInvoiceNo = prod.Purchase_Invoice;
        }

        private bool CanAddProduct()
        {
            if (String.IsNullOrWhiteSpace(ProductName))
            {
                MessageBox.Show("Product Name cannot be empty");
                return false;
            }
            if (String.IsNullOrWhiteSpace(BatchNo))
            {
                MessageBox.Show("Batch Number cannot be empty");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SubmitMethod(object param)
        {
            if(CanAddProduct())
            {
                ProductDAO productDAO = new ProductDAO(_dbInterface);
                if(IsNewProduct)
                {
                    AddProduct(productDAO);
                }
                else
                {
                    UpdateProduct(productDAO);
                }
            }
        }

        private void UpdateProduct(ProductDAO productDAO)
        {
            try
            {
                if (productDAO.UpdateProduct(CurrentProduct))
                {
                    MessageBox.Show("Product Updated successfully!");
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

        private void AddProduct(ProductDAO productDAO)
        {
            try
            {
                if (productDAO.AddProduct(CurrentProduct))
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
            IsNewProduct = true;
            ProductName = string.Empty;
            BatchNo = string.Empty;
            Tablet = true;
            Syrup = false;
            MfgDate = DateTime.Today;
            ExpDate = DateTime.Today;
            Quantity = 0;
            CGST = 0;
            SGST = 0;
            MRP = 0;
            Manufacturer = string.Empty;
            PurchaseDate = DateTime.Today;
            PurchaseInvoiceNo = string.Empty;
        }

        private void FillManufacturerSuggestion()
        {
            ProductDAO productDao = new ProductDAO(_dbInterface);
            List<string> manfactures = productDao.GetManufacturers();
            manfactures.ForEach(item => { ManfAutoCompleteCollection.Add(item); });
        }
    }
}
