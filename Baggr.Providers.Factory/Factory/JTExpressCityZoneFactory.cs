using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.Factory {
    public class JTExpressCityZoneFactory : IJtExpressCityZoneFactory {
        public Task<ResultModel<JTExpressCityDTO>> CreateCity(JTExpressCityDTO tExpressCityDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<JTExpressCitiesPageDTO>> GetCities(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
