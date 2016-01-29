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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Google.Apis.Services;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HungND.SideProjects.UWP.ProTube
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private ActivitiesResource.ListRequest _activityReq;
        private ActivityListResponse _activityRes;

        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += HomePage_Loaded;

            PrevButton.IsEnabled = false;
            NextButton.IsEnabled = false;
        }

        private async void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            if (_activityReq == null)
            {
                var userCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new Uri("ms-appx:///client_id.json"),
                    new[] { YouTubeService.Scope.Youtube },
                    "user",
                    CancellationToken.None);

                var youtube = new YouTubeService(new BaseClientService.Initializer()
                {
                    //ApiKey = "AIzaSyC7enbf9xtdebb4EDHXeeqHXk2qUuLfeuc",
                    HttpClientInitializer = userCredential,
                    ApplicationName = "ProTube"
                });

                _activityReq = youtube.Activities.List("snippet,contentDetails");
                _activityReq.Home = true;
                _activityReq.MaxResults = 50;
                _activityReq.PublishedAfter = DateTime.Now.AddDays(-14);
            }

            if (_activityRes == null)
            {
                _activityRes = await _activityReq.ExecuteAsync();
                VideosList.ItemsSource = _activityRes.Items;
                NextButton.IsEnabled = true;
            }
        }

        private void PrevButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            _activityReq.PageToken = _activityRes.NextPageToken;
            _activityRes = await _activityReq.ExecuteAsync();
            VideosList.ItemsSource = _activityRes.Items;
        }
    }
}
