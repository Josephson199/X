using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
            InitializeComponent();
            BindingContext = new MainViewModel();
            BtnNavigateToQuotes.Clicked += NavigateToQoutes;
            BtnNavigateToJokes.Clicked += NavigateToJokes;
            BtnNavigateToLibrary.Clicked += NavigateToLibrary;

        }

        private void NavigateToLibrary(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new LibraryPage());
        }

        private void NavigateToJokes(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JokePage());
        }

        private void NavigateToQoutes(object sender, EventArgs e)
        {
           // Navigation.PushAsync(new QuotePage());
        }
    }
}