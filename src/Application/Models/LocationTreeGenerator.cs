using Application.Common.Interfaces;
using Application.Common.Trees.LocationTree;
using Application.Locations.Queries.GetLocations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.Models
{
    public class LocationTreeGenerator
    {
        public static LocationTree GenerateFromExcel(double originLatitude, double originLongitude, string filename)
        {
            LocationTree locationTree = new LocationTree();

            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(new[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
                        string address = data.ElementAt(0) == null ? "" : data.ElementAt(0).TrimStart('\"');
                        double latitude = data.Length > 1 ? Convert.ToDouble(data.ElementAt(1)) : 0.0;
                        double longitude = data.Length > 2 ? Convert.ToDouble(data.ElementAt(2).TrimEnd('\"')) : 0.0;

                        LocationDto location = new LocationDto(address, latitude, longitude);

                        IDistanceCalculator distanceCalculator = new DistanceCalculator();
                        location.Distance = distanceCalculator.CalculateDistance(originLatitude, originLongitude, latitude, longitude);

                        locationTree.Insert(location);
                    }
                    sr.Close();
                }

                return locationTree;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
