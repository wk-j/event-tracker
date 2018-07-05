using System.Collections.Concurrent;
using System.Threading.Tasks;
using EventTracker.Hubs;
using EventTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace EventTracker.Controllers {

    public class Cached {
        public static ConcurrentDictionary<string, int> Dict { get; } = new ConcurrentDictionary<string, int>();
        public static void Add(char code) {
            if (char.IsLetter(code)) {
                var str = code.ToString().ToUpper();
                var ok = Dict.TryGetValue(str, out var count);
                if (ok) {
                    Dict.TryUpdate(str, count + 1, count);
                } else {
                    Dict.TryAdd(str, 1);
                }
            }
        }
    }

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
            logger.LogInformation("{0} {1}", evt.Key, evt.KeyCode);

            Cached.Add((char)evt.KeyCode);
            await HubFunctions.FireKeyPress(hub.Clients, evt);
            await HubFunctions.FireSummary(hub.Clients, Cached.Dict);

            return new Result { Success = true };
        }
    }
}