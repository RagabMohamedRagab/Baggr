using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baggr.Providers.IMP.Company
{
    public static class Base
    {
        public static string GetMappedName(Baggr.Providers.Entities.Entities.Provider provider, string CityName)
        {
            return provider.ProviderCities.Where(PC => PC.City.CityName == CityName).FirstOrDefault().MappedName;
        }
        public static int GetSubZoneId(Baggr.Providers.Entities.Entities.Provider provider, string CityName)
        {
            return provider.ProviderCities.Where(PC => PC.City.CityName == CityName).FirstOrDefault().MylerzSubZoneId;
        }
    
    }
}
