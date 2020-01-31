using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class ClientsViewModel:BaseViewModel
    {
        public ClientsViewModel()
        {
            Initialize();
        }

        public ICommand AddClientCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void Initialize()
        {
            AddClientCommand = new DelegateCommand(AddClientMethod);
            ClearCommand = new DelegateCommand(ClearMethod);
        }

        public void AddClientMethod(object param)
        {

        }
        public void ClearMethod(object param)
        {

        }

    }
}
