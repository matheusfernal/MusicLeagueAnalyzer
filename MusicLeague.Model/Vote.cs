using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLeague.Model
{
    public class Vote
    {
        public string SpotifyUri { get; set; }
        public string VoterId { get; set; }
        public DateTime Created { get; set; }
        public int PointsAssigned { get; set; }
        public string Comment { get; set; }
        public string RoundId { get; set; }
    }
}
