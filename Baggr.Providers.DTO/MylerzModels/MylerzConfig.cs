using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzConfig
    {
        public string URL { get; set; }
        public string GetTokenEndpoint { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CreateAddressEndpoint { get; set; }
        public string CreateOrdersEndpoint { get; set; }
        public string CreatePickupEndpoint { get; set; }
        public string PortalURL { get; set; }
        public string GetQuoteEndpoint { get; set; }
        public string GetAWBPDF { get; set; }
        public string TrackShipmentEndpoint { get; set; }
        public string TrackShipmentLogEndpoint { get; set; }
    }
}
