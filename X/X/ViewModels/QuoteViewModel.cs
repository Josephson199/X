using X.Helpers;
using X.Interfaces;
using X.Services;
using X.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class QuoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand FetchQuoteCommand { get; private set; }
        public ICommand StoreQuoteCommand { get; private set; }
        private Label _quoteLabel;
        private Label _quoteAuthorLabel;
        private readonly IRestClient _restClient;
        private readonly IPersistor _persistor;
        
        public QuoteViewModel()
        {

        }

        public QuoteViewModel(QuotePage page)
        {
            _quoteLabel = page.FindByName<Label>("QuoteLabel");
            _quoteAuthorLabel = page.FindByName<Label>("QuoteAuthorLabel");
            FetchQuoteCommand = new Command(FetchQuote);
            StoreQuoteCommand = new Command(StoreQuote);
            _restClient = DependencyService.Get<IRestClient>();
            _persistor = DependencyService.Get<IPersistor>();

        }

        private string _quoteTextColor;
        public string QuoteTextColor
        {
            get
            {

                return _quoteTextColor ?? ColorPaletteHelper.Red;
            }
            set
            {
                _quoteTextColor = value;
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

        private string _quoteAuthor;
        public string QuoteAuthor
        {
            get { return _quoteAuthor; }
            set
            {
                _quoteAuthor = $"Author: {value}";
                OnPropertyChanged();
            }

        }

        private string _quote;
        public string Quote
        {
            get { return _quote; }
            set
            {   
                _quote = value;
                CanStore = true;
                OnPropertyChanged();
            }
        }

        private async void StoreQuote()
        {
            await _persistor.StoreQuote(Quote, QuoteAuthor);
            MessagingCenter.Send(this, "StoredQuote");
            CanStore = false;
            QuoteTextColor = ColorPaletteHelper.Blue;
        }

        private async void FetchQuote()
        {
            await _quoteLabel.FadeTo(0, 250);
            await _quoteAuthorLabel.FadeTo(0, 250);

            var result = await _restClient.GetQuoteAsync();
            QuoteTextColor = ColorPaletteHelper.Red;
            Quote = result.Quote;
            QuoteAuthor = result.Author;

            await _quoteAuthorLabel.FadeTo(1, 250);
            await _quoteLabel.FadeTo(1, 250);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
