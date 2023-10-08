using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerFactory _CustomerFactory;
        public CustomersController(ICustomerFactory CustomerFactory)
        {
            _CustomerFactory = CustomerFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] CustomerFilterDTO CustomerFilterDTO)
        {
            var result = await _CustomerFactory.GetCustomers(CustomerFilterDTO);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(string merchantKey, [FromBody] CustomerDTO CustomerDTO)
        {
            var result = await _CustomerFactory.CreateCustomer(CustomerDTO, merchantKey);
            if (!result.IsSuccess)
                return Conflict(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(string merchantKey, [FromBody] CustomerDTO CustomerDTO)
        {
            var result = await _CustomerFactory.UpdateCustomer(CustomerDTO, merchantKey);
            if (!result.IsSuccess)
                return Conflict(result);
            return Ok(result);
        }
        [HttpDelete("{CustomerKey}")]
        public async Task<IActionResult> DeleteCustomer(string CustomerKey)
        {
            var result = await _CustomerFactory.DeleteCustomer(CustomerKey);

            return Ok(result);
        }

    }
}
