using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexGetPDFBody
    {
        public AramexClientInfo ClientInfo { get; set; }
        public LabelInfo LabelInfo { get; set; }
        public string ShipmentNumber { get; set; }
        public AramexGetPDFBody(string AWB)
        {
            ClientInfo = new AramexClientInfo();
            LabelInfo = new LabelInfo();
            ShipmentNumber = AWB;
        }
    }
    public class LabelInfo
    {
        public int ReportID { get; set; } = 9729;
        public string ReportType { get; set; } = "RPT";
    }
}
