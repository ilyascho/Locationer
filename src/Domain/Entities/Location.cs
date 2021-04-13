using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Location : Entity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }

        public Location()
        {
        }

        public Location(string address, double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
        }
    }
}
