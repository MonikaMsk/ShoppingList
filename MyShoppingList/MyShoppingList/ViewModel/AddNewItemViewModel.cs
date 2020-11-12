using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MyShoppingList.Model;
using MyShoppingList.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyShoppingList.ViewModel
{
    public class AddNewItemViewModel: BaseViewModel
    {
        private IPageService _pageService;
        private IListStore _listStore;

        public Item Item { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SpeakCommand { get; set; }

        public AddNewItemViewModel(ListViewModel viewModel, IListStore listStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _listStore = listStore;
            SaveCommand = new Command(async () => await Save());
            SpeakCommand = new Command(async () => await Speak());

            Item = new Item
            {
                Id = viewModel.Id,
                Product = viewModel.Product
            };
        }

     
        private async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Item.Product))
            {
                await _pageService.DisplayAlert("Error", "Please enter the item", "Ok");
                return;
            }

            if (Item.Id == 0)
            {
                await _listStore.AddItem(Item);
               
            }
            
            await _pageService.PopAsync();
            
        }

        private async Task Speak()
        {
            var read = Item.Product;
            await TextToSpeech.SpeakAsync(read);

        }

    }
}