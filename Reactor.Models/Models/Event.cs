using Newtonsoft.Json;
using Reactor.EventsClient.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactor.EventsClient.Models
{
    public class Event
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("eventType")]
        public EventType[] EventType { get; set; }

        [JsonProperty("startTime")]
        public string StartTime { get; set; }

        [JsonProperty("endTime")]
        public string EndTime { get; set; }

        [JsonProperty("location")]
        public City City { get; set; }

        [JsonProperty("eventContact")]
        public object EventContact { get; set; }

        [JsonProperty("speaker")]
        public object Speaker { get; set; }

        [JsonProperty("nonMSSpeaker")]
        public object NonMsSpeaker { get; set; }

        [JsonProperty("technology")]
        public string[] Technology { get; set; }

        [JsonProperty("otherTechnology")]
        public string OtherTechnology { get; set; }

        [JsonProperty("eventDescription")]
        public string EventDescription { get; set; }

        [JsonProperty("room")]
        public string[] Room { get; set; }

        [JsonProperty("eventHours")]
        public string EventHours { get; set; }

        [JsonProperty("externalAttendees")]
        public object ExternalAttendees { get; set; }

        [JsonProperty("internalAttendees")]
        public object InternalAttendees { get; set; }

        [JsonProperty("numberOfParticipants")]
        public long NumberOfParticipants { get; set; }

        [JsonProperty("displayEventName")]
        public string DisplayEventName { get; set; }

        [JsonProperty("openRegistration")]
        public bool OpenRegistration { get; set; }

        [JsonProperty("registrationLink")]
        public string RegistrationLink { get; set; }

        [JsonProperty("registrationURLVisible")]
        public RegistrationUrlVisible RegistrationUrlVisible { get; set; }

        [JsonProperty("displayDescription")]
        public bool DisplayDescription { get; set; }

        [JsonProperty("requestSource")]
        public RequestSource RequestSource { get; set; }

        public Location Location { get; set; }
    }
}
