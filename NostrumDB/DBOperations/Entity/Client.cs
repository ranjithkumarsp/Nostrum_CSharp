using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Client
    {
        private string _name;
        private string _phone;
        private string _displayName;
        private string _addr1;
        private string _addr2;
        private string _addr3;
        private string _tinNo;
        private string _dlNo;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
        public string Display_Name
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }
        public string Addr
        {
            get
            {
                return _addr1+"\r\n"+_addr2+"\r\n"+_addr3;
            }
        }
        public string Addr1
        {
            get
            {
                return _addr1;
            }
            set
            {
                _addr1 = value;
            }
        }
        public string Addr2
        {
            get
            {
                return _addr2;
            }
            set
            {
                _addr2 = value;
            }
        }
        public string Addr3
        {
            get
            {
                return _addr3;
            }
            set
            {
                _addr3 = value;
            }
        }
        public string TIN_No
        {
            get
            {
                return _tinNo;
            }
            set
            {
                _tinNo = value;
            }
        }
        public string DL_No
        {
            get
            {
                return _dlNo;
            }
            set
            {
                _dlNo = value;
            }
        }

        public override string ToString()
        {
            return "Name = " + Name + "Phone = " + Phone;
        }
    }
}
