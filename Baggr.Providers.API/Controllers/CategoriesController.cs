using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        
        private readonly ICategoryFactory _categoryFactory;

        public CategoriesController(ICategoryFactory categoryFactory, IProviderFactory providerFactory)
        {
            _categoryFactory = categoryFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(string merchantKey, int pageSize, int pageNumber)
        {
            var result = await _categoryFactory.GetCategories(merchantKey, pageSize, pageNumber);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(string merchantKey, [FromBody] CategoryDTO categoryDTO)
        {
            var result = await _categoryFactory.CreateCategory(categoryDTO, merchantKey);
            return Ok(result);
        }
    }
}
