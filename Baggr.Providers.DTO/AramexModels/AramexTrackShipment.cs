using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexTrackShipment
    {
        public string Key { get; set; }
        public IEnumerable<AramexShipmentLogs> Value { get; set; }
    }
}
