using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExRatesSharp.Objects;
using Newtonsoft.Json.Schema;
using RestSharp;

namespace ExRatesSharp
{
    public static class ExchangeRatesApi
    {
        public static async Task<Response> GetLatest() => 
            await Request<Response>.SendRequest("https://api.exchangeratesapi.io/latest", Method.GET);
        
        public static async Task<Response> GetLatest(string baseCurrency) => 
            await Request<Response>.SendRequest("https://api.exchangeratesapi.io/latest", Method.GET, null, baseCurrency);
        
        public static async Task<Response> GetLatest(string baseCurrency, string[] symbols) => 
            await Request<Response>.SendRequest("https://api.exchangeratesapi.io/latest", Method.GET, symbols, baseCurrency);

        public static async Task<Response> GetHistoricalRates(DateTime date) =>
            await Request<Response>.SendRequest("https://api.exchangeratesapi.io/" + date.ToString("yyyy-MM-dd"), Method.GET);

        public static async Task<CustomResponse> GetCustomRates(DateTime startsAt, DateTime endsAt) =>
            await Request<CustomResponse>.SendRequest("https://api.exchangeratesapi.io/history", Method.GET, null, null, startsAt, endsAt);
        
        public static async Task<CustomResponse> GetCustomRates(DateTime startsAt, DateTime endsAt, string baseCurrency) =>
            await Request<CustomResponse>.SendRequest("https://api.exchangeratesapi.io/history", Method.GET, null, baseCurrency, startsAt, endsAt);
        
        public static async Task<CustomResponse> GetCustomRates(DateTime startsAt, DateTime endsAt, string baseCurrency, string[] symbols) =>
            await Request<CustomResponse>.SendRequest("https://api.exchangeratesapi.io/history", Method.GET, symbols, baseCurrency, startsAt, endsAt);
    }
}