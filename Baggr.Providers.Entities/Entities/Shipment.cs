using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string OrderReference { get; set; }
        public string AWB { get; set; }
        public string MerchantName { get; set; }
        public string MerchantCompanyName { get; set; }
        public string MerchantEmail { get; set; }
        public string MerchantPhoneNum { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantCity { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNum { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public double TotalAmountShouldBeCollected { get; set; }
        public int NumberofPeices { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string BiiCode { get; set; }
      
        public string MerchantKey { get; set; }
        public int ProviderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Provider Provider { get; set; }
        public string LastStatus { get; set; }
        public bool IsHidden { get; set; }
        public double OnlinePaymentValue { get; set; }
        public IEnumerable<ShipmentProduct> ShipmentProducts { get; set; }
    }
}
