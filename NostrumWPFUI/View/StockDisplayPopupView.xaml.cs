using NostrumWPFUI.ViewModel;
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

namespace NostrumWPFUI.View
{
    /// <summary>
    /// Interaction logic for StockDisplayPopupView.xaml
    /// </summary>
    public partial class StockDisplayPopupView : Window
    {
        public StockDisplayPopupView(string prod, DateTime from, DateTime to) 
        {
            InitializeComponent();
            this.DataContext = new StockDisplayPopupViewModel(prod, from, to);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveasPdfButton.Visibility = Visibility.Collapsed;
        }
    }
}
