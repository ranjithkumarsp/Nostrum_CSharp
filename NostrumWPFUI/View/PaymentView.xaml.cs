using System;
using System.Collections.Generic;
using System.Data;
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
using NostrumWPFUI.UIEntity;
using NostrumWPFUI.ViewModel;

namespace NostrumWPFUI.View
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class PaymentView : UserControl
    {
        public PaymentView()
        {
            InitializeComponent();
            this.DataContext = new PaymentViewModel();
        }

        private void DataGrid_MouseDoubleClick(object sender,
                                  System.Windows.Input.MouseButtonEventArgs e)
        {
            IInputElement element = e.MouseDevice.DirectlyOver;
            if (element != null && element is FrameworkElement)
            {
                if (((FrameworkElement)element).Parent is DataGridCell)
                {
                    var grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null
        && grid.SelectedItems.Count == 1)
                    {
                        var rowView = grid.SelectedItem as DataRowView;
                        ClientPayment _clientpaymentrow = grid.SelectedItem as ClientPayment;
                        if (_clientpaymentrow != null)
                        {
                             // DataRow row = rowView.Row;
                            //do something with the underlying data
                        }

                    }
                }
            }
        }
    }
}
