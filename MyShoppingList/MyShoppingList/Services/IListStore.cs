using System.Collections.Generic;
using System.Threading.Tasks;
using MyShoppingList.Model;

namespace MyShoppingList.Services
{
    public interface IListStore
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItem(int id);
        Task AddItem(Item item);
        Task DeleteItem(Item item);
    }
}