using AutoMapper;
using Baggr.Providers.DTO.AramexModels;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.J_TExpressModels;
using Baggr.Providers.Gateway.APIs;
using Baggr.Providers.Gateway.IAPIs;
using Baggr.Providers.IMP.ICompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.Company {
    public class JTExpressManager : IJTExpressManager {
        private readonly IJTExpressAPI _jTExpressAPI;
        private readonly IMapper _mapper;
        public JTExpressManager(IMapper mapper, IJTExpressAPI jTExpressAPI)
        {

            _mapper = mapper;
            _jTExpressAPI = jTExpressAPI;
        }

        // Provider Key is jtexpresskey
        public async Task<IEnumerable<ShipmentCreationResponseDTO>> CreateOrders(IEnumerable<ShipmentDTO> orderDTOs, Entities.Entities.Provider JTExpressProvider)
        {
            var jtExpress = _mapper.Map<IEnumerable<ShipmentDTO>, IEnumerable<JTExpressShipment>>(orderDTOs).ToList();
           
             foreach(JTExpressShipment order in jtExpress)
            {
                order.Consignee.City = Base.GetMappedName(JTExpressProvider, order.Consignee.City);
                order.Shipper.City = Base.GetMappedName(JTExpressProvider, order.Shipper.City);
                order.SendStartTime = DateTime.UtcNow.ToString();
             

            }

            var responseJTExpress = await _jTExpressAPI.CreateOrders(new JTExpressShipmentsCreationBody(jtExpress));
            if (responseJTExpress.HasErrors) return null;
            return _mapper.Map<IEnumerable<JTExpressShipmentResponse>, IEnumerable<ShipmentCreationResponseDTO>>(responseJTExpress.Shipments);
        }

        public async Task<GetPDFResponseDTO> GetPDF(string BillCode)
        {
            var body = new JTExpressGetPDFBody(BillCode);

            var pdfResponse = await _jTExpressAPI.GetPDF(body);
            return _mapper.Map<JTExpressGetPDFResponse, GetPDFResponseDTO>(pdfResponse);
        }



        public async Task<IEnumerable<ShipmentTrackingDTO>> GetTrackingShipments(IEnumerable<string> shipmentsBillCode)
        {
            if (shipmentsBillCode == null || !shipmentsBillCode.Any()) return new List<ShipmentTrackingDTO>();
            var trackingResponse = await _jTExpressAPI.GetTrackingShipments(new JTExpressTrackShipmentsBody(shipmentsBillCode));
            if (trackingResponse.HasErrors) return null;
            return _mapper.Map<IEnumerable<JTExpressTrackShipment>, IEnumerable<ShipmentTrackingDTO>>(trackingResponse.TrackingResults);
        }

        public async Task<IEnumerable<ShipmentTrackingLogDto>> GetTrackingShipmentLogs(string shipmentAWB)
        {
            if (string.IsNullOrEmpty(shipmentAWB)) return new List<ShipmentTrackingLogDto>();
            var trackingResponse = await _jTExpressAPI.GetTrackingShipments(new JTExpressTrackShipmentsBody(new List<string>() { shipmentAWB }));
            if (trackingResponse.HasErrors || trackingResponse.TrackingResults.Count() == 0) return new List<ShipmentTrackingLogDto>();
            var shipmentLogs = trackingResponse.TrackingResults.FirstOrDefault().Value.ToList();

            var shipmentLogsDtos = new List<ShipmentTrackingLogDto>();
            MapShipmentLogsDtos(shipmentLogs, shipmentLogsDtos);

            return shipmentLogsDtos;
        }

        private static void MapShipmentLogsDtos(List<JTExpressShipmentLogs> shipmentLogs, List<ShipmentTrackingLogDto> shipmentLogsDtos)
        {
            shipmentLogs.ForEach(sh =>
            {
                var replaced = sh.UpdateDateTime.Replace(')', '(').Replace('+', '(');
                var shipmenLogDto = new ShipmentTrackingLogDto();
                var unixUtcString = replaced.Split('(')[1];
                if (long.TryParse(unixUtcString, out var unixUtc))
                    shipmenLogDto.ChangedDate = DateTimeOffset.FromUnixTimeMilliseconds(unixUtc).DateTime;
                shipmenLogDto.StatusEnName = sh.UpdateDescription;
                shipmentLogsDtos.Add(shipmenLogDto);
            });
        }
    }
}
