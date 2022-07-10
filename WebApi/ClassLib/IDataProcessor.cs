using ClassLib.Models;

namespace ClassLib
{
    public interface IDataProcessor
    {
        Dictionary<string, Location> Cameras { get; }

        Dictionary<string, Location> GetAllCameras();
        List<KeyValuePair<string, Location>> GetCamerasByName(string name);
    }
}

