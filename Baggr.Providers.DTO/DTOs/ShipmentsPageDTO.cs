using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class ShipmentsPageDTO
    {
        public int TotalCount { get; set; }
        public int PagesCount { get; set; }
        public IList<ShipmentDTO> Shipments { get; set; }
    }
}
