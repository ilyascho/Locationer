using Application.Locations.Queries.GetLocations;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ApiController
    {
        [HttpGet]
        public ActionResult<SearchResult> GetLocations(double latitude, double longitude, int maxDistance, int maxResult)
        {
            SearchResult searchResult = new SearchResult();
            GetLocationsQuery query = new GetLocationsQuery();
            SearchResult searchResultSorted = query.GetLocations(longitude, longitude,
                                                    maxDistance, maxResult, searchResult);

            return searchResultSorted;
        }
    }
}
