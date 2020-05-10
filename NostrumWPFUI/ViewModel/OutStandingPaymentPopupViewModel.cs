using Entity;
using NostrumDB;
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
        public ICommand SaveAsPDFCommand { get; set; }
        public OutStandingPaymentPopupViewModel(List<Order> orders)
        {
            OutstandingPaymentGridCollection = new ObservableCollection<OutstandingPayment>();
            FillOutstandingForm(orders);
            SaveAsPDFCommand = new PrintCommand();
        }

        private void FillOutstandingForm(List<Order> paymentList)
        {
            int s_no = 0;
            foreach (var item in paymentList)
            {
                if(item.Balance > 0)
                {
                    OutstandingPayment payment = new OutstandingPayment();
                    payment.SerialNo = ++s_no + ".";
                    payment.InvoiceNo = "INV-" + item.FY + "-" + item.Order_Id;
                    payment.InvoiceDate = item.Order_Date.ToString("dd-MMM-yyyy");
                    payment.InvoiceAmount = item.Balance;
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
