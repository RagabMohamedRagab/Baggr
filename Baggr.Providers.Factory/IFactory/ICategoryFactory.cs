using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.IFactory
{
    public interface ICategoryFactory
    {
        Task<ResultModel<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO, string merchantKey);
        Task<ResultModel<CategoriesPageDTO>> GetCategories(string merchantKey, int pageSize, int pageNumber);
    }
}
