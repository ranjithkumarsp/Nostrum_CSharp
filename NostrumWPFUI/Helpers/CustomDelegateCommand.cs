using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nostrum.Helpers
{
    public class CustomDelegateCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public CustomDelegateCommand(Action<object> execute)
        {
            this.execute = execute;
            this.canExecute = (x) => { return true; };
        }
        public CustomDelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
