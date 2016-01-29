using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace HungND.SideProjects.UWP
{
    public class PaneMenuItem : BindableBase
    {
        private string _label;
        public string Label
        {
            get { return _label; }
            set { SetProperty(ref _label, value); }
        }

        private IconElement _icon;
        public IconElement Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        private readonly ICommand _command;
        private readonly Func<object> _getParameter;

        public PaneMenuItem(string label, IconElement icon, ICommand command, Func<object> getParameter = null)
        {
            _label = label;
            _icon = icon;
            _command = command;
            _getParameter = getParameter;
        }

        public void ExecuteCommand()
        {
            _command?.Execute(_getParameter?.Invoke());
        }
    }
}
