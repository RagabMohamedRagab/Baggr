using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.BLL.IManager
{
    public interface IAnalyticsManager
    {
        ResultModel<AnalyticsDTO> GetAnalytics(IEnumerable<ShipmentDTO> shipments);
    }
}
