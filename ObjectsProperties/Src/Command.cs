using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ObjectsProperties.Src
{
    public class Command : ICommand
    {
        private Action<object> _action;
        private Predicate<object> _canExecute;


        public Command(Action<object> execute) : this(execute, null) { }


        public Command(Action<object> action, Predicate<object> canExecute)
        {
            //if (action == null) throw new ArgumentNullException("execute");
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }

    }
}
