using ClassLib.Models;
using ClassLib.Services;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace ClassLib
{
    public class DataProcessor : IDataProcessor
    {
        private readonly string path = @"C:\Users\iianc\Desktop\ichoosr2\WebApi\ClassLib\Resource\dataset.csv";
        private readonly CameraLogic cameraLogic;

        public Dictionary<string, Location> Cameras { get; private set; } = new Dictionary<string, Location>();

        public DataProcessor()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                MissingFieldFound = null
            };

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<CameraData>();

            foreach (var row in records)
            {
                Cameras.Add(row.Camera, new Location()
                {
                    Latitude = row.Latitude,
                    Longitude = row.Longitude
                });
            }

            cameraLogic = new(Cameras);
        }

        public List<KeyValuePair<string, Location>> GetCamerasByName(string name)
        {
            return cameraLogic.GetCamerasByName(name);
        }

        public Dictionary<string, Location> GetAllCameras()
        {
            return Cameras;
        }

    }
}
