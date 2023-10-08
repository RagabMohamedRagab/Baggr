using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.Manager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IProvidersRepository<Category> _categoriesRepository;
        private readonly IMapper _mapper;
        public CategoryManager(IProvidersRepository<Category> categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }
        public async Task<ResultModel<Category>> CreateCategory(CategoryDTO categoryDTO, string merchantKey)
        {
            var category = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            category.MerchantKey = merchantKey;
            category.Key = Guid.NewGuid().ToString();
            _categoriesRepository.Add(category);
            return new ResultModel<Category>(true, StatusMessage.Ok, category);
        }
        public async Task<ResultModel<CategoriesPageDTO>> GetCategories(string merchantKey, int PageSize, int PageNumber)
        {
            var allCategories = _categoriesRepository.GetAll().Where(c => c.MerchantKey == merchantKey);
            
            int TotalCount = allCategories.Count();

            int PagesCount = (int)Math.Ceiling(TotalCount / ((double)PageSize == 0 ? 1 : (double)PageSize));

            var categories = allCategories
                .Skip(PageSize * (PageNumber - 1))
                .Take(PageSize).ToList();

            CategoriesPageDTO categoriessPage = new CategoriesPageDTO()
            {
                PagesCount = PagesCount,
                TotalCount = TotalCount,
                Categories = _mapper.Map<IList<Category>, IList<CategoryDTO>>(categories)
            };
            return new ResultModel<CategoriesPageDTO>(true, StatusMessage.Ok, categoriessPage);
        }
    }
}
