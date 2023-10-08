using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.IFactory
{
    public interface IProductFactory
    {
        Task<ResultModel<ProductDTO>> CreateProduct(ProductDTO productDTO, string merchantKey);
        Task<ResultModel<ProductsPageDTO>> GetProducts(ProductFilterDTO productFilterDTO);
        Task<ResultModel<ProductDTO>> UpdateProduct(ProductDTO productDTO, string merchantKey);
        Task<ResultModel<ProductDTO>> DeleteProduct(string productKey);
    }
}
