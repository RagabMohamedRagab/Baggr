using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentFactory _shipmentFactory;

        public ShipmentsController(IShipmentFactory shipmentFactory)
        {
            _shipmentFactory = shipmentFactory;
        }
        [HttpGet]
        public IActionResult Get(string merchantKey, string searchTerm, DateTime? from, DateTime? to, Boolean? isFulfilled, int pagSize = 10, int pageNumber = 1)
        {

            var result = _shipmentFactory.GetShipments(merchantKey, searchTerm,  pagSize, pageNumber, from, to, isFulfilled);
            return Ok(result);
        }
        [HttpGet("{shipmentKey}/getAWBPDF")]
        public async Task<IActionResult> Get(string shipmentKey)
        {
            var result = await _shipmentFactory.GetShipmentPDF(shipmentKey);
            if (!result.IsSuccess) return NotFound();
            return Ok(result);
        }
        [HttpGet("{shipmentKey}")]
        public async Task<IActionResult> GetShipmentKey(string shipmentKey)
        {
            var result = await _shipmentFactory.GetShipmentByKey(shipmentKey);
            if (!result.IsSuccess) return NotFound();
            return Ok(result);
        }
        [HttpPost("{shipmentKey}/return")]
        public async Task<IActionResult> Return(string shipmentKey)
        {
            var result = await _shipmentFactory.ReturnShipment(shipmentKey);
            if (!result.IsSuccess) return NotFound();
            return Ok(result);
        }
        [HttpPost("{shipmentKey}/returnandpickup")]
        public async Task<IActionResult> ReturnAndPickup(string shipmentKey)
        {
            var result = await _shipmentFactory.ReturnAndPickupShipment(shipmentKey);
            if (!result.IsSuccess) return NotFound();
            return Ok(result);
        }
    }
}
