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
        EditPopUpView.ActionTaken actionTaken;
        public EditProductPopUpView()
        {
            InitializeComponent();
            actionTaken = EditPopUpView.ActionTaken.None;
            this.DataContext = new EditProductPopUpViewModel();
        }
        public void ButtonClicked(object sender, EventArgs e)
        {
            if ((sender as Button).Content.Equals("Edit"))
                actionTaken = EditPopUpView.ActionTaken.Edit;
            else
                actionTaken = EditPopUpView.ActionTaken.Delete;

            if (ProductNameCombo.SelectedItem != null && BatchNumberCombo.SelectedItem != null)
                this.DialogResult = true;
        }
        public void OnBatchSelect(object o, EventArgs e)
        {
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }

        public EditPopUpView.ActionTaken GetActionTaken()
        {
            return actionTaken;
        }

        public void GetSelectedValues(out string product, out string batch)
        {
            product = ProductNameCombo.SelectedValue.ToString();
            batch = BatchNumberCombo.SelectedValue.ToString();
        }
    }
}
