using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Baggr.Providers.Entities.Entities;

namespace Baggr.Providers.BLL.IManager {
    public interface IJTExpressCityZonesManager {
        Task<ResultModel<JTExpressCity>> CreateCity(JTExpressCityDTO tExpressCityDTO);
        Task<ResultModel<JTExpressCitiesPageDTO>> GetCities(int pageSize, int pageNumber);
        Task<ResultModel<JTExpressZone>> CreateZone(JTExpressZoneDTO tExpressZoneDTO);
        Task<ResultModel<JTExpressZonesPageDTO>> GetZones(int pageSize, int pageNumber);
    }
}
