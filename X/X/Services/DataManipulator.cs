using System.Threading.Tasks;
using X.Interfaces;
using X.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataManipulator))]
namespace X.Services
{
    public class DataManipulator : IDataManipulator
    {
        private readonly IJokeRepository _jokeRepository;
        private readonly IQuoteRepository _quoteRepository;

        public DataManipulator()
        {
            _jokeRepository = DependencyService.Get<IJokeRepository>();
            _quoteRepository = DependencyService.Get<IQuoteRepository>();
        }

        public async Task<int> DeleteJoke(int id)
        {
            return await _jokeRepository.Delete(id);
        }

        public async Task<int> DeleteQuote(int id)
        {
            return await _quoteRepository.Delete(id);
        }
    }
}
