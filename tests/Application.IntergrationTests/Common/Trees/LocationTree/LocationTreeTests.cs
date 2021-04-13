using Application.Common.Trees.LocationTree;
using Application.Locations.Queries.GetLocations;
using Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.IntergrationTests.Common.Trees.LocationTreeTests
{
    [TestClass]
    public class LocationTreeTests
    {
        /// <summary>
        /// Test method for LocationTree.Generator.Generate And LocationTree.Search
        /// </summary>
        [TestMethod()]
        public void GenerateAndSearchLocationTree()
        {
            string filePath = @"C:\Users\ilyas\source\repos\LocationR\LocationR.DataAccess\Data\locations.csv";
            LocationDto originLocation = new LocationDto("LocationA", 52.216542, 5.4778534);
            int maxDistance = 1000;
            int maxResults = 500;
            int expectedCount = 124;

            LocationTree locationTree = LocationTreeGenerator.GenerateFromExcel(originLocation.Latitude, originLocation.Longitude, filePath);

            var searchResult = locationTree.Search(maxDistance, maxResults)
                                .OrderBy(o => o.Distance).Take(maxResults);

            List<LocationDto> locations = searchResult.ToList();
            int actualCount = locations.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
