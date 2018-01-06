using System.Threading.Tasks;

namespace X.Interfaces
{
    public interface IPersistor
    {
        Task StoreJoke(string joke);
        Task StoreQuote(string quote, string quoteAuthor);
    }
}
