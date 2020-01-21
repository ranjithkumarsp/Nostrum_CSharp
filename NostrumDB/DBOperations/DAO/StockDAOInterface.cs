using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostrumDB
{
    interface IStockDAO
    {
        int getStockQuantity(string name, string batch);
        List<string> getBatchNos(string name);
    }
}
