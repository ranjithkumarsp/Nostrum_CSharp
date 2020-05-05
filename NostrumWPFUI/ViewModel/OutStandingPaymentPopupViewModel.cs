using NostrumWPFUI.Helpers;
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
    public class OutStandingPaymentPopupViewModel : BaseViewModel
    {
        public OutStandingPaymentPopupViewModel()
        {
            LoadDummydata();            
        }       

        public int TotalOutStanding
        {
            get
            {
                return OutstandingPaymentGridCollection.Sum(a => a.InvoiceAmount);
            }
        }

        private ObservableCollection<OutstandingPayment> _outstandingPaymentGridCollection;

        public ObservableCollection<OutstandingPayment> OutstandingPaymentGridCollection
        {
            get { return _outstandingPaymentGridCollection; }
            set { _outstandingPaymentGridCollection = value; this.RaisePropertyChange(); }
        }

        public void LoadDummydata()
        {
            OutstandingPaymentGridCollection = new ObservableCollection<OutstandingPayment>();
            OutstandingPaymentGridCollection.Add(new OutstandingPayment { SerialNo = "01", InvoiceDate = "13/02/2020", InvoiceNo = "001",  InvoiceAmount = 1500});
            OutstandingPaymentGridCollection.Add(new OutstandingPayment { SerialNo = "02", InvoiceDate = "11/02/2020", InvoiceNo = "002",  InvoiceAmount = 2500 });
            OutstandingPaymentGridCollection.Add(new OutstandingPayment { SerialNo = "03", InvoiceDate = "10/02/2020", InvoiceNo = "003",  InvoiceAmount = 3500 }); 
                  
        }
    }
}
