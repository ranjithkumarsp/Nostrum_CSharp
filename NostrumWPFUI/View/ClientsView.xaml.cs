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
using NostrumWPFUI.ViewModel;

namespace NostrumWPFUI.View
{
    /// <summary>
    /// Interaction logic for ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
            this.DataContext = new ClientsViewModel();
        }

        private void ClientTypeSelectionChanged(object sender, EventArgs e)
        {
            if(cmbClientType.SelectedValue.Equals("Doctor"))
            {
                this.lblDLNo.Text = "Regn No.";
                this.txtDLNo.Watermark = "Regn No.";
            }
            else
            {
                this.lblDLNo.Text = "D/L No.";
                this.txtDLNo.Watermark = "D.L. No.";
            }
        }
    }
}
