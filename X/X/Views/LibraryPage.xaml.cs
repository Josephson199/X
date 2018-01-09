using System;
using X.Models;
using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LibraryPage : ContentPage
	{
		public LibraryPage ()
		{
			InitializeComponent ();
            BindingContext = new LibraryViewModel();
            ListView.ItemSelected += NavigateToItem;
        }

        private async void NavigateToItem(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new ViewItemPage((DataDisplayModel)ListView.SelectedItem));
        }

     

    }
}