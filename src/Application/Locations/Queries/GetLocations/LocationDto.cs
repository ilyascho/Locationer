using Application.Common.Mappings;
using AutoMapper;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Locations.Queries.GetLocations
{
    public class LocationDto : IMapFrom<ExcelLocationData>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public double Distance { get; set; }

        public LocationDto(string address, double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
            Distance = 0;
        }

        public LocationDto(string address, double latitude, double longitude, double distance)
        {
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
            Distance = distance;
        }

        public LocationDto()
        {
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ExcelLocationData, LocationDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => (string)s.Address))
                .ForMember(d => d.Longitude, opt => opt.MapFrom(s => (double)s.Longitude))
                .ForMember(d => d.Latitude, opt => opt.MapFrom(s => (double)s.Latitude))
                ;
        }
    }
}
