using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace NostrumDB
{
    interface IOrderDAO
    {
        bool AddOrder(Order order);
        bool DeleteOrder(string orderId, string fy);
        Order GetOrder(string orderId, string fy);
        List<string> GetOrderIds();
        int GetNextInvNo(string FY);
        int GetNextInvNo();
        bool UpdateOrder(Order order);
    }
}