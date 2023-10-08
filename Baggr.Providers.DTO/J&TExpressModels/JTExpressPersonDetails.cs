using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.J_TExpressModels
{
    public class JTExpressPersonDetails
    {
        public string Name { get; set; }
        public string Company { get; set; } = "";
        public string MailBox { get; set; }
        public string PostCode { get; set; } = "";

        public string Mobile { get; set; }
        public string Phone { get; set; }

        public string CountryCode { get; set; } = "EGY";
        //goverments 
        public string Prov { get; set; } = "";
        public string City { get; set; }

        public string Area { get; set; }
        public string Street { get; set; }


        public string Building { get; set; } = "";
        public string Floor { get; set; } = "";
        public string Flats { get; set; } = "";
        public int? longitude { get; set; } = null;
        public int? latitude { get; set; } = null;
    }
}
