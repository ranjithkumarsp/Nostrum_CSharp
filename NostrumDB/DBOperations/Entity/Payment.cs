using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Payment
    {
        public double Order_ID { get; set; }
        public string FY { get; set; }

        public int PaymentMade { get; set; }

        public DateTime Pay_Date { get; set; }
    }
}
