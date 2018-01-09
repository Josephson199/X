using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using X.Helpers;
using X.Services;
using X.Views;
using Xamarin.Forms;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;

namespace X
{
    public partial class App : Application
	{
		public App (string dbPath)
		{
			InitializeComponent();
            FilePathHelper.DatabaseFilePath = dbPath;
            DependencyService.Get<MessageCenterService>().RegisterMessages();
            MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            AppCenter.Start("android=92f21cb8-2458-4719-b945-85f92cdd328c;" + "uwp={Your UWP App secret here};" +
                   "ios={Your iOS App secret here}",
                   typeof(Analytics), typeof(Crashes));
            Analytics.TrackEvent("App.OnStart", new Dictionary<string, string> { { "Start up", $"{nameof(App)}" }, { "Test", "Test" } });
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}       
	}
}
