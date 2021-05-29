using MusicLeague.Model;
using System;
using System.Collections.Generic;

namespace MusicLeague.Repository
{
    public class Repository
    {
        public List<Competitor> Competitors { get; }
        public List<Round> Rounds { get; }
        public List<Submission> Submissions { get; }
        public List<Vote> Votes { get; }

        public Repository()
        {

        }
    }
}
