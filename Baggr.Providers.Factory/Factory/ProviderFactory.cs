using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.Factory
{
    public class ProviderFactory : IProviderFactory
    {
        private readonly IProviderManager _providerManager;
        private readonly IMapper _mapper;
        public ProviderFactory(IMapper mapper, IProviderManager providerManager)
        {
            _mapper = mapper;
            _providerManager = providerManager;
        }
        public async Task< ResultModel< IEnumerable<ProviderDTO>>> GetProviders()
        {
            var providers = _mapper.Map < IEnumerable<ProviderDTO>>((await _providerManager.GetProvidersWIthoutRelatedEntities()).Result);
           return  new ResultModel<IEnumerable<ProviderDTO>> (true,StatusMessage.Ok, providers);
        }
    }
}
