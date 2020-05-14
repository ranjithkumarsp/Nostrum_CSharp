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
    /// Interaction logic for EditClientPopupView.xaml
    /// </summary>
    public partial class ViewOldPopupView : Window
    {
        public ViewOldPopupView()
        {
            InitializeComponent();
            this.DataContext = new ViewOldPopupViewModel();
        }
    }
}
