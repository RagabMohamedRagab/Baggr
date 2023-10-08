using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.BLL.IManager
{
    public interface IShipmentManager
    {
        Task<ResultModel<IEnumerable<GetQuoteDTO>>> GetQuote(string fromCity, string toCity, double weight);
        Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> CreateShipments(ShipmentBulkDTO orderBulkDTO, Provider provider);
        ResultModel<ShipmentsPageDTO> GetShipments(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime? from, DateTime? to, Boolean? isFulfilled);
        Task<ResultModel<GetPDFResponseDTO>> GetShipmentPDF(Shipment shipment);
        Task<ResultModel<Shipment>> GetShipmentByKey(string shipmentKey, bool statusIncluded = true);
        Task<ResultModel<String>> HideShipments(IEnumerable<string> shipmentkeys);
        Task<ResultModel<ShipmentDTO>> GetShipmentByKeyWithStatusLogs(string shipmentKey, bool statusIncluded = true);


    }
}
