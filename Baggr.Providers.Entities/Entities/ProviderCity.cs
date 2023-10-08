using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
    public class ProviderCity
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int ProviderId { get; set; }
        public City City { get; set; }
        public Provider Provider {get;set;}
        public string MappedName { get; set; } 
        //This field used only for Mylerz for Creating WareHouse
        public int MylerzSubZoneId { get; set; }

    }
}
