using NostrumDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LineItem
    {
        public int Order_Id { get; set; }
        public string FY { get; set; }
        public int S_No { get; set; }
        public string Product_Name { get; set; }
        public string Batch { get; set; }
        public int Offer1 { get; set; }
        public int Offer2 { get; set; }
        public int Pack1 { get; set; }
        public int Pack2 { get; set; }

        private Product.DrugType _drugType;
        public string Packing
        {
            get
            {
                if (Product.DrugType.Syrup == _drugType || Product.DrugType.Suspension == _drugType)
                {
                    return Pack1 + " ml";
                }
                else
                {
                    return Pack1 + " x " + Pack2;
                }
            }
        }

        public string Offer
        {
            get
            {
                if (Offer1 == 0 || Offer2 == 0)
                    return "Nett Rate";
                else
                    return Offer1 + " + " + Offer2;
            }
        }

        public double Quantity { get; set; }
        public double Rate { get; set; }

        public string ExpDate { get; set; }

        public double MRP { get; set; }

        public double Amount
        {
            get { return Rate * Quantity; }
        }

        public double CGST { get; set; }

        public double SGST { get; set; }

        public void ClearAll()
        {
            Order_Id = 0;
            FY = "";
            S_No = 0;
            Product_Name = "";
            Batch = "";
            Pack1 = 0;
            Pack2 = 0;
            Offer1 = 0;
            Offer2 = 0;
            Quantity = 0;
            Rate = 0;

            MRP = 0;
            ExpDate = "";
            _drugType = Product.DrugType.Tablet;
            CGST = 0;
            SGST = 0;
        }
        public void FillRemainingFields()
        {
            ProductDAO productDao = new ProductDAO(new MySQLDBInterface());
            Product product = productDao.GetProduct(Product_Name, Batch);

            MRP = product.MRP;
            ExpDate = product.Exp_Date.ToString("MMM-yy");
            _drugType = product.Drug_Type;
            if (_drugType == Product.DrugType.Syrup || _drugType == Product.DrugType.Suspension)
            {
                Pack1 = product.Pack1;
                Pack2 = 0;
            }
            CGST = product.CGST;
            SGST = product.SGST;
        }
    }
}
