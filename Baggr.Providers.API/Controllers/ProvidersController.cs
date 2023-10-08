using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IShipmentFactory _shipmentFactory;
        private readonly IProviderFactory _providerFactory;

        public ProvidersController(IShipmentFactory shipmentFactory, IProviderFactory providerFactory)
        {
            _shipmentFactory = shipmentFactory;
            _providerFactory = providerFactory;
        }

        [HttpGet("GetQuote")]
        public async Task<IActionResult> Get(string FromCity, string ToCity, double Weight)
        {
            var result = await _shipmentFactory.GetQuote(FromCity, ToCity, Weight);
            return Ok(result);
        }

        [HttpGet("GetProviders")]
        [ProducesResponseType( StatusCodes.Status200OK, Type=typeof(ResultModel< IEnumerable<ProviderDTO>>))]
        public async Task<IActionResult> GetProviders()
        {
            try
            {
                var result = await _providerFactory.GetProviders();
                return Ok(result);
            }
            catch (Exception)
            {

                return Ok(new ResultModel<IEnumerable<ProviderDTO>>(false, StatusMessage.BadRequest,null));
            }
        
        }
    }
}
