using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baggr.Providers.BLL.Manager
{
    public class AnalyticsManager : IAnalyticsManager
    {
        public ResultModel<AnalyticsDTO> GetAnalytics(IEnumerable<ShipmentDTO> shipments)
        {
            var analyticsDTO = new AnalyticsDTO();
            if (shipments.Any())
            {
                var deliveredStatus = new List<string>() { "delivered", "charges paid", "supporting document", "shipment update" };
                
                analyticsDTO.TotalNumOfShipments = shipments.Count();
                analyticsDTO.DeliverdOrdersCOD = shipments.Where(sh => sh.LastStatus != null && deliveredStatus.Any(ds => sh.LastStatus.ToLower().Contains(ds))).Sum(sh => sh.TotalAmountShouldBeCollected);
                analyticsDTO.ShipmentsPerCourier = shipments.GroupBy(sh => sh.Provider.Key).Select(gr => new { Provider = gr.FirstOrDefault().Provider, TotalShipments = gr.Count() });
                analyticsDTO.ShipmentsPerCities = shipments.GroupBy(sh => sh.CustomerCity).Select(gr => new { Provider = gr.Key, TotalShipments = gr.Count() }).OrderByDescending(gr => gr.TotalShipments).Take(5);
            }
            return new ResultModel<AnalyticsDTO>(true, StatusMessage.Ok, analyticsDTO);
        }
    }
}
