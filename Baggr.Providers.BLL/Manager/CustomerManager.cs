using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.Manager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IProvidersRepository<Customer> _CustomersRepository;
        private readonly IMapper _mapper;
        public CustomerManager(IProvidersRepository<Customer> CustomersRepository, IMapper mapper)
        {
            _CustomersRepository = CustomersRepository;
            _mapper = mapper;
        }
        public async Task<ResultModel<Customer>> CreateCustomer(CustomerDTO CustomerDTO, string merchantKey)
        {
            var Customers = _CustomersRepository.GetAll()
                .Where(p => p.MerchantKey == merchantKey && CustomerDTO.PhoneNumber == p.PhoneNumber);

            if (Customers.Any())
                return new ResultModel<Customer>(false, StatusMessage.Conflict);

            var Customer = _mapper.Map<CustomerDTO, Customer>(CustomerDTO);
            Customer.MerchantKey = merchantKey;
            Customer.Key = Guid.NewGuid().ToString();
            _CustomersRepository.Add(Customer);
            return new ResultModel<Customer>(true, StatusMessage.Ok, Customer);
        }

        public async Task CreateShipmentCustomers(ShipmentBulkDTO shipmentBulkDTO)
        {
            var customerPhones = shipmentBulkDTO.Shipments.Select(sh => sh.CustomerPhoneNum);
            var existingCustomers = await _CustomersRepository.GetAll()
                .Where(c => customerPhones.Any(cp=> cp == c.PhoneNumber)).ToListAsync();

            var newCustomers = shipmentBulkDTO.Shipments.Where(sh => !existingCustomers.Any(ec => ec.PhoneNumber == sh.CustomerPhoneNum))
                .Select(ec => new Customer()
                {
                    Key = Guid.NewGuid().ToString(),
                    Name = ec.CustomerName,
                    CityKey = ec.CustomerCityKey,
                    MerchantKey = ec.MerchantKey,
                    PhoneNumber = ec.CustomerPhoneNum,
                    Address = ec.CustomerAddress
                });
            await _CustomersRepository.Add(newCustomers);
        }

        public async Task<ResultModel<CustomersPageDTO>> GetCustomers(CustomerFilterDTO CustomerFilterDTO)
        {
            var allCustomers = _CustomersRepository.GetAll()
                .Where(c => c.MerchantKey == CustomerFilterDTO.MerchantKey &&
            (string.IsNullOrWhiteSpace(CustomerFilterDTO.SearchTerm) || c.Name.Contains(CustomerFilterDTO.SearchTerm) || c.PhoneNumber.Contains(CustomerFilterDTO.SearchTerm)));

            int TotalCount = allCustomers.Count();

            int PagesCount = (int)Math.Ceiling(TotalCount / ((double)CustomerFilterDTO.PageSize == 0 ? 1 : (double)CustomerFilterDTO.PageSize));

            var Customers = allCustomers
                .Skip(CustomerFilterDTO.PageSize * (CustomerFilterDTO.PageNumber - 1))
                .Take(CustomerFilterDTO.PageSize).ToList();

            CustomersPageDTO CustomersPage = new CustomersPageDTO()
            {
                PagesCount = PagesCount,
                TotalCount = TotalCount,
                Customers = _mapper.Map<IList<Customer>, IList<CustomerDTO>>(Customers)
            };

            return new ResultModel<CustomersPageDTO>(true, StatusMessage.Ok, CustomersPage);
        }
        public async Task<ResultModel<Customer>> UpdateCustomer(CustomerDTO CustomerDTO, string merchantKey)
        {
            var Customers = _CustomersRepository.GetAll()
                .Where(p => (CustomerDTO.Key == p.Key || CustomerDTO.Name == p.Name) && p.MerchantKey == merchantKey).ToList();

            if (Customers.Count() > 1) return new ResultModel<Customer>(false, StatusMessage.Conflict);

            var oldCustomer = Customers.FirstOrDefault();
            oldCustomer.PhoneNumber = CustomerDTO.PhoneNumber;
            oldCustomer.Address = CustomerDTO.Address;
            oldCustomer.ComesFrom = CustomerDTO.ComesFrom;
            oldCustomer.CityKey = CustomerDTO.CityKey;
            oldCustomer.Name = CustomerDTO.Name;

            _CustomersRepository.Update(oldCustomer);
            return new ResultModel<Customer>(true, StatusMessage.Ok, oldCustomer);
        }
        public async Task<ResultModel<Customer>> DeleteCustomer(string CustomerKey)
        {
            var oldCustomer = _CustomersRepository.GetAll()
                .Where(p => CustomerKey == p.Key).FirstOrDefault();

            _CustomersRepository.Delete(oldCustomer);

            return new ResultModel<Customer>(true, StatusMessage.Ok);
        }

    }
}
