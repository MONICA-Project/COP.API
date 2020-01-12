using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace COP.API.EventHubs
{
    public class HeatMapUpdater
    {
        private readonly IHubContext<EventHubs.WearableUpdate> _hubContext;

        public HeatMapUpdater(IHubContext<EventHubs.WearableUpdate> hubContext)
        {
            _hubContext = hubContext;
        }


    }
}
