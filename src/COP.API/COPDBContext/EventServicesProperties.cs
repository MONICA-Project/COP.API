﻿using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class EventServicesProperties
    {
        public long Eventservicepropertyid { get; set; }
        public long Eventserviceid { get; set; }
        public short Propertytypeid { get; set; }
        public string Metadata { get; set; }
    }
}
