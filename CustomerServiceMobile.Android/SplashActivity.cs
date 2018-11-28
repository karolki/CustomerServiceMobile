using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace CustomerServiceMobile.Droid
{
    [Activity(Label = "CustomerService",
        Icon = "@drawable/splash_screen",
        MainLauncher = true,
        Theme = "@style/SplashTheme",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            CallMainActivity();
        }

        private void CallMainActivity()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}