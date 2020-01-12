using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class EventLocations
    {
        public long Eventid { get; set; }
        public long Locationid { get; set; }

        public Event Event { get; set; }
        public Location Location { get; set; }
    }
}
