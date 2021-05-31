using System;
using System.Linq;
using MusicLeague.Repository;

namespace MusicLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new DataRepository("Data/competitors.csv", "Data/rounds.csv", "Data/submissions.csv", "Data/votes.csv");

            // Total votes by competitor
            foreach (var competitor in repository.Competitors)
            {
                Console.WriteLine($"{competitor.Name}'s votes from:");
                foreach (var voter in repository.Competitors)
                {
                    var competitorSubmissions = repository.Submissions.Where(s => s.SubmitterId == competitor.Id).Select(s => s.RoundId + s.SpotifyUri);
                    var competitorPoints = repository.Votes.Where(v => competitorSubmissions.Contains(v.RoundId + v.SpotifyUri) && v.VoterId == voter.Id).Sum(v => v.PointsAssigned);

                    Console.WriteLine($"  {voter.Name}: {competitorPoints}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("End");
        }
    }
}
