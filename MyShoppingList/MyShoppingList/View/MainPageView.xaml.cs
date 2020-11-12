using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShoppingList.Data;
using MyShoppingList.Services;
using MyShoppingList.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyShoppingList.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageView : ContentPage
    {
        
        public MainPageViewModel ViewModel
        {
            get => BindingContext as MainPageViewModel;
            set => BindingContext = value;
        } 
        public MainPageView()
        {
            
            var listStore = new SQLiteListStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            ViewModel = new MainPageViewModel(listStore, pageService);
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadDataCommand.Execute(null);
           
        }
      
    }
}