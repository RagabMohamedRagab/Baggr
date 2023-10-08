using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.IFactory
{
    public interface ICustomerFactory
    {
        Task<ResultModel<CustomerDTO>> CreateCustomer(CustomerDTO CustomerDTO, string merchantKey);
        Task<ResultModel<CustomersPageDTO>> GetCustomers(CustomerFilterDTO CustomerFilterDTO);
        Task<ResultModel<CustomerDTO>> UpdateCustomer(CustomerDTO CustomerDTO, string merchantKey);
        Task<ResultModel<CustomerDTO>> DeleteCustomer(string CustomerKey);
    }
}
