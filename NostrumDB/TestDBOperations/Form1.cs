using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NostrumDB;

namespace TestDBOperations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Entity.Payment p = new Entity.Payment();
            //PaymentDAO dao = new PaymentDAO(new MySQLDBInterface());
            //p.Order_ID = "INV-001";
            //p.FY= "FY20";
            //p.Payment_ID = "2";
            //p.Amount = 1000;
            //p.Pay_Date = new DateTime(2020, 01, 01);
            //dao.addPayment(p);


            Entity.Client p = new Entity.Client();
            ClientDAO dao = new ClientDAO(new MySQLDBInterface());
            //p.Order_ID = "INV-001";
            //p.FY = "FY20";
            //p.Payment_ID = "2";
            //p.Amount = 1000;
            //p.Pay_Date = new DateTime(2020, 01, 01);
            //dao.addPayment(p);
            var dd = dao.GetClientInfo();

        }
    }
}
