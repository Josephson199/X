using X.Helpers;
using X.Views;
using Xamarin.Forms;

namespace X
{
    public partial class App : Application
	{
		public App (string dbPath)
		{
			InitializeComponent();
            FilePathHelper.DatabaseFilePath = dbPath;
            MainPage = new NavigationPage(new MainPage());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
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
