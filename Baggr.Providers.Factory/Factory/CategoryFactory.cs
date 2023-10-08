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
    public class CategoryFactory : ICategoryFactory
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        public CategoryFactory(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }
        public async Task<ResultModel<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO, string merchantKey)
        {
            var result =  await _categoryManager.CreateCategory(categoryDTO, merchantKey);
            return new ResultModel<CategoryDTO>(result.IsSuccess, result.StatusMessage,
                _mapper.Map<Category, CategoryDTO>(result.Result));
        }
        public async Task<ResultModel<CategoriesPageDTO>> GetCategories(string merchantKey, int pageSize, int pageNumber)
        {
            var result = await _categoryManager.GetCategories(merchantKey, pageSize, pageNumber);
            return result;
        }
    }
}
