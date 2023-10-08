using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels {
    public class JTExpressShipmentsCreationBody {
       
        public IEnumerable<JTExpressShipment> Shipments { get; set; }
        public JTExpressShipmentsCreationBody(IEnumerable<JTExpressShipment> shipments)
        {
            Shipments = shipments;
          
        }

        
       
    }
}
