using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexShipmentDetails
    {
        public string Dimensions { get; set; }
        public AramexActualWeight ActualWeight { get; set; }
        public string ChargeableWeight { get; set; }
        public string DescriptionOfGoods { get; set; }
        public string GoodsOriginCountry { get; set; }
        public int NumberOfPieces { get; set; } = 1;
        public string ProductGroup { get; set; } = "DOM";
        public string ProductType { get; set; } = "CDS";
        public string PaymentType { get; set; } = "P";
        public string PaymentOptions { get; set; } = "";
        public string Services { get; set; }
        public AramexCash CashOnDeliveryAmount { get; set; }
        public AramexShipmentDetails ()
        {
            ActualWeight = new AramexActualWeight();
        }
    }
}
