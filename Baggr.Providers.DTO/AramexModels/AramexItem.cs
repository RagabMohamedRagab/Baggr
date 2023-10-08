using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexItem
    {
        public string ProductGroup { get; set; } = "DOM";
        public string ProductType { get; set; } = "CDS";
        public int NumberOfShipments { get; set; }
        public string PackageType { get; set; } = "Box";
        public string Payment { get; set; } = "P";
        public AramexActualWeight ShipmentWeight { get; set; }
        public string ShipmentVolume { get; set; }
        public int NumberOfPieces { get; set; } = 1;
        public string CashAmount { get; set; }
        public string ExtraCharges { get; set; }
        public AramexShipmentDimensions ShipmentDimensions { get; set; }
        public string Comments { get; set; } = "";
        public AramexItem(IEnumerable<AramexShipment> shipments)
        {
            NumberOfShipments = shipments.Count();
            ShipmentWeight = new AramexActualWeight();
            ShipmentDimensions = new AramexShipmentDimensions();
        }


    }
}
