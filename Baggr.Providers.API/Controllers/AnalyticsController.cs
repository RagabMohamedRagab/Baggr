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
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsFactory _analyticsFactory;

        public AnalyticsController(IAnalyticsFactory analyticsFactory)
        {
            _analyticsFactory = analyticsFactory;
        }
        [HttpGet]
        public IActionResult Get(string merchantKey, DateTime from, DateTime to)
        {
            var result = _analyticsFactory.GetAnalytics(merchantKey, from, to);
            return Ok(result);
        }
    }
}
