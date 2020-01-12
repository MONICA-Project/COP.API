using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class InterventionPlan
    {
        public InterventionPlan()
        {
            InterventionActions = new HashSet<InterventionActions>();
        }

        public int Interventionplanid { get; set; }
        public short Interventiontype { get; set; }
        public string Name { get; set; }

        public ICollection<InterventionActions> InterventionActions { get; set; }
    }
}
