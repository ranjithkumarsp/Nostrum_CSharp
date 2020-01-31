using NostrumWPFUI.ViewModel;
using System.Windows.Controls;

namespace NostrumWPFUI.View
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
        {
            InitializeComponent();
            this.DataContext = new ProductsViewModel();
        }
    }
}
