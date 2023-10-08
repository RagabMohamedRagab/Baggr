using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressShipmentCreationResponse
    {
        public bool HasErrors { get; set; }
        public IEnumerable<JTExpressShipmentResponse> Shipments { get; set; }

    
    }
    public class JTExpressShipmentResponse
    {
        public string ID { get; set; }
    }

}
