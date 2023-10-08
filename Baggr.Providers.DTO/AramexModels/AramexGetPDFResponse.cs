using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexGetPDFResponse
    {
        public bool HasError { get; set; }
        public ShipmentLabel ShipmentLabel { get; set; }
    }
    public class ShipmentLabel
    {
        public string LabelURL { get; set; }
        public Byte[] LabelFileContents { get; set; }
    }

}
