using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.Factory
{
    public class ProductFactory : IProductFactory
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;
        public ProductFactory(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }
        public async Task<ResultModel<ProductDTO>> CreateProduct(ProductDTO productDTO, string merchantKey)
        {
            var result = await _productManager.CreateProduct(productDTO, merchantKey);
            return new ResultModel<ProductDTO>(result.IsSuccess, result.StatusMessage, _mapper.Map<Product, ProductDTO>(result.Result));
        }
        public async Task<ResultModel<ProductsPageDTO>> GetProducts(ProductFilterDTO productFilterDTO)
        {
            var result = await _productManager.GetProducts(productFilterDTO);
            return result;
        }
        public async Task<ResultModel<ProductDTO>> UpdateProduct(ProductDTO productDTO, string merchantKey)
        {
            var result = await _productManager.UpdateProduct(productDTO, merchantKey);
            return new ResultModel<ProductDTO>(result.IsSuccess, result.StatusMessage);
        }
        public async Task<ResultModel<ProductDTO>> DeleteProduct(string productKey)
        {
            var result = await _productManager.DeleteProduct(productKey);
            return new ResultModel<ProductDTO>(result.IsSuccess, result.StatusMessage);
        }
    }
}
