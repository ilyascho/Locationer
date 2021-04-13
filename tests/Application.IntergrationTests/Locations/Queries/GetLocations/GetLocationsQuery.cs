using Application.Common.Interfaces;
using Application.Locations.Queries.GetLocations;
using Application.Models;
using AutoMapper;
using Infrastructure.DataAccess;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Application.IntergrationTests.Locations.Queries.GetLocations
{
    [TestClass]
    public class GetLocationsQueryTests
    {
        /// <summary>
        /// Test method for GetAllLocationsFileParallel
        /// </summary>
        [TestMethod()]
        public void GetAllLocationsFileParallel_CheckCountMatch_True()
        {

            string filePath = @"D:\Locationer\Locationer\src\Infrastructure\Data\Excel\locations.csv";
            LocationDto originLocation = new LocationDto("Origin Location", 52.216542, 5.4778534);
            int maxDistance = 100000;
            int maxResults = 50;
            int expectedCount = 18;

            SearchResult searchResult = new SearchResult();
                        
            IList<ExcelLocationData> result = ExcelLocationData.GetAllLocationsFileParallel(filePath);
            
            //TODO: Map ExcelLocationData => LocationData

            GetLocationsQuery query = new GetLocationsQuery();
            SearchResult searchResultSorted = query.GetLocations(originLocation.Latitude, originLocation.Longitude,
                                                    maxDistance, maxResults, searchResult);
            int actualCount = searchResultSorted.Locations.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        /// <summary>
        /// Test method for GetAllCalculatedLocations
        /// </summary>
        [TestMethod()]
        public void GetAllCalculatedLocations_CheckCountMatch_True()
        {
            LocationDto originLocation = new LocationDto("LocationA", 52.216542, 5.4778534);
            int maxDistance = 1000;
            int maxResults = 500;
            int expectedCount = 124;

            GetLocationsQuery query = new GetLocationsQuery();
            SearchResult searchResult = new SearchResult();
            SearchResult searchResultSorted = query.GetLocations(originLocation.Latitude, originLocation.Longitude, maxDistance, maxResults, searchResult);
            int actualCount = searchResultSorted.Locations.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
