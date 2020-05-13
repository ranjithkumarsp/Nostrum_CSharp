namespace Nostrum.Helpers
{
    public class InvoiceData
    {
        public string GSTIN { get; set; }
        public string Date { get; set; }
        public string InvoiceNo { get; set; }
        public string NameAndAddressOfBuyer { get; set; }
        public string DispatchMode { get; set; }
        public string PaymentTerms { get; set; }
        public string OurDrugLicense { get; set; }
        public string BillValue { get; set; }
        public string CGSTPercentage { get; set; }
        public string CGSTValue { get; set; }
        public string SGSTPercentage { get; set; }
        public string SGSTValue { get; set; }
        public string IGSTPercentage { get; set; }
        public string IGSTValue { get; set; }
        public string BillTotal { get; set; }
        public string BuyerLicenseNo { get; set; }
    }
}
