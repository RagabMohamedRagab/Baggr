using Baggr.Providers.DTO.MylerzModels;
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
    public class MylerzAPI : IMylerzAPI
    {
        private readonly MylerzConfig _mylerzConfig;

        public MylerzAPI(IOptions<MylerzConfig> mylerzConfig)
        {
            _mylerzConfig = mylerzConfig.Value;
        }
        public async Task<MylerzTokenResponse> GetToken(string url)
        {
            var headers = new List<KeyValuePair<string, string>>();
            var parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(KeyValuePair.Create("grant_type", "password"));
            parameters.Add(KeyValuePair.Create("username", _mylerzConfig.UserName));
            parameters.Add(KeyValuePair.Create("password", _mylerzConfig.Password));
            headers.Add(KeyValuePair.Create("Content-Type", "application/x-www-form-urlencoded"));
            IRestResponse response = await APICall.Excute(url, _mylerzConfig.GetTokenEndpoint, Method.POST
                , null, null, headers, false, parameters);
            var result = JsonConvert.DeserializeObject<MylerzTokenResponse>(response.Content);
            return result;
        }
        public async Task<MylerzCreateAddressResponse> CreateAddress(MylerzCreateAddressBody mylerzCreateAddressRequest, string token)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(KeyValuePair.Create("Authorization", string.Format("Bearer {0}", token)));
            IRestResponse response = await APICall.Excute(_mylerzConfig.PortalURL, _mylerzConfig.CreateAddressEndpoint, Method.POST
                , mylerzCreateAddressRequest, null, headers);
            var result = JsonConvert.DeserializeObject<MylerzCreateAddressResponse>(response.Content);
            return result;
        }
        public async Task<MylerzCreateOrdersResponse> CreateOrders(IEnumerable<MylerzShipment> body, string token)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(KeyValuePair.Create("Authorization", string.Format("Bearer {0}", token)));
            IRestResponse response = await APICall.Excute(_mylerzConfig.URL, _mylerzConfig.CreateOrdersEndpoint, Method.POST
                , body, null, headers);
            var result = JsonConvert.DeserializeObject<MylerzCreateOrdersResponse>(response.Content);
            return result;
        }
        public async Task<MylerzCreatePickupResponse> CreatePickup(IEnumerable<MylerzPackage> body, string token)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(KeyValuePair.Create("Authorization", string.Format("Bearer {0}", token)));
            IRestResponse response = await APICall.Excute(_mylerzConfig.URL, _mylerzConfig.CreatePickupEndpoint, Method.POST
                , body, null, headers);
            var result = JsonConvert.DeserializeObject<MylerzCreatePickupResponse>(response.Content);
            return result;
        }
        public async Task<MylerzGetQuoteResponse> GetQuote(MylerzGetQuoteBody mylerzGetQuoteBody, string token)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(KeyValuePair.Create("Authorization", string.Format("Bearer {0}", token)));
            IRestResponse response = await APICall.Excute(_mylerzConfig.URL, _mylerzConfig.GetQuoteEndpoint, Method.POST
                , mylerzGetQuoteBody, null, headers);
            var result = JsonConvert.DeserializeObject<MylerzGetQuoteResponse>(response.Content);
            return result;
        }
        public async Task<MylerzGetPDFResponse> GetPDF(MylerzGetPDFBody mylerzGetPDFBody, string token)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(KeyValuePair.Create("Authorization", string.Format("Bearer {0}", token)));
            IRestResponse response = await APICall.Excute(_mylerzConfig.URL, _mylerzConfig.GetAWBPDF, Method.POST
                , mylerzGetPDFBody, null, headers);
            return JsonConvert.DeserializeObject<MylerzGetPDFResponse>(response.Content);
        }
        public async Task<MylerzTrackShipmentResponse> GetTrackingShipments(IEnumerable<string> body, string token)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(KeyValuePair.Create("Authorization", string.Format("Bearer {0}", token)));
            IRestResponse response = await APICall.Excute(_mylerzConfig.URL, _mylerzConfig.TrackShipmentEndpoint, Method.POST
                , body, null, headers);
            return JsonConvert.DeserializeObject<MylerzTrackShipmentResponse>(response.Content);
        }

        public async Task<MylerzGetTrackingShipmentLogsResponse> GetTrackingShipmentLogs(IEnumerable<MylerzGetTrackingShipmentLogsBody> body, string token)
        {
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(KeyValuePair.Create("Authorization", string.Format("Bearer {0}", token)));
            IRestResponse response = await APICall.Excute(_mylerzConfig.URL, _mylerzConfig.TrackShipmentLogEndpoint, Method.POST
                , body, null, headers);
            return JsonConvert.DeserializeObject<MylerzGetTrackingShipmentLogsResponse>(response.Content);
        }
    }
}
