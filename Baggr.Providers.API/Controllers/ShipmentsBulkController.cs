using Baggr.Providers.DTO.DTOs;
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
    public class ShipmentsBulkController : ControllerBase
    {
        private readonly IShipmentFactory _shipmentFactory;

        public ShipmentsBulkController(IShipmentFactory shipmentFactory)
        {
            _shipmentFactory = shipmentFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShipmentBulkDTO shipmentBulkDTO)
        {
            var result = await _shipmentFactory.createShipments(shipmentBulkDTO);
            return Ok(result);
        }
        [HttpPut("hideShipments")]
        public async Task<IActionResult> Post(IEnumerable<string> shipmentKeys)
        {
            var result = await _shipmentFactory.HideShipments(shipmentKeys);
            return Ok(result);
        }

    }
}
