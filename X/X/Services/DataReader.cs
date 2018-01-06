using X.Interfaces;
using X.Models;
using X.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataReader))]
namespace X.Services
{
    public class DataReader : IDataReader
    {
        private readonly IJokeRepository _jokeRepository;
        private readonly IQuoteRepository _quoteRepository;

        public DataReader()
        {
            _jokeRepository = DependencyService.Get<IJokeRepository>();
            _quoteRepository = DependencyService.Get<IQuoteRepository>();
        }

        public async Task<IReadOnlyList<Joke>> GetJokes()
        {
            IReadOnlyList<Joke> jokes = await _jokeRepository.Get();
            return jokes;
        }

        public async Task<IReadOnlyList<Quote>> GetQuotes()
        {
            IReadOnlyList<Quote> quotes = await _quoteRepository.Get();
            return quotes;
        }

        public async Task<Quote> GetQuote(int id)
        {
            return await _quoteRepository.Get(id);
        }

        public async Task<Joke> GetJoke(int id)
        {
            return await _jokeRepository.Get(id);
        }
    }
}
