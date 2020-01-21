using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace NostrumDB
{
    interface IOrderDAO
    {
        bool addOrder(Order order);
        bool deleteOrder(string orderId, string fy);
        Order getOrder(string orderId, string fy);
        List<string> getOrderIds();
        int getNextInvNo(string FY);
        int getNextInvNo();
        bool updateOrder(Order order);
    }
}