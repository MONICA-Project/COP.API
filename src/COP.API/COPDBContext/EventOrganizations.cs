﻿using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class EventOrganizations
    {
        public long Eventid { get; set; }
        public int Organizationid { get; set; }

        public Event Event { get; set; }
        public Organization Organization { get; set; }
    }
}
