using System.ComponentModel;
using X.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateTitlePage : ContentPage
    {
        public UpdateTitlePage()
        {
            InitializeComponent();
            TitleEntry.TextChanged += TitleEntry_TextChanged;
            BindingContext = new UpdateTitleViewModel();
        }

        private void TitleEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Application.Current.Properties["title"] = TitleEntry.Text;
        }

    }
}