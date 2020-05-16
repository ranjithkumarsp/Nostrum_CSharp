using Nostrum.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;

namespace Nostrum.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        
        public MainWindowViewModel()
        {
            Initialize();
        }        

        public ICommand SingleExcelImportCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void Initialize()
        {            
           
            ClearCommand = new CustomDelegateCommand(ClearMethod);
        }

        
        public void ClearMethod(object param)
        {

        }

        private DelegateCommand<object> _TabselectionChange;
        public DelegateCommand<object> TabSelectionChangedCommand =>
            _TabselectionChange ?? (_TabselectionChange = new DelegateCommand<object>(ExecuteTabSelectionChangedCommand));

        private void ExecuteTabSelectionChangedCommand(object obj)
        {
            
        }
    }
}
