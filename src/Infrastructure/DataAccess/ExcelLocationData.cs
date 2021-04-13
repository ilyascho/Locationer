using LinqToExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public class ExcelLocationData : IDisposable
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }

        public ExcelLocationData()
        {
        }

        public ExcelLocationData(string address, double latitude, double longitude)
        {
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Returns locations using LinqToExcel
        /// </summary>
        /// <param name="pathToExcelFile"></param>
        /// <returns></returns>
        public static List<ExcelLocationData> GetAllLocationsLinqToExcel(string pathToExcelFile)
        {
            try
            {
                var excelFile = new ExcelQueryFactory(pathToExcelFile);

                var queryLocations = excelFile.Worksheet()
                                    .Select(location => new ExcelLocationData
                                    {
                                        Address = location["Address"], //x[0].ToString(),
                                        Latitude = double.Parse(location["Latitude"]),
                                        Longitude = double.Parse(location["Longitude"])
                                    });

                return queryLocations.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns locations using File.ReadAllLines and Parallel.For
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static List<ExcelLocationData> GetAllLocationsFileParallel(string filename)
        {
            try
            {
                List<ExcelLocationData> locations = new List<ExcelLocationData>();
                string[] AllLines = File.ReadAllLines(filename);

                var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 4 };

                Parallel.For(0, AllLines.Length - 1, options, i =>
                {
                    try
                    {
                        string[] data = AllLines[++i].Split(new[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);

                        string Address = data.ElementAt(0) == null ? "" : data.ElementAt(0).TrimStart('\"');
                        double Latitude = data.Length > 1 ? double.Parse(data.ElementAt(1)) : 0.0;
                        double Longitude = data.Length > 2 ? double.Parse(data.ElementAt(2).TrimEnd('\"')) : 0.0;

                        ExcelLocationData loc = new ExcelLocationData(Address, Latitude, Longitude);

                        lock (locations)
                        {
                            locations.Add(loc);
                        }
                    }
                    catch (Exception ex) 
                    { 
                        throw ex; 
                    }
                });

                return locations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
