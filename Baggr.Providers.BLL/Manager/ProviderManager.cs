using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.Manager
{
    public class ProviderManager : IProviderManager
    {
        
        private readonly IProvidersRepository<Provider> _providersRepository;
        public ProviderManager(IProvidersRepository<Provider> providersRepository)
        {
            _providersRepository = providersRepository;
        }
        public ResultModel<IEnumerable<Provider>> GetProviders()
        {
            var providers = _providersRepository.GetAll().Include(p => p.ProviderCities).ThenInclude(pc => pc.City).Include(p => p.ProviderInformation);
            return new ResultModel<IEnumerable<Provider>>(true, StatusMessage.Ok, providers);
        }
        public async Task<ResultModel<Provider>> GetProviderByKey(string key)
        {
            var provider =await _providersRepository.GetAll().Include(p => p.ProviderCities).ThenInclude(pc => pc.City)
                .FirstOrDefaultAsync(p => p.Key == key);
            if (provider == null) return new ResultModel<Provider>(false, StatusMessage.NotFound);
            return new ResultModel<Provider>(true, StatusMessage.Ok, provider);
        }

        public async Task< ResultModel<IEnumerable<Provider>>> GetProvidersWIthoutRelatedEntities()
        {
            var providers = _providersRepository.GetAll();
            return new ResultModel<IEnumerable<Provider>>(true, StatusMessage.Ok, await providers.ToListAsync());
        }
    }
    
}
