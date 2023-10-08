using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressTrackShipmentResponse
    {
        public IEnumerable<JTExpressTrackShipment> TrackingResults { get; set; }
        public bool HasErrors { get; set; }
    }
}
