using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLeague.Model
{
    public class Submission
    {
        public string SpotifyUri { get; set; }
        public string SubmitterId { get; set; }
        public DateTime Created { get; set; }
        public string Commennt { get; set; }
        public string RoundId { get; set; }
    }
}
