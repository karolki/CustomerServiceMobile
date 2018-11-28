using CustomerService.DTO.Creation;
using CustomerService.DTO.Output;
using CustomerService.DTO.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceMobile.Contracts.Data
{
    public interface ICustomerDataService
    {
        Task<IEnumerable<CustomerDTO>> GetCutomers();
        Task<bool> CreateCustomer(CustomerCreationDTO customerCreationDTO);
        Task<bool> UpdateCustomer(CustomerUpdateDTO customerUpdateDTO,Guid id);
        Task<bool> DeleteCustomer(Guid id);
    }
}
