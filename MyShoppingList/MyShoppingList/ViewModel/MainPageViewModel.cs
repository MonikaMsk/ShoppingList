using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyShoppingList.Model;
using MyShoppingList.Services;
using MyShoppingList.View;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyShoppingList.ViewModel
{
    public class MainPageViewModel: BaseViewModel
    {
      
        private IListStore _listStore;
        private IPageService _pageService;
        private Item _item;
        private bool _isDataLoaded;
      
    //   private bool isBusy;

       public ObservableCollection<Item> Items { get; private set; }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; set; }

        public ICommand SpeakItemCommand { get; set; }
        

        public MainPageViewModel(IListStore listStore, IPageService pageService)
        {
            Items = new ObservableCollection<Item>();
            _listStore = listStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddItemCommand = new Command(async () => await AddItem()); 
           RemoveItemCommand = new Command<Item>(async c => await Delete(c));
            SpeakItemCommand = new Command<ListViewModel>(async c => await Speak(c));

        }
        
        private async Task Speak(ListViewModel listViewModel)
        {
            var item = await _listStore.GetItem(listViewModel.Id);
            var read = item.Product;
            await TextToSpeech.SpeakAsync(read);
        }
        
        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var items = await _listStore.GetItemsAsync();
            Items.Clear();
            foreach (var item in items)
                Items.Add(item);
            _isDataLoaded = false;
        }
   
        // Items.Contains -> checks if items exist
        
        private async Task AddItem()
        {
            await _pageService.PushAsync(new AddNewItemPage(new ListViewModel()));
        }

       private async Task Delete(Item item)
       {
           Items.Remove(item);
           //  Items.Remove(listViewModel);
           var prod = await _listStore.GetItem(item.Id);

           await _listStore.DeleteItem(prod);

       } 
        
    }
}