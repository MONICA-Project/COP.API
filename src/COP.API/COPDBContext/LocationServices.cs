﻿using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class LocationServices
    {
        public long Locationid { get; set; }
        public int Serviceid { get; set; }

        public Location Location { get; set; }
        public ServiceRepository Service { get; set; }
    }
}
