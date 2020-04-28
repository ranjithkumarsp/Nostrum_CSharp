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

using Entity;
using NostrumWPFUI.ViewModel;

namespace NostrumWPFUI.View
{
    /// <summary>
    /// Interaction logic for AddLineItemView.xaml
    /// </summary>
    public partial class AddLineItemView : Window
    {
        public AddLineItemView(Order order)
        {
            InitializeComponent();
            this.DataContext = new AddLineItemViewModel(order);
        }
    }
}
