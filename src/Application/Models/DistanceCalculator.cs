using Application.Common.Interfaces;
using System;

namespace Application.Models
{
    public class DistanceCalculator : IDistanceCalculator
    {
        /// <summary>
        /// Calculates the distance between this location and another one, in meters.
        /// </summary>
        public double CalculateDistance(double originLatitude, double originLongitude, double destinationLatitude, double destinationLongitude)
        {
            var rlat1 = Math.PI * destinationLatitude / 180;
            var rlat2 = Math.PI * originLatitude / 180;
            var rlon1 = Math.PI * destinationLongitude / 180;
            var rlon2 = Math.PI * originLongitude / 180;
            var theta = destinationLongitude - originLongitude;
            var rtheta = Math.PI * theta / 180;
            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1609.344;
        }
    }
}
