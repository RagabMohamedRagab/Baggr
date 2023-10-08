using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexTrackShipmentResponse
    {
        public IEnumerable<AramexTrackShipment> TrackingResults { get; set; }
        public bool HasErrors { get; set; }
    }
}
