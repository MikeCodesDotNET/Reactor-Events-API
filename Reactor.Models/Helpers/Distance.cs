using Reactor.EventsClient.Models;
using System;

namespace Reactor.Helpers
{
    internal static class DistanceCalculator
    {
        public static double Distance(GeoPoint reactor, GeoPoint user)
        {
            double theta = reactor.Longitude - user.Longitude;
            double distance = Math.Sin(Deg2Radians(reactor.Latitude)) * Math.Sin(Deg2Radians(user.Latitude)) + Math.Cos(Deg2Radians(reactor.Latitude)) * Math.Cos(Deg2Radians(user.Latitude)) * Math.Cos(Deg2Radians(theta));
            distance = Math.Acos(distance);
            distance = Rad2Degrees(distance);
            distance = distance * 60 * 1.1515;

            return (distance);
        }

        static double Deg2Radians(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        static double Rad2Degrees(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
        
    }
}

