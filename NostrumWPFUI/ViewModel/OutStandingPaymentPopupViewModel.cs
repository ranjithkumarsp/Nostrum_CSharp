using Entity;
using NostrumDB;
using Nostrum.Helpers;
using Nostrum.UIEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;

namespace Nostrum.ViewModel
{
    public class OutStandingPaymentPopupViewModel : BaseViewModel
    {
        
        public OutStandingPaymentPopupViewModel(List<Order> orders)
        {
            OutstandingPaymentGridCollection = new ObservableCollection<OutstandingPayment>();
            FillOutstandingForm(orders);           
        }

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

        private void FillOutstandingForm(List<Order> paymentList)
        {
            int s_no = 0;
            foreach (var item in paymentList)
            {
                if(item.Balance > 0)
                {
                    OutstandingPayment payment = new OutstandingPayment
                    {
                        SerialNo = ++s_no + ".",
                        InvoiceNo = item.FY + "-" + item.Order_Id,
                        InvoiceDate = item.Order_Date.ToString("dd-MMM-yyyy"),
                        InvoiceAmount = item.Balance
                    };
                    OutstandingPaymentGridCollection.Add(payment);
                }
            }
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
    }
}
