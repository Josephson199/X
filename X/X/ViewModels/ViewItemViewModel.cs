using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using X.Interfaces;
using X.Services;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class ViewItemViewModel : INotifyPropertyChanged
    {
        public NotifyTaskCompletion<DataDisplayModel> DataDisplayModel { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IDataReader _dataReader; 

        public ViewItemViewModel(DataDisplayModel dataDisplayModel)
        {
            _dataReader = DependencyService.Get<IDataReader>();
            DataDisplayModel = new NotifyTaskCompletion<DataDisplayModel>(LoadDataAsync(dataDisplayModel));
           
        }

        async Task<DataDisplayModel> LoadDataAsync(DataDisplayModel dataDisplayModel)
        {
            var result = new DataDisplayModel();
            if (dataDisplayModel.DataType == DataType.Joke)
            {
                var joke = await _dataReader.GetJoke(dataDisplayModel.Id);
                result.Body = joke.Body;                
            }

            else if (dataDisplayModel.DataType == DataType.Quote)
            {
                var quote = await _dataReader.GetQuote(dataDisplayModel.Id);
                result.Body = quote.Body;
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
