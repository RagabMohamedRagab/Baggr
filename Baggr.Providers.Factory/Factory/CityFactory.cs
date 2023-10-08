using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Factory.Factory
{
    public class CityFactory : ICityFactory
    {
        private readonly ICityManager _cityManager;
        private readonly IMapper _mapper;
        public CityFactory(ICityManager cityManager,
                           IMapper mapper)
        {
            _cityManager = cityManager;
            _mapper = mapper;
        }
        public ResultModel<IEnumerable<CityDTO>> GetCities()
        {
            ResultModel<IEnumerable<City>> result = _cityManager.GetCities();
            return new ResultModel<IEnumerable<CityDTO>>(result.IsSuccess, result.StatusMessage,
                _mapper.Map< IEnumerable<City>, IEnumerable<CityDTO>>(result.Result));
        }
    }
}
