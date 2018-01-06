using X.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace X.Interfaces
{
    public interface IJokeRepository
    {
        Task<Joke> Get(int id);
        Task Insert(Joke joke);
        Task<List<Joke>> Get();
        Task<int> Delete(int id);
        Task<int> Delete(Joke joke);
    }
}
