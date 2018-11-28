using CustomerServiceMobile.Contracts.Other;
using CustomerServiceMobile.ViewModels.Base;
using CustomerServiceMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerServiceMobile.Services.Other
{
    public class NavigationService : INavigationService
    {
        NavigationPage NavigationPage => (Application.Current.MainPage as RootPage).Detail as NavigationPage;

        public async Task NavigateTo<T>() where T : ContentPage
        {
            if(typeof(T) == typeof(CustomerDetailsView) 
                && !(NavigationPage.CurrentPage is CustomerDetailsView))
            {
                await NavigationPage.PushAsync(new CustomerDetailsView());
            }
            else if (typeof(T) == typeof(CustomerListView))
            {
                await NavigationPage.PopToRootAsync();
            }
        }
    }
}
