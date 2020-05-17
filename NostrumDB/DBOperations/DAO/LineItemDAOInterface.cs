using System.Collections.Generic;

using Entity;

namespace NostrumDB
{
    interface ILineItemDAO
    {
        bool AddLineItem(LineItem lineItem);
        bool DeleteLineItem(double orderId, string fy, int sNo);
        bool DeleteAllLineItems(double orderId, string fy);
        List<LineItem> GetLineItems(double orderId, string fy);
        bool UpdateLineItem(LineItem LineItem);
    }
}