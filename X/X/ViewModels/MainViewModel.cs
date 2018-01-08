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

        private string _title;
        public string Title
        {
            get
            {

                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _applicationPropertiesService = DependencyService.Get<IApplicationPropertiesService>();

            MessagingCenter.Subscribe<MainPage>(this, "UpdateTitle", (sender) =>
            {
                SetTitle();
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetTitle()
        {
            this.Title = _applicationPropertiesService.GetTitle();
        }
        
    }
}
