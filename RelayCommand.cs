using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HMExtension.Xamarin
{
    public class RelayCommand : ICommand
    {
        private readonly Action ExecuteAction = null;
        private readonly Action<object> ExecuteActionParameter = null;
        private readonly Func<bool> CanExecuteFunc = null;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action Execute, Func<bool> CanExecute = null)
        {
            ExecuteAction = Execute;
            CanExecuteFunc = CanExecute;
            ChangeCanExecute();
        }

        public RelayCommand(Action<object> Execute, Func<bool> CanExecute = null)
        {
            ExecuteActionParameter = Execute;
            CanExecuteFunc = CanExecute;
            ChangeCanExecute();
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunc == null || CanExecuteFunc();
        }

        public void Execute(object parameter)
        {
            if (ExecuteAction != null)
            {
                ExecuteAction();
            }
            else if (ExecuteActionParameter != null)
            {
                ExecuteActionParameter?.Invoke(parameter);
            }
        }

        public void ChangeCanExecute()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
