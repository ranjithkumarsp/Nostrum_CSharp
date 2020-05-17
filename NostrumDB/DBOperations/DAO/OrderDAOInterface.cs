using System;
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
        bool DeleteOrder(double orderId, string fy);
        Order GetOrder(double orderId, string fy);
        List<string> GetOrderIds();
        List<string> GetOrderIds(string clientName, DateTime FromDate, DateTime ToDate);
        int GetNextInvNo(string FY);
        int GetNextInvNo();
        bool UpdateOrder(Order order);
    }
}