using AutoMapper;
using Baggr.Providers.DTO.AramexModels;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Baggr.Providers.Gateway.IAPIs;
using Baggr.Providers.IMP.Company;
using Baggr.Providers.IMP.IProvider;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.Provider
{
    public class AramexManager : IAramexManager
    {
        private readonly IAramexAPI _aramexAPI;
        private readonly IMapper _mapper;
        public AramexManager(IAramexAPI aramexAPI, IMapper mapper)
        {
            _aramexAPI = aramexAPI;
            _mapper = mapper;
        }
        public async Task<GetQuoteDTO> GetQuote(IEnumerable<Baggr.Providers.Entities.Entities.Provider> providers, string fromCity, string toCity, double weight)
        {
            var aramexProvider = providers.Where(p => p.Key == "aramexKey").FirstOrDefault();
            var body = new AramexGetQuoteBody();
            body.DestinationAddress.City = Base.GetMappedName(aramexProvider, toCity);
            body.OriginAddress.City = Base.GetMappedName(aramexProvider, fromCity);
            body.ShipmentDetails.ActualWeight.Value = weight;
            AramexGetQuoteResponse result = await _aramexAPI.GetQuote(body);
            if (result == null || result.TotalAmount?.Value < 1) return null;
            return new GetQuoteDTO(aramexProvider.ProviderName, aramexProvider.ProviderLogo, Math.Round(result.TotalAmount.Value, 2), aramexProvider.Key, _mapper.Map<Baggr.Providers.Entities.Entities.Provider, ProviderDTO>(aramexProvider));
        }
        public async Task<IEnumerable<ShipmentCreationResponseDTO>> CreatePickupOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider aramexProvider)
        {
            var aramexOrders = _mapper.Map<IEnumerable<ShipmentDTO>, IEnumerable<AramexShipment>>(orderDTOs).ToList();
            foreach (AramexShipment order in aramexOrders)
            {
                order.Consignee.PartyAddress.City = Base.GetMappedName(aramexProvider, order.Consignee.PartyAddress.City);
                order.Shipper.PartyAddress.City = Base.GetMappedName(aramexProvider, order.Shipper.PartyAddress.City);
                order.ShippingDateTime = "/Date(" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ")/";
                order.DueDate = "/Date(" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ")/";
                if (order.Details.CashOnDeliveryAmount.Value <= 0) order.Details.CashOnDeliveryAmount = null;
            }
            var response = await _aramexAPI.CreatePickupOrders(new AramexPickupCreationBody(aramexOrders));
            if (response.HasErrors) return null;
            return _mapper.Map<IEnumerable<AramexShipmentResponse>, IEnumerable<ShipmentCreationResponseDTO>>(response.ProcessedPickup.ProcessedShipments);
        }
        public async Task<IEnumerable<ShipmentCreationResponseDTO>> CreateOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider aramexProvider)
        {
            var aramexOrders = _mapper.Map<IEnumerable<ShipmentDTO>, IEnumerable<AramexShipment>>(orderDTOs).ToList();
            foreach (AramexShipment order in aramexOrders)
            {
                order.Consignee.PartyAddress.City = Base.GetMappedName(aramexProvider, order.Consignee.PartyAddress.City);
                order.Shipper.PartyAddress.City = Base.GetMappedName(aramexProvider, order.Shipper.PartyAddress.City);
                order.ShippingDateTime = "/Date(" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()+")/";
                order.DueDate = "/Date(" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ")/";
                if (order.Details.CashOnDeliveryAmount.Value <= 0) order.Details.CashOnDeliveryAmount = null;
            }
            var response = await _aramexAPI.CreateOrders(new AramexShipmentsCreationBody(aramexOrders));
            if (response.HasErrors) return null;
            return _mapper.Map<IEnumerable<AramexShipmentResponse>, IEnumerable<ShipmentCreationResponseDTO>>(response.Shipments);
        }
        public async Task<GetPDFResponseDTO> GetPDF(string AWB)
        {
            var body = new AramexGetPDFBody(AWB);

            var pdfResponse = await _aramexAPI.GetPDF(body);
            return _mapper.Map<AramexGetPDFResponse, GetPDFResponseDTO>(pdfResponse);
        }
        public async Task<IEnumerable<ShipmentTrackingDTO>> GetTrackingShipments(IEnumerable<string> shipmentsAWB)
        {
            if (shipmentsAWB == null || !shipmentsAWB.Any()) return new List<ShipmentTrackingDTO>();
            var trackingResponse = await _aramexAPI.GetTrackingShipments(new AramexTrackShipmentsBody(shipmentsAWB));
            if (trackingResponse.HasErrors) return null;
            return _mapper.Map<IEnumerable<AramexTrackShipment>, IEnumerable<ShipmentTrackingDTO>>(trackingResponse.TrackingResults);
        }

        public async Task<IEnumerable<ShipmentTrackingLogDto>> GetTrackingShipmentLogs(string shipmentAWB)
        {
            if (string.IsNullOrEmpty(shipmentAWB)) return new List<ShipmentTrackingLogDto>();
            var trackingResponse = await _aramexAPI.GetTrackingShipments(new AramexTrackShipmentsBody(new List<string>() { shipmentAWB }));
            if (trackingResponse.HasErrors || trackingResponse.TrackingResults.Count() == 0) return new List<ShipmentTrackingLogDto>();
            var shipmentLogs = trackingResponse.TrackingResults.FirstOrDefault().Value.ToList();

            var shipmentLogsDtos = new List<ShipmentTrackingLogDto>();
            MapShipmentLogsDtos(shipmentLogs, shipmentLogsDtos);

            return shipmentLogsDtos;
        }

        private static void MapShipmentLogsDtos(List<AramexShipmentLogs> shipmentLogs, List<ShipmentTrackingLogDto> shipmentLogsDtos)
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
