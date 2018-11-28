using CustomerServiceMobile.ViewModels;

namespace CustomerServiceMobile.Utility
{
    public class ViewModelLocator
    {
        public CustomerListViewModel CustomerListViewModel
        {
            get
            {
                return AppContainer.Resolve<CustomerListViewModel>();
            }
        }

        public CustomerDetailsViewModel CustomerDetailsViewModel
        {
            get
            {
                return AppContainer.Resolve<CustomerDetailsViewModel>();
            }
        }
    }
}
