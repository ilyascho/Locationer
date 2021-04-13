using Infrastructure.DataAccess;
using LinqToExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitTests.DataAccess
{
    [TestClass]
    public class ExcelLocationDataTests
    {
        [TestMethod]
        public void GetAllLocationsFileParallel()
        {
            string filePath = @"D:\Locationer\Locationer\src\Infrastructure\Data\Excel\locations.csv";

            List<ExcelLocationData> locations = new List<ExcelLocationData>();
            string[] AllLines = File.ReadAllLines(filePath);

            var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount * 4 };

            Parallel.For(0, AllLines.Length - 1, options, i =>
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
            });
        }

        [TestMethod]
        public void GetAllLocationsLinqToExcel()
        {
            string filePath = @"D:\Locationer\Locationer\src\Infrastructure\Data\Excel\locations.csv";
            var excelFile = new ExcelQueryFactory(filePath);

            var queryLocations = excelFile.Worksheet()
                                .Select(location => new ExcelLocationData
                                {
                                    Address = location["Address"],
                                    Latitude = double.Parse(location["Latitude"]),
                                    Longitude = double.Parse(location["Longitude"])
                                });

            queryLocations.ToList();

        }
    }
}
