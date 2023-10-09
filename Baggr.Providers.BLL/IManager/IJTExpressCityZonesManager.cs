using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.IManager {
    public interface IJTExpressCityZonesManager {
        Task<ResultModel<JTExpressCityDTO>> CreateCities(JTExpressCityDTO tExpressCityDTO);
        Task<ResultModel<JTExpressCitiesPageDTO>> GetCities(int pageSize, int pageNumber);
    }
}
