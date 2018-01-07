using System.Threading.Tasks;

namespace X.Interfaces
{
    public interface IDataManipulator
    {
        Task<int> DeleteQuote(int id);
        Task<int> DeleteJoke(int id);
    }
}
