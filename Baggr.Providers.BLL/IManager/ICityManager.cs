using Baggr.Providers.DTO;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.BLL.IManager
{
    public interface ICityManager
    {
        ResultModel<IEnumerable<City>> GetCities();
    }
}
