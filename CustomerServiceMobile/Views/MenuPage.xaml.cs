using CustomerServiceMobile.Enums;
using CustomerServiceMobile.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerServiceMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
        RootPage _rootPage { get => Application.Current.MainPage as RootPage; }
        List<CustomerMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<CustomerMenuItem>
            {
                new CustomerMenuItem {Id = MenuItemType.List, Title="Customer list"},
                new CustomerMenuItem {Id = MenuItemType.Exit, Title="Exit" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((CustomerMenuItem)e.SelectedItem).Id;
                await _rootPage.NavigateFromMenu(id);
            };
        }
    }
}