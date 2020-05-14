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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nostrum.View
{
    /// <summary>
    /// Interaction logic for StocksView.xaml
    /// </summary>
    public partial class StocksView : UserControl
    {
        public StocksView()
        {
           
            InitializeComponent();
            this.DataContext = new StockViewModel();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            (e.Parameter as Calendar).SelectedDate = DateTime.Now.Date;
        }
    }
    public class MyCommands
    {
        public static RoutedCommand SelectToday = new RoutedCommand("Today", typeof(MyCommands));
    }
}
