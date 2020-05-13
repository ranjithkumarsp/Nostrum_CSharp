using Entity;
using Nostrum.Helpers;
using Nostrum.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nostrum.View
{
    /// <summary>
    /// Interaction logic for OutStandingPaymentPopupView.xaml
    /// </summary>
    public partial class OutStandingPaymentPopupView : Window, IClosable
    {
        public OutStandingPaymentPopupView(List<Order> paymentList)
        {
            InitializeComponent();
            this.DataContext = new OutStandingPaymentPopupViewModel(paymentList);
        }

        public void ClosePopupWindow()
        {
            this.Close();
        }

        public void HidePopupWindow()
        {
            this.Hide();
        }

        private void SaveasPdfButton_Click(object sender, RoutedEventArgs e)
        {
            SaveasPdfButton.Visibility = Visibility.Collapsed;
        }
    }
}
