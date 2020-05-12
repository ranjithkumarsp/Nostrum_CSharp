using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public static List<string> ValidProductTypes = new List<string> { "Tablet", "Syrup", "Capsule", "Suspension" };
        public enum DrugType
        {
            Tablet = 0,
            Syrup,
            Capsule,
            Suspension,
        }

        public static string DrugTypeToString(DrugType type)
        {
            switch (type)
            {
                case DrugType.Tablet:
                    return ValidProductTypes[(int)DrugType.Tablet];
                case DrugType.Syrup:
                    return ValidProductTypes[(int)DrugType.Syrup];
                case DrugType.Capsule:
                    return ValidProductTypes[(int)DrugType.Capsule];
                case DrugType.Suspension:
                    return ValidProductTypes[(int)DrugType.Suspension];
                default:
                    return ValidProductTypes[(int)DrugType.Tablet];
            }
        }

        public static DrugType StringToDrugType(string dt)
        {
            DrugType type = DrugType.Tablet;
            if (dt.Equals(ValidProductTypes[(int)DrugType.Tablet]))
                type = DrugType.Tablet;
            else if (dt.Equals(ValidProductTypes[(int)DrugType.Capsule]))
                type = DrugType.Capsule;
            else if (dt.Equals(ValidProductTypes[(int)DrugType.Syrup]))
                type = DrugType.Syrup;
            else if (dt.Equals(ValidProductTypes[(int)DrugType.Suspension]))
                type = DrugType.Suspension;
            return type;
        }

        public string StrDrugType
        {
            get
            {
                return DrugTypeToString(Drug_Type);
            }
            set
            {
                Drug_Type = StringToDrugType(value);               
            }
        }

        public string Name { get; set; }
        public string Batch { get; set; }
        public DrugType Drug_Type { get; set; }
        public DateTime Mfg_Date { get; set; }
        public DateTime Exp_Date { get; set; }
        public int Pack1 { get; set; }
        public int Pack2 { get; set; }
        public int Quantity { get; set; }
        public double CGST { get; set; }
        public double SGST { get; set; }
        public double MRP { get; set; }
        public string Manufacturer { get; set; }
        public DateTime Purchase_Date { get; set; }
        public string Purchase_Invoice { get; set; }
    }
}
