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
        List<Payment> getPayments(int orderId, int fy);
        double getTotalAmountPaid(int orderId, int fy);
    }
}
