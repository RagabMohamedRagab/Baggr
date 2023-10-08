using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexShipment
    {
        public AramexPersonDetails Shipper { get; set; }
        public AramexPersonDetails Consignee { get; set; }
        public string ShippingDateTime { get; set; }
        public string DueDate { get; set; }
        public string Comments { get; set; }
        public AramexShipmentDetails Details { get; set; }
    }
}
