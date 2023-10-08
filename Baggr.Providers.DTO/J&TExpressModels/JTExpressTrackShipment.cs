using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressTrackShipment
    {
        public string Key { get; set; }
        public IEnumerable<JTExpressShipmentLogs> Value { get; set; }

    }
}
