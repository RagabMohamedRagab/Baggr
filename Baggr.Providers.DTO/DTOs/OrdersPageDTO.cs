using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class OrdersPageDTO
    {
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public IList<OrderDTO> Orders { get; set; }
    }
}
