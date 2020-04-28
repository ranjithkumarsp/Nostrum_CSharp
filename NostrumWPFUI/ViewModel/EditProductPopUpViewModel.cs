using NostrumDB;
using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class EditProductPopUpViewModel : BaseViewModel
    {
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public EditProductPopUpViewModel()
        {
            OnPopupLoad();
        }

        public void OnPopupLoad()
        {
            OKCommand = new CustomDelegateCommand(OkMethod);
            CancelCommand = new CustomDelegateCommand(CancelMethod);
            ProductDAO dao = new ProductDAO(new MySQLDBInterface());
            ProductNameList = dao.GetProductNames();
            SelectedProduct = ProductNameList.FirstOrDefault();
            //ProductsList = dao.getProduct();
        }

        private List<string> _productNameList;

        public List<string> ProductNameList
        {
            get { return _productNameList; }
            set { _productNameList = value; this.RaisePropertyChange(); }
        }

        private List<string> _productsList;

        public List<string> ProductsList
        {
            get { return _productsList; }
            set { _productsList = value; this.RaisePropertyChange(); }
        }

        private string _selectedProduct;

        public string SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;

                this.RaisePropertyChange();
            }
        }

        private string _selectedBatchNumber;

        public string SelectedBatchNumber
        {
            get { return _selectedBatchNumber; }
            set { _selectedBatchNumber = value; this.RaisePropertyChange(); }
        }

        private List<string> _batchNumerList;

        public List<string> BatchNumerList
        {
            get { return _batchNumerList; }
            set { _batchNumerList = value; this.RaisePropertyChange(); }
        }

        private void CancelMethod(object obj)
        {
           
        }

        private void OkMethod(object obj)
        {
           
        }

        private void UpdateBatchNumerList()
        {

        }

       

    }
}
