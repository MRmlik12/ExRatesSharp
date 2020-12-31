using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExRatesSharp.Objects
{
    public class CustomResponse
    {
        [JsonProperty("rates")]
        public Dictionary<string, Dictionary<string, double>> Rates { get; set; }

        [JsonProperty("start_at")]
        public DateTimeOffset StartAt { get; set; }

        [JsonProperty("base")]
        public string BaseCurrency { get; set; }

        [JsonProperty("end_at")]
        public DateTimeOffset EndAt { get; set; }
    }
}