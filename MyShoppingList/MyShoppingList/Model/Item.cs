using SQLite;

namespace MyShoppingList.Model
{
    public class Item
    {
      
        
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public string Product { get; set; }
        }
    
}