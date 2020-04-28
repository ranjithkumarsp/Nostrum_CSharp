using System.Collections.Generic;

using Entity;

namespace NostrumDB
{
    interface ILineItemDAO
    {
        bool addLineItem(LineItem lineItem);
        bool deleteLineItem(int orderId, string fy, int sNo);
        bool deleteAllLineItems(int orderId, string fy);
        List<LineItem> getLineItems(int orderId, string fy);
        bool updateLineItem(LineItem LineItem);
    }
}