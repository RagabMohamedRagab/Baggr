using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class CustomersPageDTO
    {
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public IList<CustomerDTO> Customers { get; set; }
    }
}
