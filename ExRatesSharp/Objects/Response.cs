using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExRatesSharp.Objects
{
    public class Response
    {
        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }

        [JsonProperty("base")]
        public string BaseCurrency { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
    }
}