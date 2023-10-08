using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Baggr.Providers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFactory _productFactory;
        public ProductsController(IProductFactory productFactory)
        {
            _productFactory = productFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilterDTO productFilterDTO)
        {
            var result = await _productFactory.GetProducts(productFilterDTO);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(string merchantKey, [FromBody] ProductDTO productDTO)
        {
            var result = await _productFactory.CreateProduct(productDTO, merchantKey);
            if (!result.IsSuccess)
                return Conflict(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(string merchantKey, [FromBody] ProductDTO productDTO)
        {
            var result = await _productFactory.UpdateProduct(productDTO, merchantKey);
            if (!result.IsSuccess)
                return Conflict(result);
            return Ok(result);
        }
        [HttpDelete("{productKey}")]
        public async Task<IActionResult> DeleteProduct(string productKey)
        {
            var result = await _productFactory.DeleteProduct(productKey);
            
            return Ok(result);
        }

    }
}
