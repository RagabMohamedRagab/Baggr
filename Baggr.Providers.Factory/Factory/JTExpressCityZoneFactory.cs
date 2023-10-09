using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.Factory {
    public class JTExpressCityZoneFactory : IJtExpressCityZoneFactory {
        private readonly IJTExpressCityZonesManager _jTExpressCityZones;
        private readonly IMapper _mapper;

        public JTExpressCityZoneFactory(IMapper mapper, IJTExpressCityZonesManager jTExpressCityZones)
        {
            _mapper = mapper;
            _jTExpressCityZones = jTExpressCityZones;
        }

        public async Task<ResultModel<JTExpressCityDTO>> CreateCity(JTExpressCityDTO tExpressCityDTO)
        {
            var result = await _jTExpressCityZones.CreateCity(tExpressCityDTO);
            return new ResultModel<JTExpressCityDTO>(true, StatusMessage.Ok, _mapper.Map<JTExpressCityDTO>(result.Result));
        }


        public Task<ResultModel<JTExpressCitiesPageDTO>> GetCities(int pageSize, int pageNumber)
        {
            var result = _jTExpressCityZones.GetCities(pageSize, pageNumber);
            return result;
        }
        public async Task<ResultModel<JTExpressZoneDTO>> CreateZone(JTExpressZoneDTO tExpressZoneDTO)
        {
            var result = await _jTExpressCityZones.CreateZone(tExpressZoneDTO);
            return new ResultModel<JTExpressZoneDTO>(true, StatusMessage.Ok, _mapper.Map<JTExpressZoneDTO>(result.Result));
        }

        public async Task<ResultModel<JTExpressZonesPageDTO>> GetZones(int pageSize, int pageNumber)
        {
            var result = await _jTExpressCityZones.GetZones(pageSize, pageNumber);
            return result;
        }
    }
}
