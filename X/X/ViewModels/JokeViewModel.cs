using X.Helpers;
using X.Interfaces;
using X.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class JokeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand FetchJokeCommand { get; private set; }
        public ICommand StoreJokeCommand { get; private set; }
        private Label _jokeLabel;
        private readonly IRestClient _restClient;
        private readonly IPersistor _persistor;

        public JokeViewModel()
        {

        }

        public JokeViewModel(JokePage page)
        {
            FetchJokeCommand = new Command(FetchJoke);
            StoreJokeCommand = new Command(StoreJoke);
            _jokeLabel = page.FindByName<Label>("LabelJoke");
            _restClient = DependencyService.Get<IRestClient>();
            _persistor = DependencyService.Get<IPersistor>();
            
        }

        private string _jokeTextColor;
        public string JokeTextColor
        {
            get
            {

                return _jokeTextColor ?? ColorPaletteHelper.Red;
            }
            set
            {
                _jokeTextColor = value;
                OnPropertyChanged();
            }
        }

        private bool _canStore;
        public bool CanStore
        {
            get
            {
                return _canStore;
            }
            set
            {
                _canStore = value;
                OnPropertyChanged();
            }
        }

        private string _joke;       

        public string Joke
        {
            get { return _joke; }
            set
            {
                _joke = value;                
                CanStore = true;                
                OnPropertyChanged();
            }
        }


        private async void StoreJoke()
        {
            await _persistor.StoreJoke(Joke);            
            MessagingCenter.Send(this, "StoredJoke");
            CanStore = false;
            JokeTextColor = ColorPaletteHelper.Blue;
        }


        async void FetchJoke()
        {
            if (Joke != null)
            {
                await _jokeLabel.FadeTo(0, 250);
            }

            Joke = await _restClient.GetJokeAsync();
            JokeTextColor = ColorPaletteHelper.Red;
            await _jokeLabel.FadeTo(1, 250);

        }



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
