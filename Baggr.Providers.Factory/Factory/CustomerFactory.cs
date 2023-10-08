using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.Factory
{
    public class CustomerFactory : ICustomerFactory
    {
        private readonly ICustomerManager _CustomerManager;
        private readonly IMapper _mapper;
        public CustomerFactory(ICustomerManager CustomerManager, IMapper mapper)
        {
            _CustomerManager = CustomerManager;
            _mapper = mapper;
        }
        public async Task<ResultModel<CustomerDTO>> CreateCustomer(CustomerDTO CustomerDTO, string merchantKey)
        {
            var result = await _CustomerManager.CreateCustomer(CustomerDTO, merchantKey);
            return new ResultModel<CustomerDTO>(result.IsSuccess, result.StatusMessage, _mapper.Map<Customer, CustomerDTO>(result.Result));
        }
        public async Task<ResultModel<CustomersPageDTO>> GetCustomers(CustomerFilterDTO CustomerFilterDTO)
        {
            var result = await _CustomerManager.GetCustomers(CustomerFilterDTO);
            return result;
        }
        public async Task<ResultModel<CustomerDTO>> UpdateCustomer(CustomerDTO CustomerDTO, string merchantKey)
        {
            var result = await _CustomerManager.UpdateCustomer(CustomerDTO, merchantKey);
            return new ResultModel<CustomerDTO>(result.IsSuccess, result.StatusMessage);
        }
        public async Task<ResultModel<CustomerDTO>> DeleteCustomer(string CustomerKey)
        {
            var result = await _CustomerManager.DeleteCustomer(CustomerKey);
            return new ResultModel<CustomerDTO>(result.IsSuccess, result.StatusMessage);
        }
    }
}
