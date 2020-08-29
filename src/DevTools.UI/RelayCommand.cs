using System;
using System.Diagnostics;
using System.Windows.Input;

namespace DevTools.UI
{
    public class RelayCommand : ICommand
    {
        readonly Func<Boolean> _canExecute;
        readonly Action _execute;


        public RelayCommand(Action execute) : this(execute, null) { }
        public RelayCommand(Action execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute; _canExecute = canExecute;
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(Object parameter) { _execute(); }
    }
}
