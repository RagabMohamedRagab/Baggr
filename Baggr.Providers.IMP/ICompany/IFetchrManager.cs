using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.ICompany
{
    public interface IFetchrManager
    {
        public Task<GetQuoteDTO> GetQuote(IEnumerable<Baggr.Providers.Entities.Entities.Provider> providers, string fromCity, string toCity, int weight);
    }
}
