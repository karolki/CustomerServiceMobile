using CustomerServiceMobile.Const;
using CustomerServiceMobile.Contracts.Data;
using CustomerServiceMobile.Contracts.Other;
using CustomerService.DTO.Output;
using CustomerServiceMobile.ViewModels.Base;
using CustomerServiceMobile.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace CustomerServiceMobile.ViewModels
{
    public class CustomerListViewModel : ViewModelBase
    {
        #region private
        private ObservableCollection<CustomerDTO> _customerCollection;
        #endregion

        private ICustomerDataService _customerDataService;
        private IPhoneService _phoneService;

        public CustomerListViewModel(ICustomerDataService customerDataService,IMessagingService messagingService,
            INavigationService navigationService, IToastService toastService,IPhoneService phoneService)
            :base(messagingService,navigationService,toastService)
        {
            _customerDataService = customerDataService;
            _phoneService = phoneService;

            InitCommands();

            OnLoad();
        }

        public ObservableCollection<CustomerDTO> CustomerCollection
        {
            get => _customerCollection;
            set
            {
                _customerCollection = value;
                OnPropertyChanged();
            }
        }

        public Command<ItemTappedEventArgs> ItemSelectedCommand { get; private set; }
        public Command NewItemCreationCommand { get; private set; }
        public Command LoadCommand { get; private set; }
        public Command<int> PhoneCommand { get; private set; }
        public Command<Guid> DeleteCustomerCommand { get; private set; }

        private void InitCommands()
        {
            ItemSelectedCommand = new Command<ItemTappedEventArgs>(OnItemSelected);
            NewItemCreationCommand = new Command(OnNewItemCreation);
            LoadCommand = new Command(OnLoad);
            PhoneCommand = new Command<int>(OnPhone);
            DeleteCustomerCommand = new Command<Guid>(OnDeleteCustomer);
        }

        private async void OnDeleteCustomer(Guid id)
        {
            if (await _toastService.AskForConfirmation("Do you want to delete selected customer?"))
            {
                await _customerDataService.DeleteCustomer(id);
                CustomerCollection.Remove(CustomerCollection.Where(x => x.Id == id).SingleOrDefault());
            }
        }

        private void OnPhone(int phoneNumber)
        {
            _phoneService.MakeCall(phoneNumber);
        }

        private void OnNewItemCreation()
        {
            _messagingService.Send<CustomerListViewModel,CustomerDTO>(this, Messages.SendingCustomer, null);
            _navigationService.NavigateTo<CustomerDetailsView>();
        }

        private void OnItemSelected(ItemTappedEventArgs obj)
        {
            _messagingService.Send(this, Messages.SendingCustomer, obj.Item as CustomerDTO);
            _navigationService.NavigateTo<CustomerDetailsView>();
        }
      
        private async void OnLoad()
        {
            CustomerCollection = new ObservableCollection<CustomerDTO>
                (await _customerDataService.GetCutomers());
        }
    }
}
