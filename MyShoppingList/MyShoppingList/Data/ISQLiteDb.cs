using SQLite;

namespace MyShoppingList.Data
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}