using Microsoft.AspNetCore.Mvc;

namespace Baggr.Providers.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class JTExpressController : ControllerBase {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
