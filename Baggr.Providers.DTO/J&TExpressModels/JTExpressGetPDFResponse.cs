using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels {
    public class JTExpressGetPDFResponse {
        public bool HasError { get; set; }
        public ShipmentLabel ShipmentLabel { get; set; }
    }
    public class ShipmentLabel {
        public string billCode { get; set; }
        public Byte[] LabelFileContents { get; set; }

    }
}
