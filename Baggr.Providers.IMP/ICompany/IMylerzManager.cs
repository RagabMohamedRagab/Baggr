using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.MylerzModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.ICompany
{
    public interface IMylerzManager
    {
        public Task<GetQuoteDTO> GetQuote(IEnumerable<Baggr.Providers.Entities.Entities.Provider> providers, string fromCity, string toCity, double weight);
        public Task<IEnumerable<ShipmentCreationResponseDTO>> CreateOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider mylerzProvider);
        public Task<GetPDFResponseDTO> GetPDF(string AWB);
        public Task<IEnumerable<ShipmentTrackingDTO>> GetTrackingShipments(IEnumerable<string> shipmentsAWB);
        Task<IEnumerable<ShipmentTrackingLogDto>> GetTrackingShipmentLogs(IEnumerable<MylerzGetTrackingShipmentLogsBody> shipmentsAWB);


    }
}
