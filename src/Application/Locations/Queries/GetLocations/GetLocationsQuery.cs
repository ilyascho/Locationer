using Application.Common.Interfaces;
using Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Locations.Queries.GetLocations
{
    public class GetLocationsQuery : ISearchLocation<SearchResult>
    {
        public IList<LocationDto> Locations { get; set; }

        /// <summary>
        /// Returns SearchResult containing list of locations.
        /// </summary>
        /// <param name="originLat">Origin Latitude</param>
        /// <param name="originLon">Origin Longitude</param>
        /// <param name="maxDistance">Max Distance</param>
        /// <param name="maxResults">Max number of Results</param>
        /// <returns></returns>
        public SearchResult GetLocations(double originLat, double originLon, int maxDistance, int maxResults, SearchResult searchResults)
        {
            try
            {
                return new SearchResult
                {
                    Locations = GetNearestLocations(originLat, originLon, maxDistance, maxResults, searchResults.Locations)
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns list of locations close to origin Latitude and Longitude.
        /// </summary>
        /// <param name="originLat">Origin Latitude</param>
        /// <param name="originLon">Origin Longitude</param>
        /// <param name="maxDistance">Max Distance</param>
        /// <param name="maxResults">Max number of Results</param>
        /// <returns></returns>
        private IList<LocationDto> GetNearestLocations(double originLat, double originLon, int maxDistance, int maxResults, IList<LocationDto> locations)
        {
            IList<LocationDto> sortedLocations = new List<LocationDto>();

            try
            {
                IDistanceCalculator distanceCalculator = new DistanceCalculator();

                //Sort by maxDistance
                var query = locations.AsParallel().WithDegreeOfParallelism(4)
                                .Select(loc => new LocationDto
                                {
                                    Address = loc.Address,
                                    Latitude = loc.Latitude,
                                    Longitude = loc.Longitude,
                                    Distance = distanceCalculator.CalculateDistance(originLat, originLon, loc.Latitude, loc.Longitude)
                                });

                query = query.Where(x => x.Distance <= maxDistance).OrderBy(o => o.Distance).Take(maxResults);

                sortedLocations = query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sortedLocations;
        }
    }
}
