using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Microsoft.EntityFrameworkCore;
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
        #region City
        public async Task<ResultModel<JTExpressCity>> CreateCity(JTExpressCityDTO tExpressCityDTO)
        {
            var city = _mapper.Map<JTExpressCity>(tExpressCityDTO);
            _jtexpresscity.Add(city);
            return new ResultModel<JTExpressCity>(true, StatusMessage.Ok, city);
        }

      

        public async Task<ResultModel<JTExpressCitiesPageDTO>> GetCities(int pageSize, int pageNumber)
        {
            var JTcities =await _jtexpresscity.GetAll().ToListAsync();
            var TotalCount = JTcities.Count;

            int PagesCount = (int)Math.Ceiling(TotalCount / ((double)pageSize == 0 ? 1 : (double)pageSize));

            JTExpressCitiesPageDTO citiesPageDTO = new JTExpressCitiesPageDTO()
            {
                PagesCount = PagesCount,
                TotalCount = TotalCount,
                CityDTOs = _mapper.Map<IList<JTExpressCityDTO>>(JTcities)
            };
           return new ResultModel<JTExpressCitiesPageDTO>(true, StatusMessage.Ok, citiesPageDTO);
        }
        #endregion

        #region Zone
        public async Task<ResultModel<JTExpressZone>> CreateZone(JTExpressZoneDTO tExpressZoneDTO)
        {
            var zone = _mapper.Map<JTExpressZone>(tExpressZoneDTO);
            _jtexpressZone.Add(zone);
            return new ResultModel<JTExpressZone>(true, StatusMessage.Ok, zone);
        }

        public async Task<ResultModel<JTExpressZonesPageDTO>> GetZones(int pageSize, int pageNumber)
        {
            var JTZones = await  _jtexpressZone.GetAll().ToListAsync();
            var TotalCount = JTZones.Count;

            int PagesCount = (int)Math.Ceiling(TotalCount / ((double)pageSize == 0 ? 1 : (double)pageSize));

            JTExpressZonesPageDTO ZonesPageDTO = new JTExpressZonesPageDTO()
            {
                PagesCount = PagesCount,
                TotalCount = TotalCount,
                CityDTOs = _mapper.Map<IList<JTExpressZoneDTO>>(JTZones)
            };
            return new ResultModel<JTExpressZonesPageDTO>(true, StatusMessage.Ok,ZonesPageDTO);
        }
        #endregion
    }
}
