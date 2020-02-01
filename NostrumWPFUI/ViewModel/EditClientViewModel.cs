using Entity;
using NostrumDB;
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
    public class EditClientViewModel : BaseViewModel
    {
        EditClientView editClient1;
        public EditClientViewModel()
        {

        }
        public EditClientViewModel(EditClientView editClient)
        {
            editClient1 = editClient;
            getClients();
            OKCommand = new DelegateCommand(OkMethod);
            CancelCommand = new DelegateCommand(CancelMethod);
        }

        private void CancelMethod(object obj)
        {
            
        }

        private void OkMethod(object obj)
        {
            editClient1.Close();
        }

        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private List<string> _clientsList;

        public List<string> ClientsList
        {
            get { return _clientsList; }
            set { _clientsList = value; this.RaisePropertyChange(); }
        }

        private string _selectedClient;

        public string SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; this.RaisePropertyChange(); }
        }

        public void getClients()
        {
            Entity.Client p = new Entity.Client();
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            ClientsList = dao.getClients();
        }

    }
}
