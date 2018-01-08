using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using X.Interfaces;
using X.Views;
using Xamarin.Forms;

namespace X.ViewModels
{
    public class UpdateTitleViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IApplicationPropertiesService _applicationPropertiesService;
        //public ICommand UpdateTitleCommand { get; private set; }

        public UpdateTitleViewModel()
        {
            _applicationPropertiesService = DependencyService.Get<IApplicationPropertiesService>();
            //UpdateTitleCommand = new Command(UpdateTitle);
            this.Title = _applicationPropertiesService.GetTitle();           
        }

        //private void UpdateTitle()
        //{
        //    _applicationPropertiesService.SetTitle(this.Title);
        //}

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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
