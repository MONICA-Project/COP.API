using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace COP.API.EventHubs
{
    public class HeatMapUpdater
    {
        private readonly IHubContext<EventHubs.COPUpdate> _hubContext;

        public HeatMapUpdater(IHubContext<EventHubs.COPUpdate> hubContext)
        {
            _hubContext = hubContext;
        }


    }
}
