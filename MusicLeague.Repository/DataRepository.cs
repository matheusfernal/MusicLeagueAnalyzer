using MusicLeague.Model;
using MusicLeague.Repository.Loaders;
using System;
using System.Collections.Generic;

namespace MusicLeague.Repository
{
    public class DataRepository
    {
        public List<Competitor> Competitors { get; }
        public List<Round> Rounds { get; }
        public List<Submission> Submissions { get; }
        public List<Vote> Votes { get; }

        public DataRepository(string competitorsPath, string roundsPath, string submissionsPath, string votesPath)
        {
            Competitors = CompetitorsLoader.Load(competitorsPath);
            Rounds = RoundsLoader.Load(roundsPath);
            Submissions = SubmissionsLoader.Load(submissionsPath);
            Votes = VotesLoader.Load(votesPath);
        }
    }
}
