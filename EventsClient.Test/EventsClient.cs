using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EventsClient.Test
{
    [TestClass]
    public class EventsClients
    {
        [TestMethod]
        public void FetchAllEvents()
        {
            var client = new Reactor.EventsClient.Client();
            DateTime.TryParse("01/10/2018", out DateTime start);
            DateTime.TryParse("31/10/2018", out DateTime end);
            
            var events = client.DownloadEvents(start, end).Result;

            Assert.IsTrue(events != null);
            Assert.IsTrue(events.Count > 0);

            var firstLondonEvent = events.FirstOrDefault(x => x.City == Reactor.EventsClient.Models.Enums.City.London);
            Assert.IsTrue(firstLondonEvent != null);

        }

        [TestMethod]
        public void FetchTodaysEvents()
        {
            var client = new Reactor.EventsClient.Client();
            var events = client.DownloadTodaysEvents().Result;

            Assert.IsTrue(events != null);
            Assert.IsTrue(events.Count > 0);
        }

        [TestMethod]
        public void FetchTodaysEventsWithUserLocation()
        {
            //Set to 10 Downing Street - London
            var userLocation = new Reactor.EventsClient.Models.GeoPoint(51.503440, -0.127708);

            var client = new Reactor.EventsClient.Client();
            var events = client.DownloadTodaysEvents(userLocation).Result;

            Assert.IsTrue(events != null);
            Assert.IsTrue(events.Count > 0);
        }

    }
}
