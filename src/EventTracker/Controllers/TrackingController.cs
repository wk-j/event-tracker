using Microsoft.Extensions.Logging;

namespace EventTracker.Controllers {
    public class TrackingController {
        private readonly ILogger<TrackingController> logger;
        public TrackingController(ILogger<TrackingController> logger) {
            this.logger = logger;
        }
    }
}