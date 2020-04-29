using System.Collections.Generic;

using Entity;

namespace NostrumDB
{
    interface ILineItemDAO
    {
        bool AddLineItem(LineItem lineItem);
        bool DeleteLineItem(int orderId, string fy, int sNo);
        bool DeleteAllLineItems(int orderId, string fy);
        List<LineItem> GetLineItems(int orderId, string fy);
        bool UpdateLineItem(LineItem LineItem);
    }
}