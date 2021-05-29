﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLeague.Model
{
    public class Round
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlaylistUrl { get; set; }
    }
}
