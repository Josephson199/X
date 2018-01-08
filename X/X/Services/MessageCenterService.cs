using X.Interfaces;
using X.Services;
using X.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(MessageCenterService))]
namespace X.Services
{
    public class MessageCenterService
    {
        private readonly IApplicationPropertiesService _applicationPropertiesService;

        public MessageCenterService()
        {
            _applicationPropertiesService = DependencyService.Get<IApplicationPropertiesService>();
        }

        public void RegisterMessages()
        {
            MessagingCenter.Subscribe<MainPage>(this, "GetTitle", (sender) =>
            {
                sender.Title = _applicationPropertiesService.GetTitle();
            });

            MessagingCenter.Subscribe<UpdateTitlePage>(this, "GetTitle", (sender) =>
            {
                sender.Title = _applicationPropertiesService.GetTitle();
            });
        }
    }
}
