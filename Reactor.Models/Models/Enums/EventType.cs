using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reactor.EventsClient.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactor.EventsClient.Models.Enums
{
    [JsonConverter(typeof(EventTypeConverter))]
    public enum EventType
    {
        Demo,
        DiversityInclusion,
        ExecFilming,
        HackfestHackathon,
        MeetingExecutives,
        MeetingPartners,
        Meetup,
        OpenHack,
        Other,
        ScaleUpEvent
    }

}
