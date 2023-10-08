using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baggr.Providers.Gateway
{
    public class APICall
    {
        public static async Task<IRestResponse> Excute(string baseURL, string endPoint, Method method, Object body = null,
            IEnumerable<KeyValuePair<string, string>> queryParams = null, IEnumerable<KeyValuePair<string, string>> headers = null, bool fireException = false, IEnumerable<KeyValuePair<string, string>> parameters = null)
        {
            Console.WriteLine($"Sending API To:\n{baseURL}{endPoint}");
            Console.WriteLine("Body:\n" + JsonConvert.SerializeObject(body));
            var client = new RestClient(baseURL);
            var request = new RestRequest(endPoint, method);

            if (method != Method.GET && body !=null)
                request.AddJsonBody(body);

            if (queryParams != null && queryParams.Any())
            {
                foreach (KeyValuePair<string, string> pair in queryParams)
                {
                    request.AddQueryParameter(pair.Key, pair.Value);
                }
            }
            request.AddHeader("Accept", "application/json");
            if (headers != null && headers.Any())
            {
                foreach (KeyValuePair<string, string> keyValue in headers)
                    request.AddHeader(keyValue.Key, keyValue.Value);
            }
            if (parameters != null && headers.Any())
            {
                foreach (KeyValuePair<string, string> keyValue in parameters)
                    request.AddParameter(keyValue.Key, keyValue.Value);
            }
            IRestResponse response = await client.ExecuteAsync(request);
            
            Console.WriteLine("status Code " + response.StatusCode + " Response Content:\n" + JsonConvert.SerializeObject(response.Content));

            if (((int)response.StatusCode < 200 || (int)response.StatusCode > 299) && fireException)
                throw new Exception("status Code " + response.StatusCode + " Error " + response.ErrorMessage);
            return response;
        }
    }
}
