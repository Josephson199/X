using X.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace X.Interfaces
{
    public interface IQuoteRepository
    {
        Task<Quote> Get(int id);
        Task Insert(Quote quote);
        Task<List<Quote>> Get();
        Task<int> Delete(int id);
        Task<int> Delete(Quote quote);
    }
}
