using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.IFactory
{
    public interface IProviderFactory
    {
        Task<ResultModel<IEnumerable<ProviderDTO>>> GetProviders();
    }
}
