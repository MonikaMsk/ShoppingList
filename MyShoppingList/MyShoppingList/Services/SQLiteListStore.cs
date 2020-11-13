using System.Collections.Generic;
using System.Threading.Tasks;
using MyShoppingList.Data;
using MyShoppingList.Model;
using SQLite;

namespace MyShoppingList.Services
{
    public class SQLiteListStore: IListStore

    {
        
        private SQLiteAsyncConnection _connection;

        public SQLiteListStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Item>().Wait();
        }


        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _connection.Table<Item>().ToListAsync();
           
        }

        public async Task<Item> GetItem(int id)
        {
            return await _connection.FindAsync<Item>(id);
            
        }

        public async Task AddItem(Item item)
        {
            await _connection.InsertAsync(item);
            
           
        }

        public async Task DeleteItem(Item item)
        {
            await _connection.DeleteAsync(item);
           
        }

    }
}