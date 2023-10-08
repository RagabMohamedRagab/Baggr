using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexPickupCreationResponse
    {
        public bool HasErrors { get; set; }
        public AramexPickupResponse ProcessedPickup { get; set; }
    }
    public class AramexPickupResponse
    {
        public IEnumerable<AramexShipmentResponse> ProcessedShipments { get; set; }
    }
}
