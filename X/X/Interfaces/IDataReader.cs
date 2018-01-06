using X.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace X.Interfaces
{
    public interface IDataReader
    {
        Task<IReadOnlyList<Joke>> GetJokes();
        Task<IReadOnlyList<Quote>> GetQuotes();
        Task<Quote> GetQuote(int id);
        Task<Joke> GetJoke(int id);
    }
}
