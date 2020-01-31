using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class StockViewModel : BaseViewModel
    {
        #region CONSTRUCTOR
        public StockViewModel()
        {
            Initialize();
        }        
        #endregion
        public ICommand ShowCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void Initialize()
        {
            ShowCommand = new DelegateCommand(ShowMethod);
            ClearCommand = new DelegateCommand(ClearMethod);
        }

        public void ShowMethod(object param)
        {

        }
        public void ClearMethod(object param)
        {

        }
    }
}
