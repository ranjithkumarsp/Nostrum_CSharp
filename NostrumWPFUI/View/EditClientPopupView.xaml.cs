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
    namespace EditPopUpView
    {
        public enum ActionTaken
        {
            None = 0,
            Edit,
            Delete
        }
    }
    public partial class EditClientPopupView : Window
    {
        EditPopUpView.ActionTaken actionTaken;
        public EditClientPopupView()
        {
            InitializeComponent();
            actionTaken = EditPopUpView.ActionTaken.None;
            this.DataContext = new EditClientPopupViewModel();
        }

        public void ButtonClicked(object o, EventArgs e)
        {
            if ((o as Button).Content.Equals("Edit"))
                actionTaken = EditPopUpView.ActionTaken.Edit;
            else
                actionTaken = EditPopUpView.ActionTaken.Delete;

            if(LoadClientCombo.SelectedItem != null)
                this.DialogResult = true;
        }

        public void OnClientSelected(object o, EventArgs e)
        {
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }
        public EditPopUpView.ActionTaken GetActionTaken()
        {
            return actionTaken;
        }
        public string GetSelectedClient()
        {
            return LoadClientCombo.SelectedValue.ToString();
        }
    }
}
