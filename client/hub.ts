import * as signalR from "@aspnet/signalr"

export const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl(`/trackingHub`)
    .configureLogging(signalR.LogLevel.Information)
    .build()

hubConnection.start().catch(err => {
    console.error(err);
});