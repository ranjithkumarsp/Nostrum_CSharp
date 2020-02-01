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

namespace NostrumWPFUI.ViewModel
{
    public class ClientsViewModel:BaseViewModel
    {
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

        List<string> ClientsFromDB = new List<string>();
        public ClientsViewModel()
        {
            Initialize();
            GetClientDetails();
        }

        public ICommand AddClientCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        public void Initialize()
        {
            AddClientCommand = new DelegateCommand(AddClientMethod);
            ClearCommand = new DelegateCommand(ClearMethod);
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
        }
        public void GetClientDetails()
        {
            Entity.Client p = new Entity.Client();
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            //p.Order_ID = "INV-001";
            //p.FY = "FY20";
            //p.Payment_ID = "2";
            //p.Amount = 1000;
            //p.Pay_Date = new DateTime(2020, 01, 01);
            //dao.addPayment(p);
            ClientsFromDB = dao.getClients();
        }
    }
}
