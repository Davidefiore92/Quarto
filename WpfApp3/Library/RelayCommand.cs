using System;
using System.Windows.Input;

namespace WpfApp3.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> _action;
        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                _action(parameter);
            }
            else
            {
                _action("Hello World");
            }
        }

        //We need to include CanExecuteChange when using the Interface ICommand 
        //In this case it doesn't actually do anything.
        public event EventHandler CanExecuteChanged;

    }


}
