using EventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventTracker.Controllers {
    public class Result {
        public bool Success { set; get; }
    }

    public class TrackingController : ControllerBase {
        private readonly ILogger<TrackingController> logger;
        public TrackingController(ILogger<TrackingController> logger) {
            this.logger = logger;
        }

        public Result NewMouseEvent([FromBody] MouseEvent evt) {
            return new Result { Success = true };
        }

        public Result NewKeyPressEvent([FromBody] KeyPressEvent evt) {
            return new Result { Success = true };
        }
    }
}