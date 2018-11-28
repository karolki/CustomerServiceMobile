using CustomerServiceMobile.Contracts.Other;
using CustomerServiceMobile.Enums;
using CustomerServiceMobile.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerServiceMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RootPage : MasterDetailPage
	{
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public RootPage ()
		{
			InitializeComponent ();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.List, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.List:
                        MenuPages.Add(id, new NavigationPage(new CustomerListView()));
                        break;
                    case (int)MenuItemType.Exit:
                        AppContainer.Resolve<IExitingService>().Exit();
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}