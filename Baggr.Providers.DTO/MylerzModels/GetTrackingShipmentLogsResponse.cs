using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.MylerzModels
{
    public class MylerzGetTrackingShipmentLogsResponse
    {

        public IEnumerable<LogsValue> Value { get; set; }
        public string ErrorDescription { get; set; }
        public bool IsErrorState { get; set; }

        public class LogsValue
        {
            public long Barcode { get; set; }
            public IEnumerable<TrackLog> TrackLog { get; set; }
        }
        public class TrackLog
        {
            public string StatusArName { get; set; }
            public string StatusEnName { get; set; }
            public DateTime ChangedDate { get; set; }


        }
    }
}
