﻿using System;
using System.Collections.Generic;

namespace COP.API.COPDBContext
{
    public partial class PublicFeedback
    {
        public string Phoneid { get; set; }
        public string FeedbackType { get; set; }
        public double FeedbackValue { get; set; }
    }
}
