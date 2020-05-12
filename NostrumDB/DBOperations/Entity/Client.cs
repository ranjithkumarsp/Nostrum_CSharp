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
        private string _type;
        private string _displayName;
        private string _address;
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

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
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

        public string Type { get => _type; set => _type = value; }
    }
}
