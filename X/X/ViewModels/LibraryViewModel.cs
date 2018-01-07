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
using X.Models;

namespace X.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IDataReader _dataReader;
      
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

   
}
