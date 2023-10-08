using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.FedexModels
{
    public class BookingModel
    {
       public string BookingCreatedBy { get; set; }
       public string BookingCompanyName { get; set; }
       public string BookingContactPerson { get; set; }
       public string BookingCountry { get; set; } = "Egypt";
       public string BookingEmail { get; set; }
       public string BookingMobileNo { get; set; }
       public string BookingPhoneNo { get; set; }
       public string BookingCity { get; set; }
       public string PackageType { get; set; } = "";
        public string GoodsDescription { get; set; } = "";
       public string Origin { get; set; } = "CAI";
       public string ProductType { get; set; } = "DOX";
       public string SendersAddress1 { get; set; }
       public string SendersAddress2 { get; set; } = "";
       public string SendersCity { get; set; }
       public string SendersCompany { get; set; }
       public string SendersContactPerson { get; set; }
       public string SendersCountry { get; set; } = "Egypt";
       public string SendersEmail { get; set; }
       public string SendersMobile { get; set; }
       public string SendersPhone { get; set; }
       public string ServiceType { get; set; } = "COD";
       public string ShipmentInvoiceCurrency { get; set; } = "EGP";
       public string BusinessClosingTime { get; set; } = "17:00";
       public string ShipmentReadyDate { get; set; }
        public string ShipmentReadyTime { get; set; } = "10:00";
    }
}
