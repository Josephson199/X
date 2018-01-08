using System.ComponentModel;
using System.Runtime.CompilerServices;
using X.Interfaces;
using X.Views;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IApplicationPropertiesService _applicationPropertiesService;
        public string Title { get; set; }
       
        public MainViewModel()
        {
            _applicationPropertiesService = DependencyService.Get<IApplicationPropertiesService>();

            //MessagingCenter.Subscribe<MainPage>(this, "GetTitle", (sender) =>
            //{
            //    this.Title = _applicationPropertiesService.GetTitle();

            //});

            this.Title = _applicationPropertiesService.GetTitle();

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
        
    }
}
