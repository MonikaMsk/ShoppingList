using System;
using System.IO;
using MyShoppingList.Android.Data;
using MyShoppingList.Data;
using SQLite;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb_Android))]

namespace MyShoppingList.Android.Data
{
    public class SQLiteDb_Android: ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {

            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var path = Path.Combine(documentsPath, "List.db");
            return new SQLiteAsyncConnection(path);
        }
    }
}