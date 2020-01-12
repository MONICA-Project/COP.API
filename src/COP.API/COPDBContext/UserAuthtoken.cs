using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class UserAuthtoken
    {
        public int Userid { get; set; }
        public string Authtoken { get; set; }
        public DateTime Dateissued { get; set; }

        public UserAuth User { get; set; }
    }
}
