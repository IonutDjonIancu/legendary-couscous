using ClassLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Services
{
    internal class CameraLogic
    {
        private readonly Dictionary<string, Location> cameras;

        internal CameraLogic(Dictionary<string, Location> cameras)
        {
            this.cameras = cameras;
        }

        internal List<KeyValuePair<string, Location>> GetCamerasByName(string name)
        {
            return cameras.Where(s => s.Key.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

    }
}
