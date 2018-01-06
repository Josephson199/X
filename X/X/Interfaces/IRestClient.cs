using X.Models;
using System.Threading.Tasks;

namespace X.Interfaces
{
    public interface IRestClient
    {
        Task<string> GetJokeAsync();
        Task<QuoteData> GetQuoteAsync();
    }
}
