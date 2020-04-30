using NostrumWPFUI.Helpers;
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
    /// Interaction logic for EditClientPopupView.xaml
    /// </summary>
    public partial class EditClientPopupView : Window
    {
        public EditClientPopupView()
        {
            this.DataContext = new EditClientPopupViewModel();
            InitializeComponent();
        }

        public void OkButtonClicked(object o, EventArgs e)
        {
            if(LoadClientCombo.SelectedItem != null)
                this.DialogResult = true;
        }

        public void OnClientSelected(object o, EventArgs e)
        {
            OkButton.IsEnabled = true;
        }
        public string GetSelectedClient()
        {
            return LoadClientCombo.SelectedValue.ToString();
        }
    }
}
