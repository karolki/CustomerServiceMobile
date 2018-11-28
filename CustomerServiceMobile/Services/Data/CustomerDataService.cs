using CustomerServiceMobile.Const;
using CustomerServiceMobile.Contracts.Data;
using CustomerService.DTO.Creation;
using CustomerService.DTO.Output;
using CustomerService.DTO.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceMobile.Services.Data
{
    public class CustomerDataService : ICustomerDataService
    {
        private Uri _baseUri;
        private IGenericRepository _genericRepository;

        public CustomerDataService(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
            _baseUri = new Uri(ApiStrings.BaseUrl);
        }

        public async Task<IEnumerable<CustomerDTO>> GetCutomers()
        {
            var _uri = new Uri(_baseUri, ApiStrings.CustomerUrl);
            var customers = await _genericRepository.GetAsync<IEnumerable<CustomerDTO>>(_uri.AbsoluteUri);
            return customers;
        }

        public async Task<bool> CreateCustomer(CustomerCreationDTO customerCreationDTO)
        {
            try
            {
                var _uri = new Uri(_baseUri, ApiStrings.CustomerUrl);
                await _genericRepository.PostAsync(_uri.AbsoluteUri, customerCreationDTO);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCustomer(CustomerUpdateDTO customerUpdateDTO,Guid id)
        {
            try
            {
                var _uri = new Uri(_baseUri, ApiStrings.CustomerUrl+$"/{id}");
                await _genericRepository.PutAsync(_uri.AbsoluteUri, customerUpdateDTO);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCustomer(Guid id)
        {
            try
            {
                var _uri = new Uri(_baseUri, ApiStrings.CustomerUrl + $"/{id}");
                await _genericRepository.DeleteAsync(_uri.AbsoluteUri);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
