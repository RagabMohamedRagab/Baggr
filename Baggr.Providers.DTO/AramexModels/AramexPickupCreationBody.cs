using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexPickupCreationBody
    {
        public AramexClientInfo ClientInfo { get; set; }
        public AramexPickup Pickup { get; set; }
        public AramexPickupCreationBody(IEnumerable<AramexShipment> shipments)
        {
            Pickup = new AramexPickup(shipments);
            ClientInfo = new AramexClientInfo();
        }
    }
}
