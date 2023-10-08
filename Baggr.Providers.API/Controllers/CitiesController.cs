using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityFactory _cityFactory;

        public CitiesController(ICityFactory cityFactory)
        {
            _cityFactory = cityFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cityFactory.GetCities());
        }
    }
}
