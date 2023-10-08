using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class OrderBulkDTO
    {
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
