using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexShipmentCreationResponse
    {
        public bool HasErrors { get; set; }
        public IEnumerable<AramexShipmentResponse> Shipments { get; set; }
    }
    public class AramexShipmentResponse
    {
        public string ID { get; set; }
    }
}
