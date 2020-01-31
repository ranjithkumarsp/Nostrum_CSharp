using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class ProductsViewModel:BaseViewModel
    {
        public ProductsViewModel()
        {
            Initialize();
        }
        public ICommand SubmitCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void Initialize()
        {
            SubmitCommand = new DelegateCommand(SubmitMethod);
            ClearCommand = new DelegateCommand(ClearMethod);
        }

        public void SubmitMethod(object param)
        {

        }
        public void ClearMethod(object param)
        {

        }
    }
}
