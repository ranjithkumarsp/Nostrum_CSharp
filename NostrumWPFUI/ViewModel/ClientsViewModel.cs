using NostrumDB;
using NostrumWPFUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Entity;
using System.Windows;
using NostrumWPFUI.View;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Controls;

namespace NostrumWPFUI.ViewModel
{
    public class ClientsViewModel:BaseViewModel, IDataErrorInfo
    {
        #region Properties

        private string _clientName;

        public string ClientName
        {
            get { return _clientName; }
            set {
                _clientName = value;
                this.RaisePropertyChange();
            }
        }

        private string _dispName;

        public string DisplayName
        {
            get { return _dispName; }
            set {
                _dispName = value;
                this.RaisePropertyChange();
            }
        }
        private string _addr;

        public string Address
        {
            get { return _addr; }
            set {
                _addr = value;
                this.RaisePropertyChange();
            }
        }

        private string _dlNo;

        public string DLNo
        {
            get { return _dlNo; }
            set {
                _dlNo = value;
                this.RaisePropertyChange();
            }
        }
        private string _tinNo;

        public string TinNo
        {
            get { return _tinNo; }
            set { _tinNo = value;
            this.RaisePropertyChange();
            }
        }

        private string _clientNameBtn;

        public string ClientNameBtn
        {
            get { return _clientNameBtn; }
            set { _clientNameBtn = value;this.RaisePropertyChange(); }
        }


        private Client _currClient;

        public Client CurrentClient
        {
            get { return _currClient; }
            set { _currClient = value;this.RaisePropertyChange(); }
        }

        List<string> ClientsFromDB = new List<string>();

        #endregion

        public ClientsViewModel()
        {
            Initialize();
            
        }

        //public ICommand AddClientCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand OnLoadedCmd { get; set; }
        public RelayCommand AddClientCommand { get; set; }

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                string result = string.Empty;
                //if (propertyName == "ClientName")
                //{
                //    if (this.ClientName == "")
                //        result = "Name can not be empty";
                //}
                //else if(propertyName == "DisplayName")
                //{
                //    if (this.DisplayName == "")
                //        result = string.Format("{0} Cannot be Empty", propertyName);
                //}
                //else if (propertyName == "Address")
                //{
                //    if (this.Address == "")
                //        result = string.Format("{0} Cannot be Empty", propertyName);
                //}
                switch (propertyName)
                {
                    case "ClientName":
                        if (this.ClientName == "")
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        break;
                    case "DisplayName":
                            if (this.DisplayName == "")
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        break;
                    case "Address":
                        if (this.Address == "")
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        break;
                    case "DLNo":
                        if (this.DLNo == "")
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        break;
                    case "TinNo":
                        if (this.TinNo == "")
                            result = string.Format("{0} Cannot be Empty", propertyName);
                        break;
                }

                if(ErrorCollection.ContainsKey(propertyName))
                {
                    ErrorCollection[propertyName] = result;
                }
                else if (result != null)
                {
                    ErrorCollection.Add(propertyName, result);
                }
                RaisePropertyChange("ErrorCollection");
                return result;
            }
        }

        //public string this[string property]
        //{
        //    get
        //    {
        //        PropertyInfo propertyInfo = this.GetType().GetProperty(property);
        //        var results = new List<ValidationResult>();

        //        var result = Validator.TryValidateProperty(
        //                                  propertyInfo.GetValue(this, null),
        //                                  new ValidationContext(this, null, null)
        //                                  {
        //                                      MemberName = property
        //                                  },
        //                                  results);

        //        if (!result)
        //        {
        //            var validationResult = results.First();
        //            return validationResult.ErrorMessage;
        //        }

        //        return string.Empty;
        //    }
        //}

        public void Initialize()
        {
            //AddClientCommand = new CustomDelegateCommand(AddClientMethod,CanAddClient);
            ClearCommand = new CustomDelegateCommand(ClearMethod);
            EditUserCommand = new CustomDelegateCommand(EditClientMethod);
            OnLoadedCmd = new CustomDelegateCommand(this.OnLoadedMthd);
            ClientNameBtn = "Add Client";
            AddClientCommand = new RelayCommand(AddClientMethod, CanAddClient);
        }

        private bool canaddclient(object obj)
        {
            if (ErrorCollection.Any(x => x.Value != ""))
                return false;
            else
                return true;
        }

        private void addclient(object obj)
        {
            
        }

        private bool CanAddClient(object arg)
        {           
            if (ErrorCollection.Any(x => x.Value != ""))
                return false;
            else
                return true;
        }

        private void OnLoadedMthd(object obj)
        {
            
        }

        private Entity.Client CreateClient()
        {
            Entity.Client cl = new Client();
            cl.Name = ClientName;
            cl.Display_Name = DisplayName;

            string[] addrArr = Address.Split(new char[] { '\r', '\n'},3,StringSplitOptions.RemoveEmptyEntries);
            cl.Addr1 = addrArr[0];
            if(addrArr.Length > 1)
                cl.Addr2 = addrArr[1];
            if(addrArr.Length > 2)
                cl.Addr3 = addrArr[2];
            cl.DL_No = DLNo;
            cl.TIN_No = TinNo;
            return cl;
        }
        public void AddClientMethod(object param)
        {
            Client cl = CreateClient();
            ClientDAO clientDao = new ClientDAO(new MySQLDBInterface());
            try
            {
                if (clientDao.addClient(cl))
                {
                    MessageBox.Show("Client successfully Added!");
                    ClearMethod(null);
                }
                else
                {
                    MessageBox.Show("Unable to add client!");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }            
        }
        public void ClearMethod(object param)
        {
            DisplayName = String.Empty;
            ClientName = String.Empty;
            Address = String.Empty;
            DLNo = String.Empty;
            TinNo = String.Empty;
            ClientNameBtn = "Add Client";
        }
        public void EditClientMethod(object param)
        {
            Client c1 = new Client();
            EditClientPopupView editClient = new EditClientPopupView();
            EditClientPopupViewModel editPopupclientVM = new EditClientPopupViewModel();
            editClient.DataContext = editPopupclientVM;
            editClient.Owner = MainWindow;
            //editClient.Topmost = true;
            editClient.ShowDialog();
            var selectedClient = editPopupclientVM.SelectedClient;
            ClientNameBtn = !string.IsNullOrWhiteSpace(selectedClient) ? ClientNameBtn = "Update Client" : ClientNameBtn = "Add Client";
            CurrentClient = GetClientDetails(selectedClient);
            LoadClient(CurrentClient);
        }
        public Client GetClientDetails(string clientname)
        {
            Entity.Client p = new Entity.Client();
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            //p.Order_ID = "INV-001";
            //p.FY = "FY20";
            //p.Payment_ID = "2";
            //p.Amount = 1000;
            //p.Pay_Date = new DateTime(2020, 01, 01);
            //dao.addPayment(p);
            return dao.getClient(clientname);
        }

        private void LoadClient(Client client)
        {
            ClientName = client.Name;
            DisplayName = client.Display_Name;
            Address = client.Addr;
            DLNo = client.DL_No;
            TinNo = client.TIN_No;
        }
    }
}
