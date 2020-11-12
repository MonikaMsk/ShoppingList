using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyShoppingList.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task<Page> PopAsync();
        Task DisplayAlert(string title, string message, string ok);
    }
    }
