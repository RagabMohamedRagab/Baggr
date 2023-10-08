using Baggr.Providers.DTO.AramexModels;
using Baggr.Providers.DTO.DTOs;
using Baggr.Providers.DTO.FedexModels;
using Baggr.Providers.DTO.J_TExpressModels;
using Baggr.Providers.Gateway.IAPIs;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Baggr.Providers.Gateway.APIs {
    public class JTExpressAPI : IJTExpressAPI {
   
        private readonly JTExpressConfig _jTExpressConfig;

        public JTExpressAPI(IOptions<JTExpressConfig> jTExpressConfig)
        {
            _jTExpressConfig = jTExpressConfig.Value;
        }


        public async Task<JTExpressShipmentCreationResponse> CreateOrders(JTExpressShipmentsCreationBody jTExpressShipmentsCreationBody)
        { 
            //add object to make send degist header!
            string jsonRequestBody = CreateJsonRequestBody(new { billCodes = jTExpressShipmentsCreationBody.Shipments });
            List<KeyValuePair<string, string>> Headers = HeadersBody(jsonRequestBody);
            IRestResponse response = await APICall.Excute(_jTExpressConfig.URL, _jTExpressConfig.CreateOrdersEndpoint, Method.POST,
                jsonRequestBody, null, Headers, false, null);
            return JsonConvert.DeserializeObject<JTExpressShipmentCreationResponse>(response.Content);

            #region
            //string res = await BuildHeaderAsync(jTExpressShipmentsCreationBody);
            ////IRestResponse responseJTExpress = await APICall.Excute(_jTExpressConfig.URL, _jTExpressConfig.CreateOrdersEndpoint, Method.POST
            //// , jTExpressShipmentsCreationBody, null, null);
            //return JsonConvert.DeserializeObject<JTExpressShipmentCreationResponse>(res);
            #endregion
        }


        public async Task<JTExpressGetPDFResponse> GetPDF(JTExpressGetPDFBody JTExpressGetPDFBody)
        {
            var body = new { 
                      customerCode = JTExpressClientInfo.CustomerCode,
                      digest = JTExpressGetPDFBody.Digest,
                      billCode = JTExpressGetPDFBody.BillCode,
                      printSize = JTExpressGetPDFBody.PrintSize,
                      printCod = JTExpressGetPDFBody.PrintCod 
            };
            string jsonRequestBody = CreateJsonRequestBody(body);
            List<KeyValuePair<string, string>> Headers = HeadersBody(jsonRequestBody);
            IRestResponse response = await APICall.Excute(_jTExpressConfig.URL, _jTExpressConfig.CreateOrdersEndpoint, Method.POST,
              jsonRequestBody, null, Headers, false, null);
            return JsonConvert.DeserializeObject<JTExpressGetPDFResponse>(response.Content);
        }

        // Build Header of Request for JTEXpress


        //private async Task<string> BuildHeaderAsync(JTExpressShipmentsCreationBody requestData)
        //{
        //    // Create a string to hash (request body or any data as specified in the documentation)
        //    string jsonRequest = JsonConvert.SerializeObject(requestData);
        //    StringBuilder sb = new StringBuilder();
        //    // Calculate the MD5 digest
        //    using (MD5 md5 = MD5.Create())
        //    {
        //        byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(jsonRequest));


        //        foreach (byte b in hashBytes)
        //        {
        //            sb.Append(b.ToString("x2")); // Convert each byte to a 2-digit hexadecimal representation
        //        }
        //    }
        //    string digest = sb.ToString() + PrivateKey;

        //    // Build Header by apiAccount and timestamp

        //    string apiUrl = _jTExpressConfig.URL + "" + _jTExpressConfig.CreateOrdersEndpoint;

        //    string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(); // Current timestamp in seconds
        //    HttpClient httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Add("Digest", digest);
        //    httpClient.DefaultRequestHeaders.Add("apiAccount", ApiAccount);
        //    httpClient.DefaultRequestHeaders.Add("timestamp", timestamp);

        //    StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        //    // Send the POST request
        //    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

        //    // Handle the response as needed
        //    string responseBody = await response.Content.ReadAsStringAsync();
        //    return responseBody;
        //}



        public async Task<JTExpressTrackShipmentResponse> GetTrackingShipments(JTExpressTrackShipmentsBody jtexpressTrackShipmentsBody)
        {
            
            string jsonRequestBody = CreateJsonRequestBody(jtexpressTrackShipmentsBody);
            List<KeyValuePair<string, string>> Headers = HeadersBody(jsonRequestBody);
            IRestResponse response = await APICall.Excute(_jTExpressConfig.URL, _jTExpressConfig.TrackingEndpoint, Method.POST, jsonRequestBody, null, Headers, false, null);
            return JsonConvert.DeserializeObject<JTExpressTrackShipmentResponse>(response.Content);
        }

       

        private List<KeyValuePair<string, string>> HeadersBody(string jsonData)
        {
            var headerObj = new JTExpressHeader(jsonData);
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("apiAccount", headerObj.apiAccount));
            headers.Add(new KeyValuePair<string, string>("digest", headerObj.DegistHeader));
            headers.Add(new KeyValuePair<string, string>("timestamp", headerObj.Timestemp));
            return headers;
        }
        //private string CreateJsonRequestBody<T>(T requestBody)
        //{
        //    return JsonConvert.SerializeObject(requestBody);
        //}
        private string CreateJsonRequestBody<T>(T requestBody)
        {
            var propertyValues = new Dictionary<string, object>();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(requestBody);
                propertyValues[property.Name] = value;
            }

            return JsonConvert.SerializeObject(propertyValues);
        }
        //private string CreateJsonRequestBody<T>(T requestBody)
        //{
        //    var propertyValues = new Dictionary<string, object>();
        //    var properties = typeof(T).GetProperties();

        //    foreach (var property in properties)
        //    {
        //        var value = property.GetValue(requestBody);

        //        // If the property is an object, recursively process it
        //        if (value != null && property.PropertyType.Namespace == typeof(T).Namespace)
        //        {
        //            var nestedProperties = value.GetType().GetProperties();
        //            foreach (var nestedProperty in nestedProperties)
        //            {
        //                var nestedValue = nestedProperty.GetValue(value);
        //                propertyValues[nestedProperty.Name] = nestedValue;
        //            }
        //        }
        //        else
        //        {
        //            propertyValues[property.Name] = value;
        //        }
        //    }

        //    return JsonConvert.SerializeObject(propertyValues);
        //}
        //private string CreateJsonRequestBody<T>(T requestBody)
        //{
        //    var propertyValues = new Dictionary<string, object>();
        //    ProcessObject(requestBody, propertyValues);
        //    return JsonConvert.SerializeObject(propertyValues);
        //}

        //private void ProcessObject<T>(T obj, Dictionary<string, object> propertyValues)
        //{
        //    var properties = typeof(T).GetProperties();

        //    foreach (var property in properties)
        //    {
        //        var value = property.GetValue(obj);

        //        if (value != null)
        //        {
        //            // Check if the property is a nested object
        //            if (property.PropertyType.Namespace == typeof(T).Namespace)
        //            {
        //                ProcessObject(value, propertyValues);
        //            }
        //            else
        //            {
        //                propertyValues[property.Name] = value;
        //            }
        //        }
        //    }
        //}
    }
}
