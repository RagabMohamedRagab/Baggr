using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JTExpressCityZoneController : ControllerBase {

        private readonly IJtExpressCityZoneFactory _jtExpressFactory;

        public JTExpressCityZoneController(IJtExpressCityZoneFactory jtExpressFactory)
        {
            _jtExpressFactory = jtExpressFactory;
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromForm] JTExpressCityDTO model)
        {
            var result=await _jtExpressFactory.CreateCity(model);
            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetCities(int pageSize, int pageNumber)
        {
            var result=await _jtExpressFactory.GetCities(pageSize, pageNumber);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddZone([FromForm] JTExpressZoneDTO model)
        {
            var result = await _jtExpressFactory.CreateZone(model);
            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetZones(int pageSize, int pageNumber)
        {
            var result = await _jtExpressFactory.GetZones(pageSize, pageNumber);
            return Ok(result);
        }



    }
}
