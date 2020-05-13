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
using Nostrum.ViewModel;
using Nostrum.Helpers;

namespace Nostrum.View
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

        private void PreviewTextInput_EnhanceComboSearch(object sender, TextCompositionEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            List<string> clientsList = ((BillingViewModel)this.DataContext).ClientsList;
            cmb.IsDropDownOpen = true;

            if (!string.IsNullOrEmpty(cmb.Text))
            {
                string fullText = cmb.Text.Insert(VisualHelpers.GetChildOfType<TextBox>(cmb).CaretIndex, e.Text);
                cmb.ItemsSource = clientsList.Where(s => s.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            }
            else if (!string.IsNullOrEmpty(e.Text))
            {
                cmb.ItemsSource = clientsList.Where(s => s.IndexOf(e.Text, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            }
            else
            {
                cmb.ItemsSource = clientsList;
            }
        }

        private void Pasting_EnhanceComboSearch(object sender, DataObjectPastingEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            List<string> clientsList = ((BillingViewModel)this.DataContext).ClientsList;
            cmb.IsDropDownOpen = true;

            string pastedText = (string)e.DataObject.GetData(typeof(string));
            string fullText = cmb.Text.Insert(VisualHelpers.GetChildOfType<TextBox>(cmb).CaretIndex, pastedText);

            if (!string.IsNullOrEmpty(fullText))
            {
                cmb.ItemsSource = clientsList.Where(s => s.IndexOf(fullText, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            }
            else
            {
                cmb.ItemsSource = clientsList;
            }
        }

        private void PreviewKeyUp_EnhanceComboSearch(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                ComboBox cmb = (ComboBox)sender;
                List<string> clientsList = ((BillingViewModel)this.DataContext).ClientsList;
                cmb.IsDropDownOpen = true;

                if (!string.IsNullOrEmpty(cmb.Text))
                {
                    cmb.ItemsSource = clientsList.Where(s => s.IndexOf(cmb.Text, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
                }
                else
                {
                    cmb.ItemsSource = clientsList;
                }
            }
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
