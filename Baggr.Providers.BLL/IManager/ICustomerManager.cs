using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.IManager
{
    public interface ICustomerManager
    {
        Task<ResultModel<Customer>> CreateCustomer(CustomerDTO CustomerDTO, string merchantKey);
        Task<ResultModel<Customer>> UpdateCustomer(CustomerDTO CustomerDTO, string merchantKey);
        Task<ResultModel<Customer>> DeleteCustomer(string CustomerKey);
        Task<ResultModel<CustomersPageDTO>> GetCustomers(CustomerFilterDTO CustomerFilterDTO);
        Task CreateShipmentCustomers(ShipmentBulkDTO shipmentBulkDTO);
    }
}
