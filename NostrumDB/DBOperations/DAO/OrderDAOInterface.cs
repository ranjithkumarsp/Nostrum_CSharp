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
        bool DeleteOrder(int orderId, string fy);
        Order GetOrder(int orderId, string fy);
        List<string> GetOrderIds();
        List<string> GetOrderIds(string clientName, string FromDate, string ToDate);
        int GetNextInvNo(string FY);
        int GetNextInvNo();
        bool UpdateOrder(Order order);
    }
}