using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMExtension.Xamarin.Mvvm
{
    public class RelayCommand : ICommand
    {
        private Action ExecuteAction = null;
        private Action<object> ExecuteActionParameter = null;
        private Func<bool> CanExecuteFunc = null;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action Execute, Func<bool> CanExecute = null)
        {
            ExecuteAction = Execute;
            CanExecuteFunc = CanExecute;
            ExecuteChanged();
        }

        public RelayCommand(Action<object> Execute, Func<bool> CanExecute = null)
        {
            ExecuteActionParameter = Execute;
            CanExecuteFunc = CanExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteFunc != null)
            {
                return CanExecuteFunc();
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (ExecuteAction != null)
            {
                ExecuteAction();
            }
            else if (ExecuteActionParameter != null)
            {
                ExecuteActionParameter(parameter);
            }
        }

        public void ExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
