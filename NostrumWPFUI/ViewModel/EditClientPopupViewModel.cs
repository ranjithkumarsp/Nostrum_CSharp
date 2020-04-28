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
        //EditClientPopupView editClientPopup;

        #region Constructor

        public EditClientPopupViewModel()
        {
            IsClientSelected = false;
            GetClientsFromDB();
            SelectedClient = ClientsList.FirstOrDefault();

            WindowCloseCommand = new CustomDelegateCommand(WindowClosingMethod);
            OnLoadedCmd = new CustomDelegateCommand(this.OnLoadedMthd);
            CancelRelayCommand = new RelayCommand<IClosable>(this.CancelMethod);
            OKRelayCommand = new RelayCommand<IClosable>(this.OkMethod);
        }

        #endregion

        #region Properties

        public ICommand WindowCloseCommand { get; set; }
        public ICommand OnLoadedCmd { get; set; }
        public DelegateCommand<IClosable> CloseWindowCommand { get; set; }
        public RelayCommand<IClosable> OKRelayCommand { get; private set; }
        public RelayCommand<IClosable> CancelRelayCommand { get; private set; }

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

        private bool _isClientSelected;

        public bool IsClientSelected
        {
            get { return _isClientSelected; }
            set { _isClientSelected = value; this.RaisePropertyChange(); }
        }


        #endregion

        #region Methods

        private void OnLoadedMthd(object obj)
        {
           // editClientPopup = obj as EditClientPopupView;
        }

        private void OkMethod(IClosable editClientPopup)
        {
            IsClientSelected = true;
            editClientPopup.ClosePopupWindow();

        }

        private void CancelMethod(IClosable editClientPopup)
        {
            SelectedClient = string.Empty;
            if (editClientPopup != null)
            {
                editClientPopup.ClosePopupWindow();
            }
        }

        private void WindowClosingMethod(object obj)
        {
            if(!IsClientSelected)
            SelectedClient = string.Empty;
        }    

        public void GetClientsFromDB()
        {
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            ClientsList = dao.GetClients();
        }

        #endregion

    }
}
