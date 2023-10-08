using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class ShipmentDTO : ICloneable
    {
        public ShipmentDTO Clone() { return (ShipmentDTO)this.MemberwiseClone(); }
        object ICloneable.Clone() { return Clone(); }
        public string Key { get; set; }
        public string AWB { get; set; }
        public string OrderReference { get; set; }
        public string MerchantName { get; set; }
        public string MerchantCompanyName { get; set; }
        public string MerchantEmail { get; set; }
        public string MerchantPhoneNum { get; set; }
        public string MerchantAddress { get; set; }
        public string MerchantCity { get; set; }
        public string MerchantCityKey { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNum { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCityKey { get; set; }
        public double TotalAmountShouldBeCollected { get; set; }
        public int NumberofPeices { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string MerchantKey { get; set; }
        public DateTime CreatedOn { get; set; }
        public ProviderDTO Provider { get; set; }
        public string LastStatus { get; set; }
        public double OnlinePaymentValue { get; set; }
        public IEnumerable<ShipmentTrackingLogDto> StatusLogs { get; set; }
        public IEnumerable<ShipmentProductDTO> shipmentProducts { get; set; }
    }
}
