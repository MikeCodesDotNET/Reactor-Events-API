using Newtonsoft.Json;
using Reactor.EventsClient.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactor.EventsClient.Models
{
    internal partial class Response
    {
        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("errorMessage")]
        public object ErrorMessage { get; set; }

        [JsonProperty("data")]
        public Event[] Events { get; set; }

        public static Response FromJson(string json) => JsonConvert.DeserializeObject<Response>(json, Converter.Settings);

    }
}
