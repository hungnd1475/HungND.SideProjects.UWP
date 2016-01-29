using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.Data;

namespace HungND.SideProjects.UWP
{
    public class NavigationCommand<T> : Command
        where T : Page
    {
        private readonly Frame _rootFrame;
        private readonly Func<object, bool> _canExecute;
        private readonly NavigationTransitionInfo _navTransInfo;

        public NavigationCommand(Frame rootFrame)
            : this(rootFrame, null, null)
        { }

        public NavigationCommand(Frame rootFrame, Func<object, bool> canExecute)
            : this(rootFrame, canExecute, null)
        { }

        public NavigationCommand(Frame rootFrame, NavigationTransitionInfo navTransInfo)
            : this(rootFrame, null, navTransInfo)
        { }

        public NavigationCommand(Frame rootFrame, Func<object, bool> canExecute, NavigationTransitionInfo navTransInfo)
        {
            if (rootFrame == null)
                throw new ArgumentNullException(nameof(rootFrame));
            _rootFrame = rootFrame;
            _canExecute = canExecute;
            _navTransInfo = navTransInfo;
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute != null ? _canExecute(parameter) : true;
        }

        public override void Execute(object parameter)
        {
            if (_navTransInfo == null)
            {
                _rootFrame.Navigate(typeof(T), parameter);
            }
            else
            {
                _rootFrame.Navigate(typeof(T), parameter, _navTransInfo);
            }
        }
    }
}
