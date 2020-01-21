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
        bool addProduct(Product product);
        Product getProduct(string name, string batch);
        List<string> getProductNames();
        List<string> getManufacturers();
        bool updateProduct(Product product);
        bool deleteProduct(string name, string batch);
    }
}
