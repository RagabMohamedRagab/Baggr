using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels {
    public class JTExpressConfig {
        public string URL { get; set; }
        public string GetQuoteEndpoint { get; set; }
        public string CreateOrdersEndpoint { get; set; }
        public string TrackingEndpoint { get; set; }
        public string GetAWBPDF { get; set; }
      //  public string CreatePickUpEndpoint { get; set; }
    }
}
