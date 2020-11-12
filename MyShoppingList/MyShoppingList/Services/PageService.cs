using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyShoppingList.Services
{
    public class PageService: IPageService
    {
        public async Task PushAsync(Page page)
        {
            await MainPageView.Navigation.PushAsync(page);
        }

        public async Task<Page> PopAsync()
        {
            return await MainPageView.Navigation.PopAsync();
        }
        
        public async Task DisplayAlert(string title, string message, string ok)
        {
            await MainPageView.DisplayAlert(title, message, ok);
        }
        
        private Page MainPageView
        {
            get { return Application.Current.MainPage; }
        }
    }
}