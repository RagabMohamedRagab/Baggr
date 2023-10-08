using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.IManager
{
    public interface ICategoryManager
    {
        Task<ResultModel<Category>> CreateCategory(CategoryDTO categoryDTO, string merchantKey);
        Task<ResultModel<CategoriesPageDTO>> GetCategories(string merchantKey, int PageSize, int PageNumber);    
    }
}
