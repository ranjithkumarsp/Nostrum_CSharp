using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity;

namespace NostrumDB
{
    interface IPaymentDAO
    {
        bool addPayment(Payment payment);
        List<Payment> getPayments(string orderId, string fy);
        double getTotalAmountPaid(string orderId, string fy);
    }
}
