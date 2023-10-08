using System;
using System.Collections.Generic;
using System.Text;

namespace Baggr.Providers.DTO.DTOs
{
    public class AnalyticsDTO
    {
        public int TotalNumOfShipments { get; set; }
        public double DeliverdOrdersCOD { get; set; }
        public Object ShipmentsPerCourier { get; set; }
        public Object ShipmentsPerCities { get; set; }
    }
}
