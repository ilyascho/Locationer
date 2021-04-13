using Application.Common.Interfaces;
using Application.Locations.Queries.GetLocations;
using Application.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests.Models
{
    [TestClass]
    class DistanceCalculatorTests
    {
        /// <summary>
        /// Test method for getAllLocationsParallel
        /// </summary>
        [TestMethod]
        public void CalculateDistance_IsEqualDistance_True()
        {       
            LocationDto locA = new LocationDto("LocationA", 52.216542, 5.4778534);
            LocationDto locB = new LocationDto("LocationB", 50.91414, 5.95549);
            double expectedDistance = 148527.96353121538;

            IDistanceCalculator calc = new DistanceCalculator();
            double actualDistance = calc.CalculateDistance(locA.Latitude, locA.Longitude, locB.Latitude, locB.Longitude);

            Assert.AreEqual(expectedDistance, actualDistance);
        }
    }
}
