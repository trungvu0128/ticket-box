using Microsoft.AspNetCore.Mvc;
using Project.Core.Extensions;
using Project.Core.Models;
using Shared.Tracking;

namespace Project.Core.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly ITrackingLog _trackingLog;

        /// <summary>
        /// Initialize a new instance of controller
        /// </summary>
        /// <param name="trackingLog"></param>
        public BaseController(ITrackingLog trackingLog)
        {
            _trackingLog = trackingLog;
        }
        protected IActionResult ResponseOk(dynamic? dataResponse)
        {
            return Ok(dataResponse);
        }

        protected IActionResult ResponseBadRequest(string[] errorMessages)
        {
            return BadRequest(errorMessages);
        }
    }
}
