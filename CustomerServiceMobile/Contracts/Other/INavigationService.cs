using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerServiceMobile.Contracts.Other
{
    public interface INavigationService
    {
        Task NavigateTo<T>() where T : ContentPage;
    }
}
