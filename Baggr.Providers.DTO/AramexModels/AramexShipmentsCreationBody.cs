using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexShipmentsCreationBody
    {
        public AramexClientInfo ClientInfo { get; set; }
        public IEnumerable<AramexShipment> Shipments { get; set; }
        public AramexShipmentsCreationBody(IEnumerable<AramexShipment> shipments)
        {
            Shipments = shipments;
            ClientInfo = new AramexClientInfo();
        }
    }
}
