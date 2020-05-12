using NostrumWPFUI.ViewModel;
using System;
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

        private void DrugTypeChanged(object sender, EventArgs e)
        {
            if(cmbDrugType.SelectedValue.Equals("Tablet") ||
                cmbDrugType.SelectedValue.Equals("Capsule"))
            {
                txtPack1.Text = "1";
                txtPack2.Text = "1";
                txtPack2.Visibility = System.Windows.Visibility.Visible;
                lblPackX.Text = "X";
                lblMRP.Text = "For 1 Stripe";
            }
            else
            {
                txtPack1.Text = "100";
                txtPack2.Text = "0";
                txtPack2.Visibility = System.Windows.Visibility.Hidden;
                lblPackX.Text = "ml";
                lblMRP.Text = "For 1 Unit";
            }
        }
    }
}
