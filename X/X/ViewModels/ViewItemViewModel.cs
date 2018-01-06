using System.ComponentModel;
using System.Runtime.CompilerServices;
using X.Interfaces;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class ViewItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IDataReader _dataReader;
        

        //public IDataItem DataItem { get; set; }


        public ViewItemViewModel(DataDisplayModel dataDisplayModel)
        {
            //_dataReader = DependencyService.Get<IDataReader>();

            //if(dataDisplayModel.DataType == DataType.Joke)
            //{
            //    DataItem = _dataReader.GetJoke(dataDisplayModel.Id).Result;
            //}

            //else if (dataDisplayModel.DataType == DataType.Quote)
            //{
            //    DataItem = _dataReader.GetQuote(dataDisplayModel.Id).Result;
            //}
        }

        public ViewItemViewModel()
        {

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
