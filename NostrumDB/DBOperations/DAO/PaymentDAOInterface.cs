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
        List<Payment> GetPayments(int orderId, int fy);
        double GetTotalAmountPaid(int orderId, int fy);
    }
}
