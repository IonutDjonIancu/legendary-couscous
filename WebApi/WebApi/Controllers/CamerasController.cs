using ClassLib;
using ClassLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using WebApi.ViewModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class CamerasController : ControllerBase
    {
        private readonly IDataProcessor _dataProcessor;

        public CamerasController(IDataProcessor dataProcessor)
        {
            _dataProcessor = dataProcessor;
        }

        [Route("api/GetCameras")]
        [HttpGet]
        public List<CameraVM> GetCameras()
        {
            var cameras = _dataProcessor.GetAllCameras();
            var camerasList = new List<CameraVM>();

            foreach (var cam in cameras)
            {
                camerasList.Add(new CameraVM
                {
                    Name = cam.Key,
                    Latitude = cam.Value.Latitude,
                    Longitude = cam.Value.Longitude
                });
            }

            return camerasList;
        }

        [Route("api/GetOk")]
        [HttpGet]
        public string GetOk()
        {
            return "okay";
        }
    }
}
