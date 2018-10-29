﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Reactor.EventsClient.Models
{
    public class GeoPoint
    {
        public GeoPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
