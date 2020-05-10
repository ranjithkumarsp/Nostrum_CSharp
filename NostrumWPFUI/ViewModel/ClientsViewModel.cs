using Entity;
using NostrumDB;
using NostrumWPFUI.Helpers;
using NostrumWPFUI.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace NostrumWPFUI.ViewModel
{
    public class ClientsViewModel : BaseViewModel
    {
        #region Properties

        public string ClientName
        {
            get { return CurrentClient.Name; }
            set
            {
                CurrentClient.Name = NostrumHelper.UppercaseFirst(value);
                this.RaisePropertyChange();
            }
        }

        public string DisplayName
        {
            get { return CurrentClient.Display_Name; }
            set
            {
                CurrentClient.Display_Name = value;
                this.RaisePropertyChange();
            }
        }

        public string Address
        {
            get { return CurrentClient.Address; }
            set
            {
                CurrentClient.Address = value;
                this.RaisePropertyChange();
            }
        }

        public string DLNo
        {
            get { return CurrentClient.DL_No; }
            set
            {
                CurrentClient.DL_No = value;
                this.RaisePropertyChange();
            }
        }

        public string TinNo
        {
            get { return CurrentClient.TIN_No; }
            set
            {
                CurrentClient.TIN_No = value;
                this.RaisePropertyChange();
            }
        }

        public string MobileNo
        {
            get { return CurrentClient.Phone; }
            set
            {
                CurrentClient.Phone = value;
                this.RaisePropertyChange();
            }
        }

        private string _submitButtonText;

        public string SubmitButtonText
        {
            get { return _submitButtonText; }
            set { _submitButtonText = value; this.RaisePropertyChange(); }
        }


        private Client _currClient;

        public Client CurrentClient
        {
            get { return _currClient; }
            set
            {
                _currClient = value;
            }
        }

        private bool _isNewClient;
        private IDBInterface _dbInterface;

        public bool IsNewClient
        {
            get { return _isNewClient; }
            set
            {
                _isNewClient = value;
                this.RaisePropertyChange();
                if (_isNewClient)
                    SubmitButtonText = "Add Client";
                else
                    SubmitButtonText = "Update Client";
            }
        }

        #endregion

        public ClientsViewModel()
        {
            Initialize();
        }

        //public ICommand AddClientCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand AddClientCommand { get; set; }
        public string this[string propertyName]
        {
            get
            {
                string result = string.Empty;
                switch (propertyName)
                {
                    case "ClientName":
                        if (ClientName == "")
                        {
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        }

                        break;
                    case "DisplayName":
                        if (DisplayName == "")
                        {
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        }

                        break;
                    case "Address":
                        if (Address == "")
                        {
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        }

                        break;
                    case "DLNo":
                        if (DLNo == "")
                        {
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        }

                        break;
                    case "TinNo":
                        if (TinNo == "")
                        {
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        }

                        break;
                    case "MobileNo":
                        if (MobileNo == "")
                        {
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        }
                        break;
                }
                return result;
            }
        }

        public void Initialize()
        {
            CurrentClient = new Client();
            _dbInterface = new MySQLDBInterface();
            AddClientCommand = new CustomDelegateCommand(OnSubmitMethod);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
            EditUserCommand = new CustomDelegateCommand(EditClientMethod);
            //AddClientCommand = new RelayCommand(AddClientMethod, CanAddClient); Relay command keeps calling the CanExecute method. Need to revisit on the usage of this. 

            ClearMethod(null);
        }

        private bool CanAddClient()
        {
            if (String.IsNullOrWhiteSpace(ClientName))
            {
                MessageBox.Show("Client Name cannot be empty");
                return false;
            }
            if(String.IsNullOrWhiteSpace(DisplayName))
            {
                MessageBox.Show("Display Name cannot be empty");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OnSubmitMethod(object param)
        {
            if(CanAddClient())
            {
                ClientDAO clientDAO = new ClientDAO(_dbInterface);
                if (IsNewClient)
                {
                    AddClient(clientDAO);
                }
                else
                {
                    UpdateClient(clientDAO);
                }
            }
        }
        public void UpdateClient(ClientDAO clientDAO)
        {
            try
            {
                if (clientDAO.UpdateClient(CurrentClient))
                {
                    MessageBox.Show("Client successfully Updated!");
                    ClearMethod(null);
                }
                else
                {
                    MessageBox.Show("Unable to update client!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddClient(ClientDAO clientDAO)
        {
            try
            {
                if (clientDAO.AddClient(CurrentClient))
                {
                    MessageBox.Show("Client successfully Added!");
                    ClearMethod(null);
                }
                else
                {
                    MessageBox.Show("Unable to add client!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void ClearMethod(object param)
        {
            IsNewClient = true;
            DisplayName = string.Empty;
            ClientName = string.Empty;
            Address = string.Empty;
            DLNo = string.Empty;
            TinNo = string.Empty;
            MobileNo = string.Empty;
        }
        public void EditClientMethod(object param)
        {
            EditClientPopupView editClient = new EditClientPopupView();
            editClient.Owner = MainWindow;

            if(editClient.ShowDialog() == true)
            {
                var selectedClient = editClient.GetSelectedClient();
                IsNewClient = false;
                FillClientDetails(selectedClient);
            }            
        }
        public void FillClientDetails(string clientname)
        {
            ClientDAO dao = new ClientDAO(_dbInterface);
            Client client = dao.GetClient(clientname);
            ClientName = client.Name;
            DisplayName = client.Display_Name;
            Address = client.Address;
            DLNo = client.DL_No;
            TinNo = client.TIN_No;
            MobileNo = client.Phone;
        }
    }
}
