using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuotePage : ContentPage
	{
		public QuotePage ()
		{
            InitializeComponent();
            MessagingCenter.Subscribe<QuoteViewModel>(this, "StoredQuote", (sender) =>
            {
                DisplayAlert("Alert", "Quote has been stored.", "OK");
            });
            //btnFetchQuote.BackgroundColor = Color.FromHex(ColorPaletteHelper.Green);
            //btnStoreQuote.BackgroundColor = Color.FromHex(ColorPaletteHelper.Yellow);
            BindingContext = new QuoteViewModel(this);
        }
	}
}