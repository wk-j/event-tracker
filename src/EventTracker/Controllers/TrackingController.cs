using System.Threading.Tasks;
using EventTracker.Hubs;
using EventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace EventTracker.Controllers {
    public class Result {
        public bool Success { set; get; }
    }

    [Route("api/[controller]/[action]")]
    public class TrackingController : ControllerBase {

        private readonly ILogger<TrackingController> logger;
        private IHubContext<TrackingHub> hub;

        public TrackingController(ILogger<TrackingController> logger, IHubContext<TrackingHub> hub) {
            this.logger = logger;
            this.hub = hub;
        }

        [HttpPost]
        public async Task<Result> MouseMove([FromBody] MouseEvent evt) {
            logger.LogInformation("({0}, {1})", evt.ClientX, evt.ClientY);
            await HubFunctions.FireMouseMove(hub.Clients, evt);
            return new Result { Success = true };
        }

        [HttpPost]
        public async Task<Result> KeyPress([FromBody] KeyPressEvent evt) {
            logger.LogInformation("{0}", evt.Key);
            await HubFunctions.FireKeyPress(hub.Clients, evt);
            return new Result { Success = true };
        }
    }
}