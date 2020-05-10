using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NostrumExcelReader;
using Prism.Commands;

namespace NostrumWPFUI.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ExcelReaderClass ExcelReader;
        public MainWindowViewModel()
        {
            Initialize();
        }
        

        public ICommand SingleExcelImportCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void Initialize()
        {
            ExcelReader = new ExcelReaderClass();
            SingleExcelImportCommand = new CustomDelegateCommand(SingleExcelImportMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
        }

        public void SingleExcelImportMethod(object param)
        {

            ExcelReader.SingleFileProcess();
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
