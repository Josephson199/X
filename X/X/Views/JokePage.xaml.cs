using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JokePage : ContentPage
	{
		public JokePage ()
		{
            InitializeComponent();

            MessagingCenter.Subscribe<JokeViewModel>(this, "StoredJoke", (sender) =>
            {
                DisplayAlert("Alert", "Joke has been stored.", "OK");
            });
            //btnFetchJoke.BackgroundColor = Color.FromHex(ColorPaletteHelper.Green);
            //btnStoreJoke.BackgroundColor = Color.FromHex(ColorPaletteHelper.Yellow);

            BindingContext = new JokeViewModel(this);
        }
	}
}