using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace HungND.SideProjects.UWP
{
    public class PaneToggleCommand : Command
    {
        private readonly SplitView _rootSplitView;

        public PaneToggleCommand(SplitView rootSplitView)
        {
            if (rootSplitView == null)
                throw new ArgumentNullException(nameof(rootSplitView));

            _rootSplitView = rootSplitView;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            _rootSplitView.IsPaneOpen = !_rootSplitView.IsPaneOpen;
        }
    }
}
