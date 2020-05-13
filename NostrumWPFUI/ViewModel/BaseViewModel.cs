using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Nostrum.Helpers;

namespace Nostrum.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            MainWindow = Application.Current.MainWindow;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private Window _mainWindow;

        public Window MainWindow
        {
            get { return _mainWindow; }
            set { _mainWindow = value; this.RaisePropertyChange(); }
        }

    }

}
