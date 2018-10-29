using Reactor.EventsClient.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reactor.EventsClient.Models
{
    public class Location
    {
        public string Name { get; set; }
        
        public GeoPoint GeoPoint { get; set; }

        /// <summary>
        /// Distance from Reactor space in miles
        /// </summary>
        public double? DistanceFromUser { get; set; }

    }
}
