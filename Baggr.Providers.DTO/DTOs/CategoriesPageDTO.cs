using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class CategoriesPageDTO
    {
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public IList<CategoryDTO> Categories { get; set; }
    }
}
