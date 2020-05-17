using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;

namespace NostrumDB
{
    public class PaymentDAO : IPaymentDAO
    {
        IDBInterface _dbInterface;
        public PaymentDAO(IDBInterface dbInterface)
        {
            _dbInterface = dbInterface;
            _dbInterface.InitializeDB();
        }
        public bool AddPayment(Payment payment)
        {
            string query = "Insert into payments values(0,'" + payment.Order_ID + "','" + payment.FY+ "','" + payment.PaymentMade + "','" + payment.Pay_Date.ToString("yyyy-MM-dd") + "');";
            int nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public List<Payment> GetPayments(double orderId, int fy)
        {
            List<Payment> payments = new List<Payment>();
            string query = "Select * from payments where Order_Id = '" + orderId + "' and FY = '" + fy + "';";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                Payment payment = new Payment
                {
                    Order_ID = (double)dr["Order_ID"],
                    FY = dr["FY"].ToString(),
                    PaymentMade = (int)dr["Payment"],
                    Pay_Date = (DateTime)dr["Pay_Date"]
                };
                payments.Add(payment);
            }

            return payments;
        }

        public double GetTotalAmountPaid(double orderId, int fy)
        {
            double total = 0;
            string query = "Select sum(Payment) from payments where Order_Id = '" + orderId + "' and FY = '" + fy + "';";

            object obj = _dbInterface.ExecuteScalar(query);
            if (obj != null && obj != DBNull.Value)
                total = Convert.ToDouble(obj);

            return total;
        }
    }
}
