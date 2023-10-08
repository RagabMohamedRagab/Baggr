using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressPickupCreationBody
    {
        public JTExpressClientInfo ClientInfo { get; set; }
        public JTExpressPickup Pickup { get; set; }
        public JTExpressPickupCreationBody(IEnumerable<JTExpressShipment> shipments)
        {
            //Pickup = new JTExpressPickup(shipments);
            ClientInfo = new JTExpressClientInfo();
        }

    }
}
