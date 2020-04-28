using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace NostrumDB
{
    interface IProductDAO
    {
        bool AddProduct(Product product);
        Product GetProduct(string name, string batch);
        Product.DrugType GetProductType(string name);
        List<string> GetProductNames();
        List<string> GetManufacturers();
        bool UpdateProduct(Product product);
        bool DeleteProduct(string name, string batch);
    }
}
