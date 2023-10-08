using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DAL;
using Baggr.Providers.DTO;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baggr.Providers.BLL.Manager
{
    public class CityManager : ICityManager
    {
        private readonly IProvidersRepository<City> _providersRepository;
        public CityManager(IProvidersRepository<City> providersRepository)
        {
            _providersRepository = providersRepository;
        }
        public ResultModel<IEnumerable<City>> GetCities()
        {
            var cities = _providersRepository.GetAll();
            return new ResultModel<IEnumerable<City>>(true, StatusMessage.Ok, cities.ToList());
        }
    }
}
