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

        [HttpGet]
        public async Task<IActionResult> AddCity([FromForm] JTExpressCityDTO model)
        {
            return Ok();

        }
        [HttpGet]
        public IActionResult GetCities(int pageSize, int pageNumber)
        {
            return Ok();
        }
    }
}
