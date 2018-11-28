using CustomerServiceMobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerServiceMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerListView : ContentPage
    {
        public CustomerListView()
        {
            InitializeComponent();
            Appearing += CustomerListView_Appearing;
        }

        private void CustomerListView_Appearing(object sender, EventArgs e)
        {
            (BindingContext as CustomerListViewModel).LoadCommand.Execute(null);
        }
    }
}
