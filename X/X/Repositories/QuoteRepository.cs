using X.Helpers;
using X.Interfaces;
using X.Models;
using X.Repositories;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(QuoteRepository))]
namespace X.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly SQLiteAsyncConnection _conn;

        public QuoteRepository()
        {
            _conn = new SQLiteAsyncConnection(FilePathHelper.DatabaseFilePath);
            _conn.CreateTableAsync<Quote>().Wait();
        }

        public async Task<Quote> Get(int id)
        {
            return await _conn.FindAsync<Quote>(id);
        }

        public async Task Insert(Quote quote)
        {
            await _conn.InsertAsync(quote);
        }

        public async Task<List<Quote>> Get()
        {
            return await _conn.Table<Quote>().ToListAsync();
        }

        public async Task<int> Delete(int id)
        {
            var quote = await Get(id);
            return await _conn.DeleteAsync(quote);
        }

        public async Task<int> Delete(Quote quote)
        {
            return await _conn.DeleteAsync(quote);
        }
    }
}
