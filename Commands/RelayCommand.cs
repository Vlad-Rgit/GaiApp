using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GaiApp.Commands
{
    public class RelayCommand : ICommand
    {

        private Func<bool> _canExecute;
        private Action _execute;


        public RelayCommand(Action execute, Func<bool> canExecute = null)
            => (_execute, _canExecute) = (execute, canExecute);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
            => _canExecute == null ? true : _canExecute();

        public void Execute(object parameter)
            => _execute();
       
    }
}
