using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class AWBModel
    {
        public string AirWayBillCreatedBy { get; set; } = "Baggr";
        public double CODAmount { get; set; }
        public string CODCurrency { get; set; } = "";
        public string Destination { get; set; }
        public int DutyConsigneePay { get; set; } = 0;
        public string GoodsDescription { get; set; } = "";
        public int NumberofPeices { get; set; } = 1;
        public string Origin { get; set; } = "CAI";
        public string ProductType { get; set; } = "DOX";
        public string ReceiversAddress1 { get; set; } 
        public string ReceiversAddress2 { get; set; } = "";
        public string ReceiversCity { get; set; }
        public string ReceiversCompany { get; set; } = "";
        public string ReceiversContactPerson { get; set; }
        public string ReceiversCountry { get; set; } = "Egypt";
        public string ReceiversEmail { get; set; }
        public string ReceiversGeoLocation { get; set; } = "";
        public string ReceiversMobile { get; set; }
        public string ReceiversPhone { get; set; } = "";
        public string ReceiversPinCode { get; set; } = "";
        public string ReceiversProvince { get; set; } = "";
        public string ReceiversSubCity { get; set; } = "";
        public string SendersAddress1 { get; set; }
        public string SendersAddress2 { get; set; } = "";
        public string SendersCity { get; set; }
        public string SendersCompany { get; set; } = "";
        public string SendersContactPerson { get; set; }
        public string SendersCountry { get; set; } = "Egypt";
        public string SendersEmail { get; set; }
        public string SendersGeoLocation { get; set; } = "";
        public string SendersMobile { get; set; }
        public string SendersPhone { get; set; } = "";
        public string SendersPinCode { get; set; } = "";
        public string SendersSubCity { get; set; } = "";
        public string ServiceType { get; set; } = "COD";
        public string ShipmentDimension { get; set; } = "";
        public string ShipmentInvoiceCurrency { get; set; } = "EGP";
        public int ShipmentInvoiceValue { get; set; } = 0;
        public string ShipperReference { get; set; }
        public string ShipperVatAccount { get; set; } = "";
        public string SpecialInstruction { get; set; } = "Confirm Location before Delivery";

        public int Weight { get; set; }
    }
}
