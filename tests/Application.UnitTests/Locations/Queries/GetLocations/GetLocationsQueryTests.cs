using Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Locations.Queries.GetLocations.Tests
{
    [TestClass()]
    public class GetLocationsQueryTests
    {
        [TestMethod()]
        public void GetLocationsTest_CheckCountMatch_True()
        {
            LocationDto originLocation = new LocationDto("Origin Location", 52.216542, 5.4778534);
            int maxDistance = 100000;
            int maxResults = 50;
            int expectedCount = 18;

            IList<LocationDto> result = new List<LocationDto>();
            
            result.Add(new LocationDto("TestLocation 1", 52.2165425, 5.4778534));
            result.Add(new LocationDto("TestLocation 2", 50.91414, 5.95549));
            result.Add(new LocationDto("TestLocation 3", 52.22667, 5.1811));
            result.Add(new LocationDto("TestLocation 4", 52.3878359, 4.6371779));
            result.Add(new LocationDto("TestLocation 5", 52.0611478, 4.4875588));
            result.Add(new LocationDto("TestLocation 6", 51.5829768, 5.1764954));
            result.Add(new LocationDto("TestLocation 7", 52.187709, -1.692691));
            result.Add(new LocationDto("TestLocation 8", 52.5259673, 5.719307));
            result.Add(new LocationDto("TestLocation 9", 53.0001983, 6.5146841));
            result.Add(new LocationDto("TestLocation 10", 51.6798806, 5.3170226));
            result.Add(new LocationDto("TestLocation 11", 51.964345, 5.8989));
            result.Add(new LocationDto("TestLocation 12", 52.76725, -1.53142));
            result.Add(new LocationDto("TestLocation 13", 52.2198788, 6.8959664));
            result.Add(new LocationDto("TestLocation 14", 51.647715, 5.9502954));
            result.Add(new LocationDto("TestLocation 15", 51.3788468, -2.3592111));
            result.Add(new LocationDto("TestLocation 16", 51.644054, 5.6548692));
            result.Add(new LocationDto("TestLocation 17", 51.3342487, 5.9963625));
            result.Add(new LocationDto("TestLocation 18", 52.2607102, 4.5586074));
            result.Add(new LocationDto("TestLocation 19", 52.9486111, 6.4483333));
            result.Add(new LocationDto("TestLocation 20", 52.4299872, 4.9136706));
            result.Add(new LocationDto("TestLocation 21", 51.847809, 5.8634111));
            result.Add(new LocationDto("TestLocation 22", 51.9055491, 6.1174997));
            result.Add(new LocationDto("TestLocation 23", 52.0857564, 5.240287));
            result.Add(new LocationDto("TestLocation 24", 52.3060726, 6.5215324));
            result.Add(new LocationDto("TestLocation 25", 52.1920308, -2.2222391));
            result.Add(new LocationDto("TestLocation 26", 51.5133835, 7.4613312));
            result.Add(new LocationDto("TestLocation 27", 51.6019565, 4.105881));
            result.Add(new LocationDto("TestLocation 28", 51.1462912, 4.2979291));
            result.Add(new LocationDto("TestLocation 29", 58.9829236, 5.6738134));
            result.Add(new LocationDto("TestLocation 20", 51.62613, 5.88097));

            SearchResult searchResult = new SearchResult { Locations = result };            

            GetLocationsQuery query = new GetLocationsQuery();
            SearchResult searchResultSorted = query.GetLocations(originLocation.Latitude, originLocation.Longitude,
                                                    maxDistance, maxResults, searchResult);
            int actualCount = searchResultSorted.Locations.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
