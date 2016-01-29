using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HungND.SideProjects.UWP.ProTube
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<PaneMenuItem> NavLinks { get; } = new ObservableCollection<PaneMenuItem>();
        public PaneToggleCommand PaneToggleCommand { get; }

        public MainPage()
        {
            this.InitializeComponent();

            NavLinks.Add(new PaneMenuItem("Home", new SymbolIcon(Symbol.Home), new NavigationCommand<HomePage>(rootFrame)));
            NavLinks.Add(new PaneMenuItem("My Channel", new SymbolIcon(Symbol.Contact2), new NavigationCommand<MyChannelPage>(rootFrame)));
            NavLinks.Add(new PaneMenuItem("Trending", new FontIcon() { Glyph = "" }, new NavigationCommand<TrendingPage>(rootFrame)));
            NavLinks.Add(new PaneMenuItem("Subscriptions", new FontIcon() { Glyph = "" }, null));
            NavLinks.Add(new PaneMenuItem("History", new FontIcon() { Glyph = "" }, null));
            NavLinks.Add(new PaneMenuItem("Watch Later", new FontIcon() { Glyph = "" }, null));
            NavLinks.Add(new PaneMenuItem("Liked Videos", new SymbolIcon(Symbol.OutlineStar) /*new FontIcon() { Glyph = "" }*/, null));
            NavLinks.Add(new PaneMenuItem("Library", new FontIcon() { Glyph = "" }, null));
            NavLinks.Add(new PaneMenuItem("Search", new SymbolIcon(Symbol.Find), null));

            PaneToggleCommand = new PaneToggleCommand(rootSplitView);
        }

        private void NavLinksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var command = e.ClickedItem as Command;
            if (command != null)
                command.Execute(null);
        }

        private void NavLinksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var item = e.AddedItems[0] as PaneMenuItem;
                if (item != null)
                    item.ExecuteCommand();
            }
        }
    }
}
