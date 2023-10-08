using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexGetQuoteBody
    {
        public AramexClientInfo ClientInfo { get; set; }
        public AramexAddress DestinationAddress { get; set; }
        public AramexAddress OriginAddress { get; set; }
        public string PreferredCurrencyCode { get; set; } = "EGP";
        public AramexShipmentDetails ShipmentDetails { get; set; }
        public AramexGetQuoteBody()
        {
            ClientInfo = new AramexClientInfo();
            DestinationAddress = new AramexAddress();
            OriginAddress = new AramexAddress();
            ShipmentDetails = new AramexShipmentDetails();
        }
    }
}
