using ClassLib.Models;

namespace ConsoleApp
{
    internal static class MessageFormat
    {
        internal static void PrintCameras(List<KeyValuePair<string, Location>> cameras)
        {
            foreach (var item in cameras)
            {
                var cameraNum = GetCameraNumber(item.Key);

                Console.WriteLine($"{(cameraNum != 0 ? cameraNum : string.Empty)} | {item.Key} | {item.Value.Latitude} | {item.Value.Longitude}");
            }
        }

        private static int GetCameraNumber(string cameraName)
        {
            var number = cameraName.Substring(7, 3);

            var hasNumber = int.TryParse(number, out var num);

            if (hasNumber)
            {
                return num;
            }
            else
            {
                return 0;
            }
        }
    }
}
