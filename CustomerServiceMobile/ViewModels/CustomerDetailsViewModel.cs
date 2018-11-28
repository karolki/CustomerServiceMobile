using AutoMapper;
using CustomerServiceMobile.Const;
using CustomerServiceMobile.Contracts.Data;
using CustomerServiceMobile.Contracts.Other;
using CustomerService.DTO.Creation;
using CustomerService.DTO.Output;
using CustomerService.DTO.Update;
using CustomerServiceMobile.ViewModels.Base;
using CustomerServiceMobile.Views;
using System;
using Xamarin.Forms;

namespace CustomerServiceMobile.ViewModels
{
    public class CustomerDetailsViewModel : ViewModelBase
    {
        #region privateFields
        private CustomerUpdateDTO _customer;
        private bool _isNew;
        private Guid _id;
        #endregion

        private ICustomerDataService _customerDataService;

        public CustomerDetailsViewModel(ICustomerDataService customerDataService,
            IMessagingService messagingService, INavigationService navigationService, IToastService toastService)
            : base(messagingService, navigationService,toastService)
        {
            _customerDataService = customerDataService;

            InitCommands();

            _messagingService.Subscribe<CustomerListViewModel, CustomerDTO>
                (this, Messages.SendingCustomer, OnCustomerReceive);
        }

        public string FirstName
        {
            get => _customer.FirstName;
            set
            {
                _customer.FirstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _customer.LastName;
            set
            {
                _customer.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get => _customer.Address;
            set
            {
                _customer.Address = value;
                OnPropertyChanged();
            }
        }
        
        public string PhoneNumber
        {
            get => _customer.PhoneNumber.ToString() != "0" ? _customer.PhoneNumber.ToString() : null;
            set
            {
                _customer.PhoneNumber = int.Parse(value);
                OnPropertyChanged();
            }
        }

        public bool IsNew
        {
            get => _isNew;
            set
            {
                _isNew = value;
                OnPropertyChanged();
            }
        }

        public Command AddOrUpdateCustomerCommand { get; set; }

        private void InitCommands()
        {
            AddOrUpdateCustomerCommand = new Command(async () =>
              {
                  bool result;
                  if (IsNew)
                  {
                      var customerCreationDTO = Mapper.Map<CustomerCreationDTO>(_customer);
                      result = await _customerDataService.CreateCustomer(customerCreationDTO);
                  }
                  else
                  {
                      result = await _customerDataService.UpdateCustomer(_customer, _id);
                  }
                  if(result)
                  {
                      _toastService.ShortToast("Changes saved!");
                      await _navigationService.NavigateTo<CustomerListView>();
                  }
                  else
                  {
                      _toastService.LongToast("Problem during saving changes.");
                  }
              });
        }

        private void OnCustomerReceive(CustomerListViewModel viewModel, CustomerDTO customer)
        {
            if (customer == null)
            {
                IsNew = true;
                _customer = new CustomerUpdateDTO();
                _id = Guid.Empty;
            }
            else
            {
                IsNew = false;
                var customerUpdateDTO = Mapper.Map<CustomerUpdateDTO>(customer);
                _customer = customerUpdateDTO;
                _id = customer.Id;
            }
            OnPropertyChanged("FirstName");
            OnPropertyChanged("LastName");
            OnPropertyChanged("Address");
            OnPropertyChanged("PhoneNumber");
        }
    }
}
