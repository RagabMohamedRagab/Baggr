using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.Manager {
    public class JTExpressCityZonesManager : IJTExpressCityZonesManager {
        private readonly IProvidersRepository<JTExpressCity> _jtexpresscity;
        private readonly IProvidersRepository<JTExpressZone> _jtexpressZone;
        private readonly IMapper _mapper;

        public JTExpressCityZonesManager(IProvidersRepository<JTExpressCity> jtexpresscity, IProvidersRepository<JTExpressZone> jtexpressZone, IMapper mapper)
        {
            _jtexpresscity = jtexpresscity;
            _jtexpressZone = jtexpressZone;
            _mapper = mapper;
        }

        public Task<ResultModel<JTExpressCityDTO>> CreateCities(JTExpressCityDTO tExpressCityDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<JTExpressCitiesPageDTO>> GetCities(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
