using NostrumWPFUI.UIEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumWPFUI.ViewModel
{
    public class StockDisplayPopupViewModel :BaseViewModel
    {
        public StockDisplayPopupViewModel()
        {
            LoadDummydata();
        }

        private ObservableCollection<StockDisplay> _stockDisplayCollection;

        public ObservableCollection<StockDisplay> StockDisplayCollection
        {
            get { return _stockDisplayCollection; }
            set { _stockDisplayCollection = value; this.RaisePropertyChange(); }
        }

        public void LoadDummydata()
        {
            StockDisplayCollection = new ObservableCollection<StockDisplay>();
            StockDisplayCollection.Add(new StockDisplay {  InvoiceNo = "001", BatchNo="111", ExpiryDate= "13/02/2022", ManufactureDate= "13/02/2022", Manufacturer="nostrum", PurchaseQty="11", Remarks="dummy",

                Date = "13/02/2020",  SaleQty="55", Stock="5000"});
            
        }
    }
}
