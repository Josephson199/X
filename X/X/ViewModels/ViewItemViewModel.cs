using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using X.Helpers;
using X.Interfaces;
using X.Models;
using X.Services;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class ViewItemViewModel : INotifyPropertyChanged
    {
        public NotifyTaskCompletion<DataDisplayModel> DataDisplayModel { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IDataReader _dataReader;
        private readonly IDataManipulator _dataManipulator;
        private readonly INavigation _navigation;

        public ICommand DeleteItemCommand { get; private set; }

        public ViewItemViewModel(DataDisplayModel dataDisplayModel, INavigation navigation)
        {
            _dataReader = DependencyService.Get<IDataReader>();
            _dataManipulator = DependencyService.Get<IDataManipulator>();
            _navigation = navigation;
            DeleteItemCommand = new Command(DeleteAction);
            DataDisplayModel = new NotifyTaskCompletion<DataDisplayModel>(LoadDataAsync(dataDisplayModel));           
        }

        private async void DeleteAction()
        {
            if(DataDisplayModel.Result.DataType == DataType.Joke)
            {
                await _dataManipulator.DeleteJoke(DataDisplayModel.Result.Id);
            }
            else
            {
                await _dataManipulator.DeleteQuote(DataDisplayModel.Result.Id);
            }

            MessagingCenter.Send(this, "ItemDeleted");
            //this._navigation.RemovePage(this._navigation.NavigationStack[this._navigation.NavigationStack.Count - 1]);
            //await _navigation.PopAsync();
            await _navigation.PopToRootAsync();

        }

        async Task<DataDisplayModel> LoadDataAsync(DataDisplayModel dataDisplayModel)
        {
            var result = new DataDisplayModel();
            if (dataDisplayModel.DataType == DataType.Joke)
            {
                var joke = await _dataReader.GetJoke(dataDisplayModel.Id);
                result.Body = joke.Body;
                result.InsertDate = joke.InsertDate;
                result.Id = joke.Id;
                result.TextColor = ColorPaletteHelper.Blue;
                result.DataType = DataType.Joke;
                
            }

            else if (dataDisplayModel.DataType == DataType.Quote)
            {
                var quote = await _dataReader.GetQuote(dataDisplayModel.Id);
                result.Body = quote.Body;
                result.InsertDate = quote.InsertDate;
                result.Id = quote.Id;
                result.TextColor = ColorPaletteHelper.Green;
                result.Author = quote.Author;
                result.DataType = DataType.Quote;
            }

            return result;

        }

        public ViewItemViewModel()
        {
            _dataReader = DependencyService.Get<IDataReader>();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
