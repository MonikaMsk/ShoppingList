using System;
using System.IO;
using MyShoppingList.Services;
using MyShoppingList.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MyShoppingList
{
    public partial class App : Application
    {
        
        private static SQLiteListStore sqLiteListStore;

        public static SQLiteListStore SqLiteListStore
        {
            get
            {
                if (sqLiteListStore == null)
                {
                    var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var path = Path.Combine(documentsPath, "List.db");
                    return sqLiteListStore;

                }

                return sqLiteListStore;
            }
        }
        
        
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPageView())
            {
                BarBackgroundColor = Color.CornflowerBlue,
                BarTextColor = Color.Azure
               
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}