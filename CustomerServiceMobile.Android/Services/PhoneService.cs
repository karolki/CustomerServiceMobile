using Android.App;
using Android.Content;
using Android.Net;
using CustomerServiceMobile.Android.Services;
using CustomerServiceMobile.Contracts.Other;
using System.Threading.Tasks;
using Android.Widget;

[assembly: Xamarin.Forms.Dependency(typeof(PhoneService))]
namespace CustomerServiceMobile.Android.Services
{
    public class PhoneService : IPhoneService
    {
        public void MakeCall(int phoneNumber)
        {
            var phone = new PhoneCall.Forms.Plugin.Droid.PhoneCallImplementation();
            phone.MakeQuickCall(phoneNumber.ToString());
        }
    }
}