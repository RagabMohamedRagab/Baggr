using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressPickupCreationResponse
    {
        public bool HasErrors { get; set; }
        public JTExpressPickupResponse ProcessedPickup { get; set; }
    
    public class JTExpressPickupResponse
        {
        public IEnumerable<JTExpressShipmentResponse> ProcessedShipments { get; set; }
    }
}
}
