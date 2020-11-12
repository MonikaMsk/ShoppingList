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
    public partial class AddNewItemPage : ContentPage
    {
        public AddNewItemPage(ListViewModel viewModel )
        {
            var listStore = new SQLiteListStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            BindingContext = new AddNewItemViewModel(viewModel ?? new ListViewModel(), listStore, pageService);
            InitializeComponent();
        }
    }
}