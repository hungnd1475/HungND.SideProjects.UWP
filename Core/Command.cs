using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HungND.SideProjects.UWP
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;    
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
