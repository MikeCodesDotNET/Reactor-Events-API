using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reactor.EventsClient.Models;
using Reactor.EventsClient.Models.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Reactor.EventsClient.Helpers
{
    internal static class Serialize
    {
        public static string ToJson(this Response self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                EventTypeConverter.Singleton,
                LocationConverter.Singleton,
                RegistrationUrlVisibleConverter.Singleton,
                RequestSourceConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class EventTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(EventType) || t == typeof(EventType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Demo":
                    return EventType.Demo;
                case "Diversity & Inclusion":
                    return EventType.DiversityInclusion;
                case "Exec Filming":
                    return EventType.ExecFilming;
                case "Hackfest / Hackathon":
                    return EventType.HackfestHackathon;
                case "Meeting: Executives":
                    return EventType.MeetingExecutives;
                case "Meeting: Partners":
                    return EventType.MeetingPartners;
                case "Meetup":
                    return EventType.Meetup;
                case "OpenHack":
                    return EventType.OpenHack;
                case "Other":
                    return EventType.Other;
                case "ScaleUp Event":
                    return EventType.ScaleUpEvent;
            }
            throw new Exception("Cannot unmarshal type EventType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (EventType)untypedValue;
            switch (value)
            {
                case EventType.Demo:
                    serializer.Serialize(writer, "Demo");
                    return;
                case EventType.DiversityInclusion:
                    serializer.Serialize(writer, "Diversity & Inclusion");
                    return;
                case EventType.ExecFilming:
                    serializer.Serialize(writer, "Exec Filming");
                    return;
                case EventType.HackfestHackathon:
                    serializer.Serialize(writer, "Hackfest / Hackathon");
                    return;
                case EventType.MeetingExecutives:
                    serializer.Serialize(writer, "Meeting: Executives");
                    return;
                case EventType.MeetingPartners:
                    serializer.Serialize(writer, "Meeting: Partners");
                    return;
                case EventType.Meetup:
                    serializer.Serialize(writer, "Meetup");
                    return;
                case EventType.OpenHack:
                    serializer.Serialize(writer, "OpenHack");
                    return;
                case EventType.Other:
                    serializer.Serialize(writer, "Other");
                    return;
                case EventType.ScaleUpEvent:
                    serializer.Serialize(writer, "ScaleUp Event");
                    return;
            }
            throw new Exception("Cannot marshal type EventType");
        }

        public static readonly EventTypeConverter Singleton = new EventTypeConverter();
    }

    internal class LocationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(City) || t == typeof(City?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "London":
                    return City.London;
                case "New York":
                    return City.NewYork;
                case "Redmond B20":
                    return City.RedmondB20;
                case "Redmond B25":
                    return City.RedmondB25;
                case "San Francisco":
                    return City.SanFrancisco;
                case "Seattle":
                    return City.Seattle;
                case "Sydney":
                    return City.Sydney;
            }
            throw new Exception("Cannot unmarshal type Location");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (City)untypedValue;
            switch (value)
            {
                case City.London:
                    serializer.Serialize(writer, "London");
                    return;
                case City.NewYork:
                    serializer.Serialize(writer, "New York");
                    return;
                case City.RedmondB20:
                    serializer.Serialize(writer, "Redmond B20");
                    return;
                case City.RedmondB25:
                    serializer.Serialize(writer, "Redmond B25");
                    return;
                case City.SanFrancisco:
                    serializer.Serialize(writer, "San Francisco");
                    return;
                case City.Seattle:
                    serializer.Serialize(writer, "Seattle");
                    return;
                case City.Sydney:
                    serializer.Serialize(writer, "Sydney");
                    return;
            }
            throw new Exception("Cannot marshal type Location");
        }

        public static readonly LocationConverter Singleton = new LocationConverter();
    }

    internal class RegistrationUrlVisibleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RegistrationUrlVisible) || t == typeof(RegistrationUrlVisible?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return RegistrationUrlVisible.Empty;
                case "No":
                    return RegistrationUrlVisible.No;
                case "Yes":
                    return RegistrationUrlVisible.Yes;
            }
            throw new Exception("Cannot unmarshal type RegistrationUrlVisible");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RegistrationUrlVisible)untypedValue;
            switch (value)
            {
                case RegistrationUrlVisible.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case RegistrationUrlVisible.No:
                    serializer.Serialize(writer, "No");
                    return;
                case RegistrationUrlVisible.Yes:
                    serializer.Serialize(writer, "Yes");
                    return;
            }
            throw new Exception("Cannot marshal type RegistrationUrlVisible");
        }

        public static readonly RegistrationUrlVisibleConverter Singleton = new RegistrationUrlVisibleConverter();
    }

    internal class RequestSourceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RequestSource) || t == typeof(RequestSource?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "External":
                    return RequestSource.External;
                case "Internal":
                    return RequestSource.Internal;
            }
            throw new Exception("Cannot unmarshal type RequestSource");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RequestSource)untypedValue;
            switch (value)
            {
                case RequestSource.External:
                    serializer.Serialize(writer, "External");
                    return;
                case RequestSource.Internal:
                    serializer.Serialize(writer, "Internal");
                    return;
            }
            throw new Exception("Cannot marshal type RequestSource");
        }

        public static readonly RequestSourceConverter Singleton = new RequestSourceConverter();
    }
}
