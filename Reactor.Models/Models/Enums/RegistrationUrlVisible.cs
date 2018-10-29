using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reactor.EventsClient.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactor.EventsClient.Models.Enums
{
    [JsonConverter(typeof(RegistrationUrlVisibleConverter))]
    public enum RegistrationUrlVisible
    {
        Empty,
        No,
        Yes
    }

}
