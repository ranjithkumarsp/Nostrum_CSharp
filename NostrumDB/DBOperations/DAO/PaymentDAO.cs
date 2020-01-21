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
        public bool addPayment(Payment payment)
        {
            int nRowsAffected = 0;
            string query = "Insert into payments values('" + payment.Payment_ID + "','" + payment.Order_ID + "','" + payment.FY+ "','" + payment.Amount + "','" + payment.Pay_Date.ToString("yyyy-MM-dd") + "');";
            nRowsAffected = _dbInterface.ExecuteNonQuery(query);
            return (nRowsAffected > 0);
        }

        public List<Payment> getPayments(string orderId, string fy)
        {
            List<Payment> payments = new List<Payment>();
            string query = "Select * from payments where Order_Id = '" + orderId + "' and FY = '" + fy + "';";

            DataTable dataTable = _dbInterface.ExecuteQuery(query);

            foreach (DataRow dr in dataTable.Rows)
            {
                Payment payment = new Payment();
                payment.Payment_ID = dr["Payment_ID"].ToString();
                payment.Order_ID = dr["Order_ID"].ToString();
                payment.FY = dr["FY"].ToString();
                payment.Amount = (double)dr["Amount"];
                payment.Pay_Date = (DateTime)dr["Pay_Date"];
                payments.Add(payment);
            }

            return payments;
        }

        public double getTotalAmountPaid(string orderId, string fy)
        {
            double total = 0;
            string query = "Select sum(Amount) from payments where Order_Id = '" + orderId + "' and FY = '" + fy + "';";

            total = _dbInterface.ExecuteScalar(query);

            return total;
        }
    }
}
