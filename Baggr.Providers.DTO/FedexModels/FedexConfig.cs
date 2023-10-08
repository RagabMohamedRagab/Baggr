using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class FedexConfig
    {
        public string URL { get; set; }
        public string GetQuoteEndpoint { get; set; }
        public string CreateOrderEndpoint { get; set; }
        public string TrackShipmentEndpoint { get; set; }
        public string CreatePickUpEndpoint { get; set; }
        public string GetAWBPDF { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
