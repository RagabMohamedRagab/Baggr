using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.ICompany {
    public interface IJTExpressManager {
        
       public  Task<IEnumerable<ShipmentCreationResponseDTO>> CreateOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider JTExpressProvider);
        public Task<IEnumerable<ShipmentTrackingDTO>> GetTrackingShipments(IEnumerable<string> shipmentsAWB);
        public Task<IEnumerable<ShipmentTrackingLogDto>> GetTrackingShipmentLogs(string shipmentAWB);
        public Task<GetPDFResponseDTO> GetPDF(string BillCode);
    }
}
