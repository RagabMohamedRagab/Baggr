using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class FedexTrackShipmentBody
    {
        public string UserName { get; set; } = "BAGGR";
        public string Password { get; set; } = "r9t4SiSiqY5WyUP99mt/8A==";
        public string AccountNo { get; set; } = "qb6gu/fdHAUpfk93HhpX2w==";
        public string TrackingAWB { get; set; }
        public FedexTrackShipmentBody(string awb)
        {
            TrackingAWB = awb;
        }
    }
    
}
