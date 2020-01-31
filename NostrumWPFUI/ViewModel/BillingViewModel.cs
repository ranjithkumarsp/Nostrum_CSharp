using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class BillingViewModel : BaseViewModel
    {
        public BillingViewModel()
        {
            Initialize();
        }

        public ICommand BillingCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void Initialize()
        {
            BillingCommand = new DelegateCommand(BillingMethod);
            ClearCommand = new DelegateCommand(ClearMethod);
        }

        public void BillingMethod(object param)
        {

        }
        public void ClearMethod(object param)
        {

        }
    }
}
