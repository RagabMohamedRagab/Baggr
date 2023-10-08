using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.FetchrModels;
using Baggr.Providers.IMP.ICompany;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.Company
{
    public class FetchrManager: IFetchrManager
    {
        private readonly FetchrConfig _fetchrConfig;

        public FetchrManager(IOptions<FetchrConfig> fetchrConfig)
        {
            _fetchrConfig = fetchrConfig.Value;
        }
        public async Task<GetQuoteDTO> GetQuote(IEnumerable<Baggr.Providers.Entities.Entities.Provider> providers, string fromCity, string toCity, int weight)
        {
            var fetchrProvider = providers.Where(p => p.Key == "fetchrKey").FirstOrDefault();
            var totalPrice = (_fetchrConfig.RatePerFirstKG.Where(r => r.Destination == toCity).FirstOrDefault().Price + _fetchrConfig.RatePerExtraKG *(weight-1))* _fetchrConfig.AddedTaxes;
            return new GetQuoteDTO(fetchrProvider.ProviderName, fetchrProvider.ProviderLogo, totalPrice, fetchrProvider.Key, null);
        }
    }
}
