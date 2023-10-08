using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzTrackShipmentResponse
    {
        public IEnumerable<MylerzTrackShipmentValue> Value { get; set; }
        public bool IsErrorState { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class MylerzTrackShipmentValue
    {
        public string BarCode { get; set; }
        public string Status { get; set; }
    }
        

}
