using AutoMapper;
using Baggr.Providers.BLL.IManager;
using Baggr.Providers.DTO;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Entities.Entities;
using Baggr.Providers.Factory.IFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Factory.Factory
{
    public class ShipmentFactory : IShipmentFactory
    {
        private readonly IShipmentManager _shipmentManager;
        private readonly IProviderManager _providerManager;
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;
        public ShipmentFactory(IShipmentManager shipmentManager, IProviderManager providerManager, IMapper mapper, IOrderManager orderManager)
        {
            _shipmentManager = shipmentManager;
            _providerManager = providerManager;
            _mapper = mapper;
            _orderManager = orderManager;
        }
        public async Task<ResultModel<IEnumerable<GetQuoteDTO>>> GetQuote(string fromCity, string toCity, double weight)
        {
            return await _shipmentManager.GetQuote(fromCity, toCity, weight);
        }
        public async Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> createShipments(ShipmentBulkDTO shipmentBulkDTO)
        {
            var provider = await _providerManager.GetProviderByKey(shipmentBulkDTO.ProviderKey);
            if (!provider.IsSuccess) return new ResultModel<IEnumerable<ShipmentCreationResponseDTO>>(false, StatusMessage.BadRequest);
            var result = await _shipmentManager.CreateShipments(shipmentBulkDTO, provider.Result);
            await _orderManager.DeleteOrderByKeys(shipmentBulkDTO.Shipments.Select(sh => sh.Key).ToList());
            return result;
        }
        public ResultModel<ShipmentsPageDTO> GetShipments(string merchantKey, string searchTerm, int PageSize, int PageNumber, DateTime? from, DateTime? to, Boolean? isFulfilled)
        {
            return _shipmentManager.GetShipments(merchantKey, searchTerm, PageSize, PageNumber, from, to, isFulfilled);
        }
        public async Task<ResultModel<GetPDFResponseDTO>> GetShipmentPDF(string shipmentKey)
        {
            var shipmentResult = await _shipmentManager.GetShipmentByKey(shipmentKey, false);
            if (!shipmentResult.IsSuccess) return new ResultModel<GetPDFResponseDTO>(false, StatusMessage.NotFound);
            return await _shipmentManager.GetShipmentPDF(shipmentResult.Result);
        }
        public async Task<ResultModel<ShipmentDTO>> GetShipmentByKey(string shipmentKey)
        {
            var shipmentResult = await _shipmentManager.GetShipmentByKeyWithStatusLogs(shipmentKey);
            if (!shipmentResult.IsSuccess) return new ResultModel<ShipmentDTO>(false, StatusMessage.NotFound);
            return new ResultModel<ShipmentDTO>(true, StatusMessage.Ok, shipmentResult.Result); 
        }
        public async Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> ReturnShipment(string shipmentKey)
        {
            var shipmentResult = await _shipmentManager.GetShipmentByKey(shipmentKey, false);
            shipmentResult.Result.TotalAmountShouldBeCollected = 0;
            shipmentResult.Result.Note = "Return Shipment " + shipmentResult.Result.Note;
            var orderBulk = new ShipmentBulkDTO() { ProviderKey = shipmentResult.Result.Provider.Key, Shipments = new List<ShipmentDTO>() { ReturnShipmentMapper(_mapper.Map<Shipment, ShipmentDTO>(shipmentResult.Result)) } };
            return await _shipmentManager.CreateShipments(orderBulk, shipmentResult.Result.Provider);
        }
        public async Task<ResultModel<IEnumerable<ShipmentCreationResponseDTO>>> ReturnAndPickupShipment(string shipmentKey)
        {
            var shipmentResult = await _shipmentManager.GetShipmentByKey(shipmentKey, false);
            var shipmentDTO = _mapper.Map<Shipment, ShipmentDTO>(shipmentResult.Result);
            shipmentDTO.Note = "Return and Pickup Shipment" + shipmentDTO.Note;
            var orderBulk = new ShipmentBulkDTO() { ProviderKey = shipmentResult.Result.Provider.Key, Shipments = new List<ShipmentDTO>() { ReturnShipmentMapper(shipmentDTO)} };
            return await _shipmentManager.CreateShipments(orderBulk, shipmentResult.Result.Provider);
        }
        public async Task<ResultModel<String>> HideShipments(IEnumerable<string> shipmentkeys)
        {
            return await _shipmentManager.HideShipments(shipmentkeys);
        }
        private ShipmentDTO ReturnShipmentMapper(ShipmentDTO shipmentDTO)
        {
            ShipmentDTO result =  shipmentDTO.Clone();
            result.MerchantName = shipmentDTO.CustomerName;
            result.MerchantAddress = shipmentDTO.CustomerAddress;
            result.MerchantCity = shipmentDTO.CustomerCity;
            result.MerchantPhoneNum = shipmentDTO.CustomerPhoneNum;
            result.CustomerAddress = shipmentDTO.MerchantAddress;
            result.CustomerCity = shipmentDTO.MerchantCity;
            result.CustomerName = shipmentDTO.MerchantName;
            result.CustomerPhoneNum = shipmentDTO.MerchantPhoneNum;
            return result;
        }
    }
}
