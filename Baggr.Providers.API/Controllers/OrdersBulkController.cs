using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersBulkController : ControllerBase
    {
        private readonly IOrderFactory _orderFactory;
        public OrdersBulkController(IOrderFactory orderFactory)
        {
            _orderFactory = orderFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderBulkDTO orderBulkDTO)
        {
            var result = await _orderFactory.createOrders(orderBulkDTO);
            return Ok(result);
        }
    }
}
