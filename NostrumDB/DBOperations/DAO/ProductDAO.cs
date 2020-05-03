using System;
using System.Collections.Generic;
using System.Data;
using Entity;

namespace NostrumDB
{
    public class ProductDAO : IProductDAO
    {
        IDBInterface _dbInterface;
        public ProductDAO(IDBInterface dbInterface)
        {
            _dbInterface = dbInterface;
            _dbInterface.InitializeDB();
        }
        public bool AddProduct(Product product)
        {
            int nRowsAffected = 0;
            string query = "Insert into products values('" + product.Name + "','" + product.Batch+ "','" + product.Drug_Type+ "','" + product.Mfg_Date.ToString("yyyy-MM-dd") + "','" + product.Exp_Date.ToString("yyyy-MM-dd") + "','" + product.Quantity + "','" + product.CGST+ "','" + product.SGST+ "','" + product.MRP + "','" + product.Manufacturer + "','" + product.Purchase_Date.ToString("yyyy-MM-dd") + "','" + product.Purchase_Invoice + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public bool DeleteProduct(string name, string batch)
        {
            int nRowsAffected = 0;
            string query = "Delete from products where Name = '" + name + "' and batch = '" + batch + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public List<string> GetManufacturers()
        {
            List<string> mfrs = new List<string>();
            string query = "Select Manufacturer from products;";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                mfrs.Add(dr["Manufacturer"].ToString());
            }

            return mfrs;
        }

        public Product GetProduct(string name, string batch)
        {
            Product product = new Product();
            string query = "Select * from products where name = '" + name + "' and batch = '" + batch + "';";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow reader = dataTable.Rows[0];
                product.Name = reader["Name"].ToString();
                product.Batch = reader["Batch"].ToString();
                product.Drug_Type = (Product.DrugType) Enum.Parse(typeof(Product.DrugType), reader["Drug_Type"].ToString(), true);
                product.Mfg_Date = (DateTime) reader["Mfg_Date"];
                product.Exp_Date = (DateTime) reader["Exp_Date"];
                product.Quantity = (int)reader["Quantity"];
                product.CGST = (double)reader["CGST"];
                product.SGST = (double)reader["SGST"];
                product.MRP = (double)reader["MRP"];
                product.Manufacturer = reader["Manufacturer"].ToString();
                product.Purchase_Date = (DateTime)reader["Purchase_Date"];
                product.Purchase_Invoice = reader["Purchase_Invoice"].ToString();
            }
            else
            {
                Console.WriteLine("Get Client returns 0 rows..!");
            }

            return product;
        }

        public List<Product> GetProducts(string name, DateTime from, DateTime to)
        {
            string query = "Select * from products where name = '" + name + "' and Purchase_date between '" + from.ToString("yyyy-MM-dd") + "' and '" + to.ToString("yyyy-MM-dd") + "';";
            List<Product> products = new List<Product>();
            DataTable dataTable = _dbInterface.ExecuteQuery(query);
            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product();
                product.Name = dr["Name"].ToString();
                product.Batch = dr["Batch"].ToString();
                product.Drug_Type = (Product.DrugType)Enum.Parse(typeof(Product.DrugType), dr["Drug_Type"].ToString(), true);
                product.Mfg_Date = (DateTime)dr["Mfg_Date"];
                product.Exp_Date = (DateTime)dr["Exp_Date"];
                product.Quantity = (int)dr["Quantity"];
                product.CGST = (double)dr["CGST"];
                product.SGST = (double)dr["SGST"];
                product.MRP = (double)dr["MRP"];
                product.Manufacturer = dr["Manufacturer"].ToString();
                product.Purchase_Date = (DateTime)dr["Purchase_Date"];
                product.Purchase_Invoice = dr["Purchase_Invoice"].ToString();
                products.Add(product);
            }
            return products;
        }

        public bool IsProductExpired(string name, string batch)
        {
            int count = 0;
            string query = "Select count(name) from products where name = '" + name + "' and batch = '" + batch + "' and Last_day(Exp_Date) < curdate();";
            object obj = _dbInterface.ExecuteScalar(query);
            if (obj != null && obj != DBNull.Value)
                count = Convert.ToInt32(obj);
            return (count > 0);
        }

        public List<string> GetProductNames()
        {
            List<string> productNames = new List<string>();
            string query = "Select distinct Name from products;";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                productNames.Add(dr["Name"].ToString());
            }

            return productNames;
        }

        public Product.DrugType GetProductType(string name)
        {
            Product.DrugType type = Product.DrugType.Tablet;
            string query = "Select Drug_Type from products where name = '" + name + "';";

            object obj = _dbInterface.ExecuteScalar(query);
            string drugType = "";
            if (obj != null && obj != DBNull.Value)
                drugType = Convert.ToString(obj);

            type = drugType.Equals("Syrup") ? Product.DrugType.Syrup : Product.DrugType.Tablet;
            
            return type;
        }

        public bool UpdateProduct(Product product)
        {
            int nRowsAffected = 0;
            string query = "Update products set Drug_Type = '" + product.Drug_Type + "', Mfg_Date = '" + product.Mfg_Date.ToString("yyyy-MM-dd") + "', Exp_Date = '" + product.Exp_Date.ToString("yyyy-MM-dd") + "', Quantity = '" + product.Quantity + "', CGST = '" + product.CGST + "', SGST = '" + product.SGST + "', MRP = '" + product.MRP + "', Manufacturer = '" + product.Manufacturer + "', Purchase_Date = '" + product.Purchase_Date.ToString("yyyy-MM-dd") + "', Purchase_Invoice = '" + product.Purchase_Invoice + "' where Name = '" + product.Name + "' and Batch = '" + product.Batch + "';";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }
    }
}