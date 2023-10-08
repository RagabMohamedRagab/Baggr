using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class OrderProductDTO
    {
        public string ProductKey { get; set; }
        public int Quantity { get; set; }
        public ProductDTO Product { get; set; }
    }
}
