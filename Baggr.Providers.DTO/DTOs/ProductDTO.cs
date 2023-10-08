using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class ProductDTO
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string SKU { get; set; }
        public int StockAvailability { get; set; }
        public string PhotoUrl { get; set; }
        public string CategoryKey { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
