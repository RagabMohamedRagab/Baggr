using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexPickup
    {
        public AramexAddress PickupAddress { get; set; }
        public AramexContact PickupContact { get; set; }
        public string PickupLocation { get; set; }
        public string PickupDate { get; set; }
        public string ReadyTime { get; set; }
        public string LastPickupTime { get; set; }
        public string ClosingTime { get; set; }
        public string Comments { get; set; } = "";
        public string Reference1 { get; set; } = "ref";
        public string Reference2 { get; set; } = "";
        public string Vehicle { get; set; } = "";
        public IEnumerable<AramexShipment> Shipments { get; set; }
        public List<AramexItem> PickupItems { get; set; }
        public string Status { get; set; } = "Ready";
        public AramexPickup(IEnumerable<AramexShipment> shipments)
        {
            Shipments = shipments;
            PickupAddress = shipments.FirstOrDefault().Shipper.PartyAddress;
            PickupContact = shipments.FirstOrDefault().Shipper.Contact;
            PickupLocation = shipments.FirstOrDefault().Shipper.PartyAddress.City;
           
            var now = DateTimeOffset.UtcNow;
            if (now.Hour >= 13) now = now.AddDays(1); 

            var readyForPickUp = new DateTimeOffset(now.Year,now.Month,now.Day,15,0,0,new TimeSpan());
            var closingTime = new DateTimeOffset(now.Year, now.Month, now.Day, 16, 0, 0, new TimeSpan());
            PickupDate = "/Date(" + readyForPickUp.ToUnixTimeMilliseconds() + ")/";
            ReadyTime = PickupDate;
            LastPickupTime = "/Date(" + closingTime.ToUnixTimeMilliseconds() + ")/";
            ClosingTime = LastPickupTime;
            PickupItems = new List<AramexItem>() { new AramexItem(shipments) };
        }

    }
}
