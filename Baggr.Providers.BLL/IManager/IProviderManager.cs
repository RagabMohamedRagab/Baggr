using Baggr.Providers.DTO;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.IManager
{
    public interface IProviderManager
    {
        ResultModel<IEnumerable<Provider>> GetProviders();
        Task<ResultModel<Provider>> GetProviderByKey(string key);
        Task<ResultModel<IEnumerable<Provider>>> GetProvidersWIthoutRelatedEntities();
    }
}
