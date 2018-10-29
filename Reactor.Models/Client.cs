using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Reactor.EventsClient.Models;
using Reactor.Helpers;

namespace Reactor.EventsClient
{
    public class Client
    {
        public async Task<List<Event>> DownloadEvents(DateTime startDate, DateTime endDate, GeoPoint usersLocation = null)
        {
            var baseUrl = "https://developer.microsoft.com/en-us/reactor/api/sp/events";

            var start = startDate.ToString("s");
            var end = endDate.ToString("s");

            var webClient = new WebClient();
            var json = await webClient.DownloadStringTaskAsync($"{baseUrl}?from={start}.111Z&to={end}.111Z");

            var eventsResponse = Response.FromJson(json);

            foreach(var e in eventsResponse.Events)
            {
                GeoPoint geoPoint = null;

               switch(e.City)
                {
                    case Models.Enums.City.London:
                        geoPoint = new GeoPoint(51.521661, -0.084660);
                        e.Location = new Location() { Name = "London", GeoPoint = geoPoint };
                        break;

                    case Models.Enums.City.NewYork:
                        geoPoint = new GeoPoint(40.756989, -73.989708);
                        e.Location = new Location() { Name = "New York", GeoPoint = geoPoint };
                        break;

                    case Models.Enums.City.RedmondB20:
                        geoPoint = new GeoPoint(47.643826, -122.130709);
                        e.Location = new Location() { Name = "Redmond Building 20", GeoPoint = geoPoint };
                        break;

                    case Models.Enums.City.RedmondB25:
                        geoPoint = new GeoPoint(47.644840, -122.130031);
                        e.Location = new Location() { Name = "Redmond Building 25", GeoPoint = geoPoint };
                        break;

                    case Models.Enums.City.Seattle:
                        geoPoint = new GeoPoint(47.621460, -122.338058);
                        e.Location = new Location() { Name = "Seattle", GeoPoint = geoPoint };
                        break;

                    case Models.Enums.City.SanFrancisco:
                        geoPoint = new GeoPoint(37.784599, -122.398529);
                        e.Location = new Location() { Name = "San Francisco", GeoPoint = geoPoint };
                        break;

                    case Models.Enums.City.Sydney:
                        geoPoint = new GeoPoint(-33.767048, 151.090646);
                        e.Location = new Location() { Name = "Sydney", GeoPoint = geoPoint };
                        break;
                }

                if (usersLocation != null)
                    e.Location.DistanceFromUser = DistanceCalculator.Distance(geoPoint, usersLocation);
            }

            var results = eventsResponse.Events.ToList();

            //Lets order by closest Reactor space.
            if(usersLocation != null)
            {
                results = results.OrderBy(x => x.Location.DistanceFromUser).ToList();
            }

            return results;
        }

        public async Task<List<Event>> DownloadTodaysEvents(GeoPoint userLocation = null)
        {
            return await DownloadEvents(DateTime.Now, DateTime.Now, userLocation);
        }

        
    }
}
