
using System;
using System.IO;
using MyShoppingList.Data;
using MyShoppingList.iOS.Data;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb_iOS))]

namespace MyShoppingList.iOS.Data
{
    public class SQLiteDb_iOS: ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentsPath, "List.db");
            return new SQLiteAsyncConnection(path);
            
        }
        
    }
}