using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly IProvidersRepository<Product> _productsRepository;
        private readonly IMapper _mapper;
        public ProductManager(IProvidersRepository<Product> productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }
        public async Task<ResultModel<Product>> CreateProduct(ProductDTO productDTO, string merchantKey)
        {
            var products = _productsRepository.GetAll()
                .Where(p => p.MerchantKey == merchantKey && productDTO.Name == p.Name);
            
            if(products.Any())
                return new ResultModel<Product>(false, StatusMessage.Conflict);

            var product = _mapper.Map<ProductDTO, Product>(productDTO);
            product.MerchantKey = merchantKey;
            product.Key = Guid.NewGuid().ToString();
            _productsRepository.Add(product);
            return new ResultModel<Product>(true, StatusMessage.Ok, product);
        }
        public async Task<bool> DeductQuantities (IList<ShipmentProductDTO> shipmentProducts)
        {
            var productKeys = shipmentProducts.Select(sp => sp.ProductKey);
            var products = await _productsRepository.GetAll().Where(p => productKeys.Any(spk => spk == p.Key)).ToListAsync();
            foreach (var shipmentProduct in shipmentProducts)
            {
                products.Where(p => p.Key == shipmentProduct.ProductKey).FirstOrDefault().StockAvailability -= shipmentProduct.Quantity;
            }
            await _productsRepository.Update(products);
            return true;
        }
        public async Task<ResultModel<ProductsPageDTO>> GetProducts(ProductFilterDTO productFilterDTO)
        {
            var allProducts = _productsRepository.GetAll().Include(p => p.Category)
                .Where(c => !c.IsDeleted && c.MerchantKey == productFilterDTO.MerchantKey &&
            (string.IsNullOrWhiteSpace(productFilterDTO.SearchTerm) || c.Name.Contains(productFilterDTO.SearchTerm) || c.SKU.Contains(productFilterDTO.SearchTerm)));

            int TotalCount = allProducts.Count();

            int PagesCount = (int)Math.Ceiling(TotalCount / ((double)productFilterDTO.PageSize == 0 ? 1 : (double)productFilterDTO.PageSize));
            
            var products = allProducts
                .Skip(productFilterDTO.PageSize * (productFilterDTO.PageNumber - 1))
                .Take(productFilterDTO.PageSize).ToList();

            ProductsPageDTO productsPage = new ProductsPageDTO()
            {
                PagesCount = PagesCount,
                TotalCount = TotalCount,
                Products = _mapper.Map<IList<Product>, IList<ProductDTO>>(products)
            };

            return new ResultModel<ProductsPageDTO>(true, StatusMessage.Ok, productsPage);
        }
        public async Task<ResultModel<Product>> UpdateProduct(ProductDTO productDTO, string merchantKey)
        {
            var products = _productsRepository.GetAll()
                .Where(p => (productDTO.Key == p.Key || productDTO.Name == p.Name) && p.MerchantKey == merchantKey).ToList();

            if (products.Count() > 1) return new ResultModel<Product>(false, StatusMessage.Conflict);
            
            var oldProduct = products.FirstOrDefault();
            oldProduct.SKU = productDTO.SKU;
            oldProduct.Price = productDTO.Price;
            oldProduct.PhotoUrl = productDTO.PhotoUrl;
            oldProduct.CategoryKey = productDTO.CategoryKey;
            oldProduct.StockAvailability = productDTO.StockAvailability;
            oldProduct.Name = productDTO.Name;

            _productsRepository.Update(oldProduct);
            return new ResultModel<Product>(true, StatusMessage.Ok, oldProduct);
        }
        public async Task<ResultModel<Product>> DeleteProduct(string productKey)
        {
            var oldProduct = _productsRepository.GetAll()
                .Where(p => productKey == p.Key).FirstOrDefault();
            oldProduct.IsDeleted = true;

            _productsRepository.Update(oldProduct);

            return new ResultModel<Product>(true, StatusMessage.Ok);
        }

    }
}
