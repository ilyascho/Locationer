using Application.Common.Trees.LocationTree;
using Application.Locations.Queries.GetLocations;
using Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests.Models
{
    [TestClass]
    public class LocationTreeGeneratorTests
    {
        [TestMethod()]
        public void GenerateLocationTreeFromExcel()
        {
            string filePath = @"D:\Locationer\Locationer\src\Infrastructure\Data\Excel\locations.csv";
            LocationDto originLocation = new LocationDto("LocationA", 52.216542, 5.4778534);

            LocationTree locationTree = LocationTreeGenerator.GenerateFromExcel(originLocation.Latitude, originLocation.Longitude, filePath);

            Assert.IsNotNull(locationTree);
        }
    }
}
