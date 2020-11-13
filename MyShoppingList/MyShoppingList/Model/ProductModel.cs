using MyShoppingList.ViewModel;

namespace MyShoppingList.Model
{
    public class ListViewModel: BaseViewModel
    {
        public int Id { get; set; }

        public ListViewModel()
        {

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