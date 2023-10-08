using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Factory.IFactory
{
    public interface ICityFactory
    {
        public ResultModel<IEnumerable<CityDTO>> GetCities();
    }
}
