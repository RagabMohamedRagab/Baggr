using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.IFactory
{
    public interface IShipmentFactory
    {
        Task<ResultModel<IEnumerable<GetQuoteDTO>>> GetQuote(string fromCity, string toCity, double weight);
        Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> createShipments(ShipmentBulkDTO shipmentBulkDTO);
        ResultModel<ShipmentsPageDTO> GetShipments(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime? from, DateTime? to, Boolean? isFulfilled);
        Task<ResultModel<GetPDFResponseDTO>> GetShipmentPDF(string shipmentKey);
        Task<ResultModel<ShipmentDTO>> GetShipmentByKey(string shipmentKey);
        Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> ReturnShipment(string shipmentKey);
        Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> ReturnAndPickupShipment(string shipmentKey);
        Task<ResultModel<String>> HideShipments(IEnumerable<string> shipmentkeys);
    }
}
