using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.IManager
{
    public interface IProductManager
    {
        Task<ResultModel<Product>> CreateProduct(ProductDTO productDTO, string merchantKey);
        Task<ResultModel<Product>> UpdateProduct(ProductDTO productDTO, string merchantKey);
        Task<ResultModel<Product>> DeleteProduct(string productKey);
        Task<ResultModel<ProductsPageDTO>> GetProducts(ProductFilterDTO productFilterDTO);
        Task<bool> DeductQuantities(IList<ShipmentProductDTO> shipmentProducts);
    }
}
