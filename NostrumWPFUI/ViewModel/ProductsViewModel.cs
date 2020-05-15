using Nostrum.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using NostrumDB;
using Entity;
using System.Windows;
using Nostrum.View;
using System.Collections.ObjectModel;
using Prism.Commands;
using System.ComponentModel;

namespace Nostrum.ViewModel
{
    public class ProductsViewModel:BaseViewModel
    {
        #region Properties

        public string ProductName
        {
            get { return CurrentProduct.Name; }
            set
            {
                if (value.Length > 24)
                {
                    MessageBox.Show("Product Name too big", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentProduct.Name = NostrumHelper.UppercaseFirst(value);
                this.RaisePropertyChange();
            }
        }

        public string Type
        {
            get { return CurrentProduct.StrDrugType; }
            set
            {
                CurrentProduct.StrDrugType = value;
                this.RaisePropertyChange();
            }
        }

        public string BatchNo
        {
            get { return CurrentProduct.Batch; }
            set 
            {
                if (value.Length > 24)
                {
                    MessageBox.Show("Batch No too big", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentProduct.Batch = value; 
                this.RaisePropertyChange(); 
            }
        }

        public string MfgDate
        {
            get { return CurrentProduct.Mfg_Date.ToString("MMM-yyyy"); }
            set 
            {
                DateTime result;
                if (DateTime.TryParseExact(value, "MMM-yyyy", null, System.Globalization.DateTimeStyles.None, out result))
                {
                    CurrentProduct.Mfg_Date = result;
                    this.RaisePropertyChange();
                }
                else
                {
                    MessageBox.Show("Invalid date format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }                
            }
        }

        public string ExpDate
        {
            get { return CurrentProduct.Exp_Date.ToString("MMM-yyyy"); }
            set 
            {
                DateTime result;
                if (DateTime.TryParseExact(value, "MMM-yyyy", null, System.Globalization.DateTimeStyles.None, out result))
                {
                    CurrentProduct.Exp_Date = result;
                    this.RaisePropertyChange();
                }
                else
                {
                    MessageBox.Show("Invalid date format. Try MMM-yyyy format", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public int Pack1
        {
            get { return CurrentProduct.Pack1; }
            set
            {
                if (value < 1)
                {
                    MessageBox.Show("Invalid Packing", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentProduct.Pack1 = value;
                this.RaisePropertyChange();
            }
        }
        public int Pack2
        {
            get { return CurrentProduct.Pack2; }
            set
            {
                if (value < 1)
                {
                    MessageBox.Show("Invalid Packing", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentProduct.Pack2 = value;
                this.RaisePropertyChange();
            }
        }
        public int Quantity
        {
            get { return CurrentProduct.Quantity; }
            set { 
                if(value < 1)
                {
                    MessageBox.Show("Invalid Quantity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentProduct.Quantity = value; 
                this.RaisePropertyChange(); 
            }
        }

        public double CGST
        {
            get { return CurrentProduct.CGST; }
            set 
            {
                if (value < 0)
                {
                    MessageBox.Show("Invalid CGST", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentProduct.CGST = value; 
                this.RaisePropertyChange(); 
            }
        }

        public double SGST
        {
            get { return CurrentProduct.SGST; }
            set 
            {
                if (value < 0)
                {
                    MessageBox.Show("Invalid SGST", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CurrentProduct.SGST = value; 
                this.RaisePropertyChange(); 
            }
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
                if (value.Length > 44)
                {
                    MessageBox.Show("Manufacturer too big", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
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

        private ObservableCollection<string> _productNameCollection = new ObservableCollection<string>();
        public ObservableCollection<string> ProductNameCollection
        {
            get { return _productNameCollection; }
            set { _productNameCollection = value; this.RaisePropertyChange(); }
        }
        
        private bool _isNewProduct;

        public bool IsNewProduct
        {
            get { return _isNewProduct; }
            set
            {
                _isNewProduct = value;
                this.RaisePropertyChange();
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

        public ObservableCollection<string> DrugTypeList { get; private set; }

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
            DrugTypeList = new ObservableCollection<string>(Product.ValidProductTypes);
            ClearMethod(null);
            FillAutoCompleteSuggestions();
        }

        private void FillAutoCompleteSuggestions()
        {
            FillManufacturerSuggestion();
            FillProductNameCollection();
        }

        private void EditProductMethod(object obj)
        {
            EditProductPopUpView editproductPopup = new EditProductPopUpView();
            editproductPopup.Owner = MainWindow;
            if(editproductPopup.ShowDialog() == true)
            {
                if(editproductPopup.GetActionTaken() == View.EditPopUpView.ActionTaken.Edit)
                {
                    IsNewProduct = false;
                    string product, batch;
                    editproductPopup.GetSelectedValues(out product, out batch);
                    FillProduct(product, batch);
                }
                else if(editproductPopup.GetActionTaken() == View.EditPopUpView.ActionTaken.Delete)
                {
                    MessageBoxResult result = MessageBox.Show("Deleting the product will remove the entries from existing orders. Want to Continue?", "Delete",
               MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if(result == MessageBoxResult.Yes)
                    {
                        string product, batch;
                        editproductPopup.GetSelectedValues(out product, out batch);
                        DeleteProduct(product, batch);
                    }                    
                }
            }
        }

        private void FillProduct(string product, string batch)
        {
            ProductDAO productDAO = new ProductDAO(_dbInterface);
            Product prod = productDAO.GetProduct(product, batch);
            ProductName = prod.Name;
            BatchNo = prod.Batch;
            Type = prod.StrDrugType;
            MfgDate = prod.Mfg_Date.ToString("MMM-yyyy");
            ExpDate = prod.Exp_Date.ToString("MMM-yyyy");
            Pack1 = prod.Pack1;
            Pack2 = prod.Pack2;
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
                    MessageBox.Show("Unable to add Product!");
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
                    FillAutoCompleteSuggestions();
                }
                else
                {
                    MessageBox.Show("Unable to add Product!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DeleteProduct(string product, string batch)
        {
            try
            {
                ProductDAO productDAO = new ProductDAO(_dbInterface);
                if (productDAO.DeleteProduct(product, batch))
                {
                    MessageBox.Show("Product successfully Deleted!");
                    ClearMethod(null);
                }
                else
                {
                    MessageBox.Show("Unable to Delete Product!");
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
            Type = DrugTypeList.First<string>();
            MfgDate = DateTime.Today.ToString("MMM-yyyy");
            ExpDate = DateTime.Today.ToString("MMM-yyyy");
            Pack1 = 1;
            Pack2 = 1;
            Quantity = 1;
            CGST = 6;
            SGST = 6;
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
        private void FillProductNameCollection()
        {
            ProductDAO productDao = new ProductDAO(_dbInterface);
            List<string> manfactures = productDao.GetProductNames();
            manfactures.ForEach(item => { ProductNameCollection.Add(item); });
        }
    }
}
