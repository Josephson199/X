using X.Helpers;
using X.Interfaces;
using X.Models;
using X.Repositories;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(JokeRepository))]
namespace X.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        private readonly SQLiteAsyncConnection _conn;

        public JokeRepository()
        {
            _conn = new SQLiteAsyncConnection(FilePathHelper.DatabaseFilePath);
            _conn.CreateTableAsync<Joke>().Wait();     

        }

        public async Task<Joke> Get(int id)
        {
            return await _conn.FindAsync<Joke>(id);
        }

        public async Task Insert(Joke joke)
        {
            await _conn.InsertAsync(joke);
        }

        public async Task<List<Joke>> Get()
        {
            return await _conn.Table<Joke>().ToListAsync();
        }

        public async Task<int> Delete(int id)
        {
            var joke = await Get(id);
            return await _conn.DeleteAsync(joke);
        }

        public async Task<int> Delete(Joke joke)
        {
           return await _conn.DeleteAsync(joke);
        }
        
    }
}
