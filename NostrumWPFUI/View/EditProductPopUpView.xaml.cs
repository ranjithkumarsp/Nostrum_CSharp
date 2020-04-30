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
    /// Interaction logic for EditProductPopUpView.xaml
    /// </summary>
    public partial class EditProductPopUpView : Window
    {
        public EditProductPopUpView()
        {
            InitializeComponent();
            this.DataContext = new EditProductPopUpViewModel();
        }
        public void OkButtonClicked(object o, EventArgs e)
        {
            if (ProductNameCombo.SelectedItem != null && BatchNumberCombo.SelectedItem != null)
                this.DialogResult = true;
        }
        public void OnBatchSelect(object o, EventArgs e)
        {
            OkButton.IsEnabled = true;
        }

        public void GetSelectedValues(out string product, out string batch)
        {
            product = ProductNameCombo.SelectedValue.ToString();
            batch = BatchNumberCombo.SelectedValue.ToString();
        }
    }
}
