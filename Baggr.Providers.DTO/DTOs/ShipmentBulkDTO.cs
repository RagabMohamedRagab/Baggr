using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class ShipmentBulkDTO
    {
        public string ProviderKey { get; set; }
        public IEnumerable<ShipmentDTO> Shipments { get; set; }
    }
}
