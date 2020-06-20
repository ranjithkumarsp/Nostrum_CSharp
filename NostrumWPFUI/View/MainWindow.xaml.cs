using log4net;
using Nostrum.Helpers;
using Nostrum.View;
using Nostrum.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Nostrum
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly ILog logger = LogManager.GetLogger("Nostrum Biotech");
        public MainWindow()
        {
            logger.Info("                            =============  Started Logging  ===========        ");            
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            VersionTxtBlk.Text = "1.2.005";            
            logger.InfoFormat("Version Info : {0}", VersionTxtBlk.Text);
        }

        private void NostrumMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {           
            var activetview = VisualHelpers.GetChildOfType<UserControl>(this.NostrumMainWindow);
            var _userControlsInMainWindow = VisualHelpers.GetLogicalChildrenCollection<UserControl>(NostrumMainWindow);
            logger.Info("        =============  Ended Logging  =============        ");
            //ExcelImportView _excelImportView = _userControlsInMainWindow.Where(x => x.Name.Equals("ExcelImportMainView")).FirstOrDefault() as ExcelImportView;
            // if (_excelImportView != null && _excelImportView.xlApp != null)
            //     _excelImportView.CLEAN(true);
            // System.Windows.Forms.Application.ExitThread(); //Closes all underlying threads

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tc = sender as TabControl; //The sender is a type of TabControl...

            if (tc != null && tc.SelectedItem != null)
            {
                var item = tc.SelectedItem;
                TabItem selectedtabname = tc.SelectedItem as TabItem;
                string name = selectedtabname.Name;
              
                //Do Stuff ...
            }
            
        }
    }
}
