using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ExRatesSharp
{
    public static class Request<T>
    {
        public static async Task<T> SendRequest(string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);

            var response = await client.ExecuteAsync(request);
            return DeserializeResponse(response.Content);
        }
        
        public static async Task<T> SendRequest(string url, Method method, string[] symbols, string baseCurrency = "EUR")
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddParameter("symbols", string.Join(",", symbols));
            request.AddParameter("base", baseCurrency);

            var response = await client.ExecuteAsync(request);
            return DeserializeResponse(response.Content);
        }
        
        public static async Task<T> SendRequest(string url, Method method, string[] symbols, string baseCurrency,
            DateTime startAt, DateTime endAt)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            if (symbols != null)
                request.AddParameter("symbols", string.Join(",", symbols));
            if (baseCurrency != null)
                request.AddParameter("base", baseCurrency != "" ? baseCurrency : "EUR");
            request.AddParameter("start_at", startAt.ToString("yyyy-MM-dd"));
            request.AddParameter("end_at", endAt.ToString("yyyy-MM-dd"));

            var response = await client.ExecuteAsync(request);
            return DeserializeResponse(response.Content);
        }

        private static T DeserializeResponse(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}