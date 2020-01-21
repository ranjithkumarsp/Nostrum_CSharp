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
        private string _batch;
        private int _quantity;

        public string Product
        {
            get
            {
                return _product;
            }
        }
        public string Batch
        {
            get
            {
                return _batch;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }
    }
}
