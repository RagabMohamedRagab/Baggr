using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class FedexTrackShipmentResponse
    {
        public int Code { get; set; }
        public IEnumerable<AirwayBillTrack> AirwayBillTrackList { get; set; }

    }
    public class AirwayBillTrack
    {
        public string LastStatus { get; set; }
        public string AirWayBillNo { get; set; }
        public IEnumerable<FedexTrackingLogDetails> TrackingLogDetails { get; set; }
    }  
    public class FedexTrackingLogDetails
    {
       public DateTime ActivityDate { get; set; }
       public DateTime ActivityTime { get; set; }
       public string Remarks { get; set; }



    }

}
