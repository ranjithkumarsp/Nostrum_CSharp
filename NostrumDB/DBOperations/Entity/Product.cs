using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public enum DrugType
        {
            Tablet = 0,
            Syrup = 1
        }

        private string _name;
        private string _batch;
        private DrugType _drugType;
        private DateTime _mfgDate;
        private DateTime _expDate;
        private int _quantity;
        private double _cgst;
        private double _sgst;
        private double _mrp;
        private string _manufacuturer;
        private DateTime _purchaseDate;
        private string _purchaseInvNo;
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
        public string Batch
        {
            get
            {
                return _batch;
            }
            set
            {
                _batch = value;
            }
        }
        public DrugType Drug_Type
        {
            get
            {
                return _drugType;
            }
            set
            {
                _drugType = value;
            }
        }
        public DateTime Mfg_Date
        {
            get
            {
                return _mfgDate;
            }
            set
            {
                _mfgDate = value;
            }
        }
        public DateTime Exp_Date
        {
            get
            {
                return _expDate;
            }
            set
            {
                _expDate = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        public double CGST
        {
            get
            {
                return _cgst;
            }
            set
            {
                _cgst = value;
            }
        }
        public double SGST
        {
            get
            {
                return _sgst;
            }
            set
            {
                _sgst = value;
            }
        }
        public double MRP
        {
            get
            {
                return _mrp;
            }
            set
            {
                _mrp = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return _manufacuturer;
            }
            set
            {
                _manufacuturer = value;
            }
        }
        public DateTime Purchase_Date
        {
            get
            {
                return _purchaseDate;
            }
            set
            {
                _purchaseDate = value;
            }
        }
        public string Purchase_Invoice
        {
            get
            {
                return _purchaseInvNo;
            }
            set
            {
                _purchaseInvNo = value;
            }
        }
    }
}
