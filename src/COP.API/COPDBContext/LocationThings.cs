using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class LocationThings
    {
        public long Locationid { get; set; }
        public long Thingid { get; set; }
        public DateTime Timepoint { get; set; }

        public Location Location { get; set; }
        public Thing Thing { get; set; }
    }
}
