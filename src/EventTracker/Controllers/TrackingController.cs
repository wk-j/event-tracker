using EventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventTracker.Controllers {
    public class Result {
        public bool Success { set; get; }
    }

    [Route("api/[controller]/[action]")]
    public class TrackingController : ControllerBase {
        private readonly ILogger<TrackingController> logger;
        public TrackingController(ILogger<TrackingController> logger) {
            this.logger = logger;
        }

        [HttpPost]
        public Result NewMouseMove([FromBody] MouseEvent evt) {
            logger.LogInformation("({0}, {1})", evt.ClientX, evt.ClientY);
            return new Result { Success = true };
        }

        [HttpPost]
        public Result NewKeyPress([FromBody] KeyPressEvent evt) {
            logger.LogInformation("{0}", evt.Key);
            return new Result { Success = true };
        }
    }
}