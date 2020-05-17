using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nostrum.UIEntity
{
    public class StockDisplay
    {
        public DateTime Date { get; set; }

        public string InvoiceNo { get; set; }

        public string Manufacturer { get; set; }

        public string BatchNo { get; set; }

        public string ManufactureDate { get; set; }

        public string ExpiryDate { get; set; }

        public string PurchaseQty { get; set; }

        public string SaleQty { get; set; }

        public int Stock { get; set; }

        public string Remarks { get; set; }
    }
}
