using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace COP.API.EventHubs
{
    public class WearableUpdate : Hub

    {
        public async Task peoplewithwearablesUpdate(string message)
        {
            await Clients.All.SendAsync("peoplewithwearablesUpdate", message);
        }

        public async Task SoundsensorUpdate(string message)
        {
            await Clients.All.SendAsync("SoundsensorUpdate", message);
        }

        public async Task  ZoneUpdate(string message)
        {
            await Clients.All.SendAsync("ZoneUpdate", message);
        }
        public async Task Incidents(string message)
        {
            await Clients.All.SendAsync("Incidents", message);
        }

        public async Task SoundIncidents(string message)
        {
            await Clients.All.SendAsync("SoundIncidents", message);
        }

        public async Task TemperatureUpdate(string message)
        {
            await Clients.All.SendAsync("TemperatureUpdate", message);
        }

        public async Task HumidityUpdate(string message)
        {
            await Clients.All.SendAsync("HumidityUpdate", message);
        }


        public async Task WindUpdate(string message)
        {
            await Clients.All.SendAsync("WindUpdate", message);
        }

        public async Task AggregateUpdate(string message)
        {
            await Clients.All.SendAsync("AggregateUpdate", message);
        }
        public async Task PeopleGateCounting(string message)
        {
            await Clients.All.SendAsync("PeopleGateCounting", message);
        }

        public async Task SoundheatmapUpdate(string message)
        {
            await Clients.All.SendAsync("SoundheatmapUpdate", message);
        }


        public async Task PeopleheatmapUpdate(string message)
        {
            await Clients.All.SendAsync("PeopleheatmapUpdate", message);
        }
    }
}
