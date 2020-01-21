using System.Collections.Generic;

using Entity;

namespace NostrumDB
{
    interface ILineItemDAO
    {
        bool addLineItem(LineItem lineItem);
        bool deleteLineItem(string orderId, string fy, int sNo);
        bool deleteAllLineItems(string orderId, string fy);
        List<LineItem> getLineItems(string orderId, string fy);
        bool updateLineItem(LineItem LineItem);
    }
}