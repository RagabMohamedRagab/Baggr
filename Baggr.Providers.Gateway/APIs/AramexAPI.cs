using Baggr.Providers.DTO.AramexModels;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.Gateway.IAPIs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Baggr.Providers.Gateway.APIs
{
    public class AramexAPI : IAramexAPI
    {
        private readonly AramexConfig _aramexConfig;

        public AramexAPI(IOptions<AramexConfig> aramexConfig)
        {
            _aramexConfig = aramexConfig.Value;
        }

        public async Task<AramexGetQuoteResponse> GetQuote(AramexGetQuoteBody aramexGetQuoteBody)
        {
            IRestResponse response = await APICall.Excute(_aramexConfig.URL, _aramexConfig.GetQuoteEndpoint, Method.POST
                , aramexGetQuoteBody, null, null);
            return JsonConvert.DeserializeObject<AramexGetQuoteResponse>(response.Content);
        }
        public async Task<AramexPickupCreationResponse> CreatePickupOrders(AramexPickupCreationBody aramexPickupCreationBody)
        {
            IRestResponse response = await APICall.Excute(_aramexConfig.URL, _aramexConfig.CreatePickUpEndpoint, Method.POST
                , aramexPickupCreationBody, null, null);
            return JsonConvert.DeserializeObject<AramexPickupCreationResponse>(response.Content);
        }
        public async Task<AramexShipmentCreationResponse> CreateOrders(AramexShipmentsCreationBody aramexOrdersCreationBody)
        {
            IRestResponse response = await APICall.Excute(_aramexConfig.URL, _aramexConfig.CreateOrdersEndpoint, Method.POST
                , aramexOrdersCreationBody, null, null);
            return JsonConvert.DeserializeObject<AramexShipmentCreationResponse>(response.Content);
        }
        public async Task<AramexGetPDFResponse> GetPDF(AramexGetPDFBody aramexGetPDFBody)
        {
            IRestResponse response = await APICall.Excute(_aramexConfig.URL, _aramexConfig.GetAWBPDF, Method.POST
                , aramexGetPDFBody, null, null);
            return JsonConvert.DeserializeObject<AramexGetPDFResponse>(response.Content);
        }
        public async Task<AramexTrackShipmentResponse> GetTrackingShipments(AramexTrackShipmentsBody aramexTrackShipmentsBody)
        {
            IRestResponse response = await APICall.Excute(_aramexConfig.URL, _aramexConfig.TrackingEndpoint, Method.POST
                , aramexTrackShipmentsBody, null, null);
            return JsonConvert.DeserializeObject<AramexTrackShipmentResponse>(response.Content);
        }
    }
}
