using NostrumDB;
using Nostrum.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nostrum.ViewModel
{
    public class EditProductPopUpViewModel : BaseViewModel
    {
        public EditProductPopUpViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            ProductDAO dao = new ProductDAO(new MySQLDBInterface());
            ProductNameList = dao.GetProductNames();
        }

        private List<string> _productNameList;

        public List<string> ProductNameList
        {
            get { return _productNameList; }
            set { _productNameList = value; this.RaisePropertyChange(); }
        }

        private string _selectedProduct;

        public string SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                GetBatchNos();
                this.RaisePropertyChange();
            }
        }

        private List<string> _batchNumberList;

        public List<string> BatchNumberList
        {
            get { return _batchNumberList; }
            set { _batchNumberList = value; this.RaisePropertyChange(); }
        }

        private void GetBatchNos()
        {
            StockDAO dao = new StockDAO(new MySQLDBInterface());
            BatchNumberList = dao.GetBatchNos(SelectedProduct);
        }
    }
}
