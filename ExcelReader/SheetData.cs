using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumExcelReader
{
    public class BatchSheetData
    {
        public string FileName { get; set; }
        public List<ExcelProduct> ProductList { get; set; }
        public InvoiceData InvoiceDetails { get; set; }
    }
}
