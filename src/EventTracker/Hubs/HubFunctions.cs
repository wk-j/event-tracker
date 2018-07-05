using System.Collections.Concurrent;
using System.Threading.Tasks;
using EventTracker.Models;
using Microsoft.AspNetCore.SignalR;

namespace EventTracker.Hubs {
    public class HubFunctions {
        public static async Task FireSummary(IHubClients client, ConcurrentDictionary<string, int> dict) {
            await client.All.SendAsync("summary", new {
                Summary = dict
            });
        }

        public static async Task FireMouseMove(IHubClients client, MouseEvent evt) {
            await client.All.SendAsync("mouseMove", new {
                evt.ClientX,
                evt.ClientY
            });
        }
        public static async Task FireKeyPress(IHubClients client, KeyPressEvent evt) {
            await client.All.SendAsync("keyPress", new {
                evt.Key
            });
        }
    }
}