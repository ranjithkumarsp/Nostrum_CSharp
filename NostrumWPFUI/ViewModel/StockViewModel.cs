using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
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
            ShowCommand = new CustomDelegateCommand(ShowMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
        }

        public void ShowMethod(object param)
        {            
            StockDisplayPopupView stockdisplaypopupview = new StockDisplayPopupView();
            StockDisplayPopupViewModel _outStandingPaymentPopupViewModel = new StockDisplayPopupViewModel();
            stockdisplaypopupview.DataContext = _outStandingPaymentPopupViewModel;
            stockdisplaypopupview.Owner = MainWindow;
            stockdisplaypopupview.ShowDialog();
        }
        public void ClearMethod(object param)
        {

        }
    }
}
