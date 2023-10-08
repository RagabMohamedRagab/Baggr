using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexTrackShipmentsBody
    {
        public AramexClientInfo ClientInfo { get; set; }
        public IEnumerable<string> Shipments { get; set; }
        public AramexTrackShipmentsBody(IEnumerable<string> awbNumbers)
        {
            Shipments = awbNumbers;
            ClientInfo = new AramexClientInfo();
        }
    }
}
