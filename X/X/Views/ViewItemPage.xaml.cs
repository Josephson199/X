using X.Models;
using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewItemPage : ContentPage
	{
		public ViewItemPage (DataDisplayModel dataDisplayModel)
		{
			InitializeComponent ();
            MessagingCenter.Subscribe<ViewItemViewModel>(this, "ItemDeleted", (sender) =>
            {
                DisplayAlert("Alert", "Item deleted!", "OK");
            });
            BindingContext = new ViewItemViewModel(dataDisplayModel, Navigation); 
        }
	}
}