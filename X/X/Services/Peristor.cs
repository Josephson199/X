using System.Threading.Tasks;
using X.Interfaces;
using X.Models;
using X.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Peristor))]
namespace X.Services
{
    public class Peristor : IPersistor
    {
        private readonly IJokeRepository _jokeRepository;
        private readonly IQuoteRepository _quoteRepository;

        public Peristor()
        {
            _jokeRepository = DependencyService.Get<IJokeRepository>();
            _quoteRepository = DependencyService.Get<IQuoteRepository>();            
        }

        public async Task StoreJoke(string jokeBody)
        {
            if(string.IsNullOrWhiteSpace(jokeBody))
            {
                return;
            }

            var jokeModel = new Joke
            {
                Body = jokeBody
            };

            await _jokeRepository.Insert(jokeModel);    

        }

        public async Task StoreQuote(string quoteBody, string quoteAuthor)
        {
            if(string.IsNullOrWhiteSpace(quoteBody) || string.IsNullOrWhiteSpace(quoteAuthor))
            {
                return;
            }

            var quote = new Quote
            {
                Body = quoteBody,
                Author = quoteAuthor
            };

            await _quoteRepository.Insert(quote);
        }
    }
}
