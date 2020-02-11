using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using NostrumDB;

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
            BillingCommand = new CustomDelegateCommand(BillingMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
            GetClientsFromDB();
        }

        public void BillingMethod(object param)
        {
            BillFormView bfm = new BillFormView();
            bfm.Owner = MainWindow;
            bfm.ShowDialog();
        }
        public void ClearMethod(object param)
        {

        }

        private List<string> _clientsList;

        public List<string> ClientsList
        {
            get { return _clientsList; }
            set { _clientsList = value; this.RaisePropertyChange(); }
        }

        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            ClientsList = dao.getClients();
        }

    }
}
