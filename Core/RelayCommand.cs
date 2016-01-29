using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungND.SideProjects.UWP
{
    public class RelayCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action execute)
            : this(execute != null ? (o) => execute() : (Action<object>)null)
        { }

        public RelayCommand(Action execute, Func<bool> canExecute)
            : this(execute != null ? (o) => execute() : (Action<object>)null, 
                  canExecute != null ? (o) => canExecute() : (Func<object, bool>)null)
        { }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
