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

        //  private bool _isDataLoaded;
      
       private bool isBusy;

       public ObservableCollection<ListViewModel> Items { get; private set; }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; set; }

        public ICommand SpeakItemCommand { get; set; }


        public MainPageViewModel()
        {
            MessagingCenter.Subscribe<AddNewItemViewModel, Item>
                (this, Event.ItemAdded, OnItemAdded);
        }
        
        private void OnItemAdded(AddNewItemViewModel source, Item item)
        {
            Items.Add(new ListViewModel(item));
        }

        
        

        public MainPageViewModel(IListStore listStore, IPageService pageService)
        {
            Items = new ObservableCollection<ListViewModel>();
            _listStore = listStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddItemCommand = new Command(async () => await AddItem()); 
            RemoveItemCommand = new Command<ListViewModel>(async c => await Delete(c));
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
         // if (_isDataLoaded)
           //  return;

             //_isDataLoaded = true;
           isBusy = true;
            var items = await _listStore.GetItemAsync();
            foreach (var item in items)
            {
                Items.Add(new ListViewModel(item));
            }

          //  isBusy = false;
        }
   
        
        private async Task AddItem()
        {
            await _pageService.PushAsync(new AddNewItemPage(new ListViewModel()));
        }

        private async Task Delete(ListViewModel listViewModel)
        {
            Items.Remove(listViewModel);

            var item = await _listStore.GetItem(listViewModel.Id);
            await _listStore.DeleteItem(item);
          
        }
        
    }
}