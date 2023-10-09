using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.IFactory {
    public interface IJtExpressCityZoneFactory {
        Task<ResultModel<JTExpressCityDTO>> CreateCity(JTExpressCityDTO tExpressCityDTO);
        Task<ResultModel<JTExpressCitiesPageDTO>> GetCities( int pageSize, int pageNumber);
        Task<ResultModel<JTExpressZoneDTO>> CreateZone(JTExpressZoneDTO tExpressZoneDTO);
        Task<ResultModel<JTExpressZonesPageDTO>> GetZones(int pageSize, int pageNumber);
    }
}
