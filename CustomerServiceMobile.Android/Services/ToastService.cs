using Android.App;
using Android.Widget;
using CustomerServiceMobile.Android.Services;
using CustomerServiceMobile.Contracts.Other;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ToastService))]
namespace CustomerServiceMobile.Android.Services
{
    public class ToastService : IToastService
    {
        public Task<bool> AskForConfirmation(string message)
        {
            return App.Current.MainPage.DisplayAlert("Are you sure?", message, "YES", "NO");
        }

        public void LongToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortToast(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}