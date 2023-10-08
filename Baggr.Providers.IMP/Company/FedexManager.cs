using AutoMapper;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.FedexModels;
using Baggr.Providers.Gateway.IAPIs;
using Baggr.Providers.IMP.ICompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.IMP.Company
{
    public class FedexManager : IFedexManager
    {
        private readonly IFedexAPI _fedexAPI;
        private readonly IMapper _mapper;
        public FedexManager(IFedexAPI fedexAPI, IMapper mapper)
        {
            _fedexAPI = fedexAPI;
            _mapper = mapper;
        }
        public async Task<GetQuoteDTO> GetQuote(IEnumerable<Baggr.Providers.Entities.Entities.Provider> providers, string fromCity, string toCity, double weight)
        {
            var fedexProvider = providers.Where(p => p.Key == "fedexKey").FirstOrDefault();
            var body = new FedexGetQuoteBody();
            body.Destination = Base.GetMappedName(fedexProvider, toCity);
            body.Origin = Base.GetMappedName(fedexProvider, fromCity);
            body.Weight = weight;
            FedexGetQuoteResponse result = await _fedexAPI.GetQuote(body);
            if (result == null || result.NetAmount < 1) return null;
            return new GetQuoteDTO(fedexProvider.ProviderName, fedexProvider.ProviderLogo, Math.Round(result.NetAmount, 2), fedexProvider.Key, _mapper.Map<Baggr.Providers.Entities.Entities.Provider, ProviderDTO>(fedexProvider));

        }
        public async Task<IEnumerable<ShipmentCreationResponseDTO>> CreateOrders(IEnumerable<ShipmentDTO> orderDTOs, Baggr.Providers.Entities.Entities.Provider fedexProvider)
        {
            var fedexResponses = new List<FedexShipmentCreationResponse>();

            var fedexOrders = _mapper.Map<IEnumerable<ShipmentDTO>, IEnumerable<FedexShipmentCreationBody>>(orderDTOs);

            IList<Task> tasks = new List<Task>();
            foreach (FedexShipmentCreationBody order in fedexOrders)
            {
                order.AirwayBillData.Destination = Base.GetMappedName(fedexProvider, order.AirwayBillData.Destination);
                order.AirwayBillData.Origin = Base.GetMappedName(fedexProvider, order.AirwayBillData.Origin);
                //tasks.Add(_fedexAPI.CreateOrder(order));
                fedexResponses.Add(await _fedexAPI.CreateOrder(order));
            }

            var pickupResult = await CreatePickup(fedexOrders.FirstOrDefault());
            if (pickupResult.Code != 1) return null;

            // await Task.WhenAll(tasks);

            foreach (Task<FedexShipmentCreationResponse> task in tasks)
                fedexResponses.Add(task.Result);

            return _mapper.Map<IEnumerable<FedexShipmentCreationResponse>, IEnumerable<ShipmentCreationResponseDTO>>(fedexResponses);
        }
        private async Task<FedexPickupCreationResponse> CreatePickup(FedexShipmentCreationBody fedexShipmentCreationBody)
        {
            var body = _mapper.Map<FedexShipmentCreationBody, FedexPickupCreationBody>(fedexShipmentCreationBody);
            return await _fedexAPI.CreatePickup(body);
        }
        public async Task<IEnumerable<ShipmentTrackingDTO>> GetTrackingShipments(IEnumerable<string> shipmentsAWB)
        {
            if (shipmentsAWB == null || !shipmentsAWB.Any()) return new List<ShipmentTrackingDTO>();
            IList<Task> tasks = new List<Task>();
            var fedexResponses = new List<FedexTrackShipmentResponse>();
            foreach (string awb in shipmentsAWB)
            {
                var body = new FedexTrackShipmentBody(awb);
                var response = await _fedexAPI.TrackShipment(body);
                if(response == null) return new List<ShipmentTrackingDTO>();
                fedexResponses.Add(response);
            }
            /*await Task.WhenAll(tasks);
            var fedexResponses = new List<FedexTrackShipmentResponse>();
            foreach (Task<FedexTrackShipmentResponse> task in tasks)
                fedexResponses.Add(task.Result);*/

            return _mapper.Map<IEnumerable<FedexTrackShipmentResponse>, IEnumerable<ShipmentTrackingDTO>>(fedexResponses);
        }
        public async Task<GetPDFResponseDTO> GetPDF(string AWB)
        {
            var body = new FedexGetPDFBody();
            body.AirwayBillNumber = AWB;

            var pdfResponse = await _fedexAPI.GetPDF(body);
            return _mapper.Map<FedexGetPDFResponse, GetPDFResponseDTO>(pdfResponse);
        }

        public async Task<(IEnumerable<ShipmentTrackingLogDto>, string)> GetTrackingShipmentLogs(string shipmentAWB)
        {
            if (string.IsNullOrEmpty(shipmentAWB)) return (new List<ShipmentTrackingLogDto>(), null);
            IList<Task> tasks = new List<Task>();


            var body = new FedexTrackShipmentBody(shipmentAWB);
            var response = await _fedexAPI.TrackShipment(body);


            /*await Task.WhenAll(tasks);
            var fedexResponses = new List<FedexTrackShipmentResponse>();
            foreach (Task<FedexTrackShipmentResponse> task in tasks)
                fedexResponses.Add(task.Result);*/
            var trackingLogs = _mapper.Map<IEnumerable<FedexTrackingLogDetails>, 
                IEnumerable<ShipmentTrackingLogDto>>(response.AirwayBillTrackList.FirstOrDefault().TrackingLogDetails);
            trackingLogs.FirstOrDefault().StatusEnName = response.AirwayBillTrackList.FirstOrDefault().LastStatus;
            return (trackingLogs, response.AirwayBillTrackList.FirstOrDefault().LastStatus);
        }
    }
}
