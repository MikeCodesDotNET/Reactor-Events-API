
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Reactor.EventsClient.Models;
using System.Net.Http;
using System.Text;

namespace Reactor.EventsAPI
{
    public static class Events
    {
        [FunctionName("events")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, ILogger log)
        {
            string latitude = req.Query["lat"];
            string longitude = req.Query["long"];
            string date = req.Query["date"];

            List<Event> events;

            var client = new EventsClient.Client();

            if (string.IsNullOrEmpty(latitude) || string.IsNullOrEmpty(longitude))
                events = await client.DownloadEvents(DateTime.Parse(date), DateTime.Parse(date));
            else
                events = await client.DownloadEvents(DateTime.Parse(date), DateTime.Parse(date), new GeoPoint(Double.Parse(latitude), Double.Parse(longitude)));

            var json = JsonConvert.SerializeObject(events);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "application/json") };
        }
    }
}
