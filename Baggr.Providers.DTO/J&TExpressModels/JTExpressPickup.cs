using Baggr.Providers.DTO.AramexModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressPickup
    {
        public string SendStartTime { get; set; }
        public string expectDeliveryStartTime { get; set; }
        public string SendEndTime { get; set; }
        public string expectDeliveryEndTime { get; set; }
        public IEnumerable<JTExpressShipment> Shipments { get; set; }
        public List<JTExpressItem> PickupItems { get; set; }
        public JTExpressPickup() {
            // i dont know make intalize in the constrctor or in own class !.
            var now = DateTimeOffset.UtcNow;
            if (now.Hour >= 13) now = now.AddDays(1);

            var readyForPickUp = new DateTimeOffset(now.Year, now.Month, now.Day, 15, 0, 0, new TimeSpan());
            var closingTime = new DateTimeOffset(now.Year, now.Month, now.Day, 16, 0, 0, new TimeSpan());
            SendStartTime = "/Date(" + readyForPickUp.ToUnixTimeMilliseconds() + ")/";
            expectDeliveryStartTime = SendEndTime;
            SendEndTime = "/Date(" + closingTime.ToUnixTimeMilliseconds() + ")/";
            expectDeliveryEndTime = SendEndTime;
            //PickupItems = new List<JTExpressItem>() 
            //{ new JTExpressItem(shipments) };
        }

    }
}
