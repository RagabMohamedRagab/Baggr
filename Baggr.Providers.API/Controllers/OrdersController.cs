using Baggr.Providers.Factory.Factory;
using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderFactory _orderFactory;
        public OrdersController(IOrderFactory orderFactory)
        {
            _orderFactory = orderFactory;
        }
        [HttpGet]
        public IActionResult Get(string merchantKey, string searchTerm,bool? isPayed, DateTime? from, DateTime? to, int pagSize = 10, int pageNumber = 1)
        {
            var result = _orderFactory.GetOrders(merchantKey, searchTerm, pagSize, pageNumber, from, to, isPayed);
            return Ok(result);
        }
        [HttpGet("{orderKey}")]
        public async Task<IActionResult> GetOrderByKey(string orderKey)
        {
            var result = await _orderFactory.GetOrderByKey(orderKey);
            if (!result.IsSuccess) return NotFound();
            return Ok(result);
        }
        [HttpPost("{orderRef}/markOrderPayed")]
        public async Task<IActionResult> MarkOrderPayed(string orderRef)
        {
            await _orderFactory.MarkOrderPayed(orderRef);
            
            return Ok();
        }
        [HttpDelete("{orderKey}")]
        public async Task<IActionResult> DeleteOrderByKey(string orderKey)
        {
            var result = await _orderFactory.DeleteOrderByKey(orderKey);
            if (!result.IsSuccess) return NotFound();
            return Ok(result);
        }
    }
}
