using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.Factory.Factory
{
    public class AnalyticsFactory : IAnalyticsFactory
    {
        private readonly IShipmentManager _shipmentManager;
        private readonly IAnalyticsManager _analyticsManager;
        public AnalyticsFactory(IShipmentManager shipmentManager, IAnalyticsManager analyticsManager)
        {
            _shipmentManager = shipmentManager;
            _analyticsManager = analyticsManager;
        }
        public ResultModel<AnalyticsDTO> GetAnalytics(string merchantKey, DateTime from, DateTime to)
        {
            var shipments = _shipmentManager.GetShipments(merchantKey, null, 1000, 1, from, to, null);
            return _analyticsManager.GetAnalytics(shipments.Result.Shipments);
        }
    }
}
