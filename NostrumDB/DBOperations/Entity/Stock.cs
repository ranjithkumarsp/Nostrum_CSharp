using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Stock
    {
        private string _product;
        private DateTime _date;
        private string _invNo;
        private string _3rdParty;
        private string _batch;
        private DateTime _mfgDate;
        private DateTime _expDate;
        private int _purchaseQty;
        private int _sellQty;
        private int _stock;
        

        public DateTime Date { get => _date; set => _date = value; }
        public string InvNo { get => _invNo; set => _invNo = value; }
        public string ThirdParty { get => _3rdParty; set => _3rdParty = value; }
        public DateTime MfgDate { get => _mfgDate; set => _mfgDate = value; }
        public DateTime ExpDate { get => _expDate; set => _expDate = value; }
        public int RemainingStock { get => _stock; set => _stock = value; }
        public string Product { get => _product; set => _product = value; }
        public string Batch { get => _batch; set => _batch = value; }
        public string BuyQty {
            get
            {
                if (_purchaseQty == 0)
                    return "-";
                else
                    return _purchaseQty.ToString();
            }
            set {
                _purchaseQty = Convert.ToInt32(value);
            }
        }
        public string SellQty
        {
            get
            {
                if (_sellQty == 0)
                    return "-";
                else
                    return _sellQty.ToString();
            }
            set
            {
                _sellQty = Convert.ToInt32(value);
            }
        }
    }
}
