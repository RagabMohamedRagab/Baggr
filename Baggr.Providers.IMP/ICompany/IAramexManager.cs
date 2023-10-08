using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.IProvider
{
    public interface IAramexManager
    {
        public Task<GetQuoteDTO> GetQuote(IEnumerable<Baggr.Providers.Entities.Entities.Provider> providers, string fromCity, string toCity, double weight);
        public Task<IEnumerable<ShipmentCreationResponseDTO>> CreateOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider aramexProvider);
        public Task<IEnumerable<ShipmentCreationResponseDTO>> CreatePickupOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider aramexProvider);
        public Task<GetPDFResponseDTO> GetPDF(string AWB);
        public Task<IEnumerable<ShipmentTrackingDTO>> GetTrackingShipments(IEnumerable<string> ShipmentsAWB);
        public Task<IEnumerable<ShipmentTrackingLogDto>> GetTrackingShipmentLogs(string shipmentAWB);
    }
}
