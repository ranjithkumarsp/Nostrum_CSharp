using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class PaymentViewModel : BaseViewModel
    {
        public PaymentViewModel()
        {
            Initialize();
        }
        public ICommand InvoiceDetailsCommand { get; set; }
        public ICommand OutStandingDetailsCommand { get; set; }

        public void Initialize()
        {
            InvoiceDetailsCommand = new CustomDelegateCommand(InvoiceDetailsMethod);
            OutStandingDetailsCommand = new CustomDelegateCommand(OutStandingDetailsMethod);
        }

        public void InvoiceDetailsMethod(object param)
        {

        }
        public void OutStandingDetailsMethod(object param)
        {

        }

    }
}
