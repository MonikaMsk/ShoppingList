using MyShoppingList.Model;

namespace MyShoppingList.ViewModel
{
    public class ListViewModel: BaseViewModel
    {
        public int Id { get; set; }

        public ListViewModel()
        {

        }
        public ListViewModel(Item item)
        {
            Id = item.Id;
            _product = item.Product;
        }

        private string _product;

        public string Product
        {
            get { return _product;}
            set
            {
                SetValue(ref _product, value);
                OnPropertyChanged(nameof(Product));
            }
        }
    }
}