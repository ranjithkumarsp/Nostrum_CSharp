using Entity;
using NostrumDB;
using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class EditClientPopupViewModel : BaseViewModel
    {

        #region Constructor

        public EditClientPopupViewModel()
        {
            GetClientsFromDB();
        }

        #endregion

        #region Properties

        private List<string> _clientsList;

        public List<string> ClientsList
        {
            get { return _clientsList; }
            set { _clientsList = value; this.RaisePropertyChange(); }
        }

        #endregion

        #region Methods
        public void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            ClientsList = dao.GetClients();
        }
        #endregion

    }
}
