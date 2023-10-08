using AutoMapper;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.MylerzModels;
using Baggr.Providers.Gateway.IAPIs;
using Baggr.Providers.IMP.ICompany;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.Company
{
    public class MylerzManager : IMylerzManager
    {
        private readonly MylerzConfig _mylerzConfig;
        private readonly IMylerzAPI _mylerzAPI;
        private readonly IMapper _mapper;
        public MylerzManager(IMylerzAPI mylerzAPI, IMapper mapper, IOptions<MylerzConfig> mylerzConfig)
        {
            _mylerzAPI = mylerzAPI;
            _mapper = mapper;
            _mylerzConfig = mylerzConfig.Value;
        }
        public async Task<GetQuoteDTO> GetQuote(IEnumerable<Baggr.Providers.Entities.Entities.Provider> providers, string fromCity, string toCity, double weight)
        {
            var tokenRes = await _mylerzAPI.GetToken(_mylerzConfig.URL);
            var mylerzProvider = providers.Where(p => p.Key == "mylerzKey").FirstOrDefault();
            var warehouse = new Warehouse("GetQuote", fromCity);
            var warehouseRes = await CreateWarehouse(mylerzProvider, warehouse, fromCity);
            var getQuoteBody = new MylerzGetQuoteBody();
            getQuoteBody.CustomerZoneCode = Base.GetMappedName(mylerzProvider, toCity);
            getQuoteBody.WarehouseName = warehouse.Name;
            getQuoteBody.PackageWeight = weight;
            MylerzGetQuoteResponse result = await _mylerzAPI.GetQuote(getQuoteBody, tokenRes.access_token);
            if (result.IsErrorState) return null;
            return new GetQuoteDTO(mylerzProvider.ProviderName, mylerzProvider.ProviderLogo, Math.Abs(result.Value.NetTransferValue), mylerzProvider.Key, _mapper.Map<Baggr.Providers.Entities.Entities.Provider, ProviderDTO>(mylerzProvider));
        }
        
        private async Task<MylerzCreateAddressResponse> CreateWarehouse(Baggr.Providers.Entities.Entities.Provider mylerz, Warehouse warehouse, string city)
        {
            warehouse.SubZoneId = Base.GetSubZoneId(mylerz, city);
            var addressBody = new MylerzCreateAddressBody(warehouse);
            var tokenRes = await _mylerzAPI.GetToken(_mylerzConfig.PortalURL);
            return await _mylerzAPI.CreateAddress(addressBody, tokenRes.access_token);
        }
        public async Task<IEnumerable<ShipmentCreationResponseDTO>> CreateOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider mylerzProvider)
        {
            var warehouse = new Warehouse(orderDTOs.FirstOrDefault().MerchantName, orderDTOs.FirstOrDefault().MerchantAddress, orderDTOs.FirstOrDefault().MerchantPhoneNum, orderDTOs.FirstOrDefault().MerchantName);
            var warehouseRes = await CreateWarehouse(mylerzProvider, warehouse, orderDTOs.FirstOrDefault().MerchantCity);
            warehouse.ID = warehouseRes.Value.LastOrDefault().ID;
            warehouseRes = await CreateWarehouse(mylerzProvider, warehouse, orderDTOs.FirstOrDefault().MerchantCity);

            var tokenRes = await _mylerzAPI.GetToken(_mylerzConfig.URL);

            var mylerzShipments = _mapper.Map<IEnumerable<ShipmentDTO>, IEnumerable<MylerzShipment>>(orderDTOs);

            foreach (MylerzShipment shipment in mylerzShipments)
            {
                shipment.Neighborhood = Base.GetMappedName(mylerzProvider, shipment.Neighborhood);
                shipment.WarehouseName = warehouse.Name;
            }

            var ordersRes = await _mylerzAPI.CreateOrders(mylerzShipments, tokenRes.access_token);


            var pickupRes = await _mylerzAPI.CreatePickup(ordersRes.Value.Packages, tokenRes.access_token);

            return _mapper.Map<IEnumerable<MylerzPackage>, IEnumerable<ShipmentCreationResponseDTO>>(ordersRes.Value.Packages);
        }
        public async Task<GetPDFResponseDTO> GetPDF(string AWB)
        {
            var body = new MylerzGetPDFBody(AWB);

            var tokenRes = await _mylerzAPI.GetToken(_mylerzConfig.URL);
            var pdfResponse = await _mylerzAPI.GetPDF(body, tokenRes.access_token);
            return _mapper.Map<MylerzGetPDFResponse, GetPDFResponseDTO>(pdfResponse);
        }
        public async Task<IEnumerable<ShipmentTrackingDTO>> GetTrackingShipments(IEnumerable<string> shipmentsAWB)
        {
            if (shipmentsAWB == null || !shipmentsAWB.Any()) return new List<ShipmentTrackingDTO>();
            var tokenRes = await _mylerzAPI.GetToken(_mylerzConfig.URL);
            var trackingResponse = await _mylerzAPI.GetTrackingShipments(shipmentsAWB, tokenRes.access_token);
            if (trackingResponse.IsErrorState) return null;
            return _mapper.Map<IEnumerable<MylerzTrackShipmentValue>, IEnumerable<ShipmentTrackingDTO>>(trackingResponse.Value);
        }

        public async Task<IEnumerable<ShipmentTrackingLogDto>> GetTrackingShipmentLogs(IEnumerable<MylerzGetTrackingShipmentLogsBody> shipmentsAWB)
        {
            if (shipmentsAWB == null || !shipmentsAWB.Any()) return new List<ShipmentTrackingLogDto>();
            var tokenRes = await _mylerzAPI.GetToken(_mylerzConfig.URL);
            var trackingResponse = await _mylerzAPI.GetTrackingShipmentLogs(shipmentsAWB, tokenRes.access_token);
            if (trackingResponse.IsErrorState) return null;
            trackingResponse.Value.FirstOrDefault().TrackLog = trackingResponse.Value.FirstOrDefault().TrackLog.OrderByDescending(x => x.ChangedDate);
            return _mapper.Map<IEnumerable<MylerzGetTrackingShipmentLogsResponse.TrackLog>,
                IEnumerable<ShipmentTrackingLogDto>>(trackingResponse.Value.FirstOrDefault().TrackLog);
        }
    }
}
