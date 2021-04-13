using Application.Locations.Queries.GetLocations;
using System.Collections.Generic;

namespace Application.Models
{
    public class SearchResult
    {
        public IList<LocationDto> Locations { get; set; }
    }
}
