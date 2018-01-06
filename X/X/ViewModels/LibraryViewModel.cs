using X.Helpers;
using X.Interfaces;
using X.Services;
using X.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IDataReader _dataReader;
        //public INavigation Navigation { get; set; }

        //private DataDisplayModel _selectedItem;
        //public DataDisplayModel SelectedItem { get { return _selectedItem; }
        //    set
        //    {
        //        _selectedItem = value;
        //        if (_selectedItem == null)
        //            return;

        //        //Execute(_selectedItem);

        //        SelectedItem = null;
        //    }
        //}

        //private async void Execute(DataDisplayModel selectItem)
        //{
        //    //new ViewItemPage(selectItem)
        //    await this.Navigation.PushModalAsync(new ViewItemPage(selectItem));
        //}

        public NotifyTaskCompletion<List<DataDisplayModel>> DataDisplayModels { get; private set; }          

        public LibraryViewModel()
        {
            _dataReader = DependencyService.Get<IDataReader>();           
            DataDisplayModels = new NotifyTaskCompletion<List<DataDisplayModel>>(LoadDataAsync());           
        }      

        async Task<List<DataDisplayModel>> LoadDataAsync()
        {
            var list = new List<DataDisplayModel>();
            var jokes = await _dataReader.GetJokes();
            foreach (var joke in jokes)
            {
                var displayModel = new DataDisplayModel
                {
                    DataType = DataType.Joke,
                    Body = $"{joke.Body} - Saved: {joke.InsertDate.ToLongDateString()}",
                    Id = joke.Id,
                    InsertDate = joke.InsertDate,
                    BgColor = ColorPaletteHelper.Blue
                };

                list.Add(displayModel);

            }

            var quotes = await _dataReader.GetQuotes();
            foreach (var quote in quotes)
            {
                    var displayModel = new DataDisplayModel
                    {
                        DataType = DataType.Quote,
                        Body = $"{quote.Body} - Saved: {quote.InsertDate.ToLongDateString()}",
                        Id = quote.Id,
                        InsertDate = quote.InsertDate,
                        BgColor = ColorPaletteHelper.Green
                    };

                list.Add(displayModel);
            }

            list = list.OrderByDescending(d => d.InsertDate).ToList();

            return list;
        }


       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class DataDisplayModel
    {
        public int Id { get; set; }
        public DataType DataType { get; set; }
        public string Body { get; set; }
        public DateTime InsertDate { get; set; }
        public string BgColor { get; set; }
    }

    public enum DataType
    {
        Joke,
        Quote
    }
}
