using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.AramexModels
{
    public class AramexAddress
    {
        public string Line1 { get; set; } = "ABC Street";
        public string Line2 { get; set; } = "";
        public string Line3 { get; set; } = "";
        public string City { get; set; } 
        public string StateOrProvinceCode { get; set; } = "";
        public string PostCode { get; set; } = "";
        public string CountryCode { get; set; } = "EG";

    }
}
