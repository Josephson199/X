using X.Interfaces;
using X.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ApplicationPropertiesService))]
namespace X.Services
{
    public class ApplicationPropertiesService : IApplicationPropertiesService
    {
        public string GetTitle()
        {
            var titleExists = Application.Current.Properties.TryGetValue("title", out object title);
            return titleExists ? title as string: "Deafult Title";
        }

        public void SetTitle(string title)
        {
            Application.Current.Properties["title"] = title;
        }
    }
}
