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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NostrumWPFUI.ViewModel;
using NostrumWPFUI.Helpers;

namespace NostrumWPFUI.View
{
    /// <summary>
    /// Interaction logic for BillingView.xaml
    /// </summary>
    public partial class BillingView : UserControl
    {
        public BillingView()
        {
            InitializeComponent();
            this.DataContext = new BillingViewModel();
        }

        //TO Hide the row when Donation Radio button is selected.
        private void BillingRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            RowDefinition r = new RowDefinition();
            r.Height = new GridLength(0, GridUnitType.Auto);
            paymtTerms.Height = r.Height;
        }
    }
}
