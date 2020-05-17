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
        bool AddPayment(Payment payment);
        List<Payment> GetPayments(double orderId, int fy);
        double GetTotalAmountPaid(double orderId, int fy);
    }
}
