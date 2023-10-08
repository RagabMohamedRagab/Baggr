using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels {
    public class JTExpressGetPDFBody {
        public JTExpressClientInfo ClientInfo { get; set; }
        public string BillCode { get; set; }
     
        public int PrintSize { get; set; }
        public int PrintCod { get; set; }
        public string Digest { get; set; }
        public JTExpressGetPDFBody(string billcode)
        {
            ClientInfo = new JTExpressClientInfo();
            BillCode =billcode;
            PrintSize = 0;
            PrintCod = 0;
            BillCode = billcode;
            Digest= JTExpressShipmentDegistBody.CalculateDigest();
        }
    }
}
  
