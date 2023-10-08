using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Entities.Entities
{
   public class Provider
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string ProviderName { get; set; }
        public string ProviderLogo { get; set; }
        public string ProviderAnalyticsColour { get; set; }
        public IEnumerable<ProviderCity> ProviderCities { get; set; }
        public IEnumerable<ProviderInformation> ProviderInformation { get; set; }
    }
}
