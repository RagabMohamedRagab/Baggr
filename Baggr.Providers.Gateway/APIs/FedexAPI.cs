using Baggr.Providers.DTO.FedexModels;
using Baggr.Providers.Gateway.IAPIs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Gateway.APIs
{
    public class FedexAPI : IFedexAPI
    {
        private readonly FedexConfig _fedexConfig;

        public FedexAPI(IOptions<FedexConfig> fedexConfig)
        {
            _fedexConfig = fedexConfig.Value;
        }
        public async Task<FedexGetQuoteResponse> GetQuote(FedexGetQuoteBody fedexGetQuoteBody)
        {
            IRestResponse response = await APICall.Excute(_fedexConfig.URL, _fedexConfig.GetQuoteEndpoint, Method.POST
                , fedexGetQuoteBody, null, null);
            var result = JsonConvert.DeserializeObject<FedexGetQuoteResponse>(response.Content);
            return result;
        }
        public async Task<FedexShipmentCreationResponse> CreateOrder(FedexShipmentCreationBody fedexOrderCreationBody)
        {
            IRestResponse response = await APICall.Excute(_fedexConfig.URL, _fedexConfig.CreateOrderEndpoint, Method.POST
                , fedexOrderCreationBody, null, null);
            return JsonConvert.DeserializeObject<FedexShipmentCreationResponse>(response.Content);
        }
        public async Task<FedexPickupCreationResponse> CreatePickup(FedexPickupCreationBody fedexPickupCreationBody)
        {
            IRestResponse response = await APICall.Excute(_fedexConfig.URL, _fedexConfig.CreatePickUpEndpoint, Method.POST
                , fedexPickupCreationBody, null, null);
            return JsonConvert.DeserializeObject<FedexPickupCreationResponse>(response.Content);
        }
        public async Task<FedexGetPDFResponse> GetPDF(FedexGetPDFBody fedexGetPDFBody)
        {
            IRestResponse response = await APICall.Excute(_fedexConfig.URL, _fedexConfig.GetAWBPDF, Method.POST
                , fedexGetPDFBody, null, null);
            return JsonConvert.DeserializeObject<FedexGetPDFResponse>(response.Content);
        }
        public async Task<FedexTrackShipmentResponse> TrackShipment(FedexTrackShipmentBody fedexTrackShipmentBody)
        {
            IRestResponse response = await APICall.Excute(_fedexConfig.URL, _fedexConfig.TrackShipmentEndpoint, Method.POST
                , fedexTrackShipmentBody, null, null);
            return JsonConvert.DeserializeObject<FedexTrackShipmentResponse>(response.Content);
        }
    }
}
