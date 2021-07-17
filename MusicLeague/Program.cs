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

            var numberOfCompetitors = repository.Competitors.Count;
            var competitors = new string[numberOfCompetitors];
            var pointsMatrix = new int[numberOfCompetitors, numberOfCompetitors];

            // Total votes by competitor
            for (var i = 0; i < numberOfCompetitors; i++)
            {
                var competitor = repository.Competitors[i];
                competitors[i] = competitor.Name;

                competitors[i] = competitor.Name;
                Console.WriteLine($"{competitor.Name}'s votes from:");
                for (var j = 0; j < numberOfCompetitors; j++)
                {
                    var voter = repository.Competitors[j];
                    var competitorSubmissions = repository.Submissions.Where(s => s.SubmitterId == competitor.Id).Select(s => s.RoundId + s.SpotifyUri);
                    var competitorPoints = repository.Votes.Where(v => competitorSubmissions.Contains(v.RoundId + v.SpotifyUri) && v.VoterId == voter.Id).Sum(v => v.PointsAssigned);
                    pointsMatrix[i, j] = competitorPoints;

                    Console.WriteLine($"  {voter.Name}: {competitorPoints}");
                }
                Console.WriteLine();
            }

            // Votes difference
            var votesDifference = new int[numberOfCompetitors, numberOfCompetitors];
            for (int i = 0; i < numberOfCompetitors; i++)
            {
                for (int j = 0; j < numberOfCompetitors; j++)
                {
                    votesDifference[i, j] = Math.Abs(pointsMatrix[i, j] - pointsMatrix[j, i]);
                }
            }

            Console.WriteLine("Votes difference");
            PrintMatrix(votesDifference, competitors, true);
        }

        public static void PrintMatrix(int[,] matrix, string[] competitors, bool oneHalf = false)
        {
            Console.Write("       "); 
            foreach (var c in competitors)
            {
                Console.Write(CompetitorInitials(c));
            }
            Console.WriteLine();

            for (int i = 0; i < competitors.Length; i++)
            {
                Console.Write(CompetitorInitials(competitors[i]));
                for (int j = 0; j < competitors.Length; j++)
                {
                    if (oneHalf && j <= i)
                    {
                        Console.Write("     ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j].ToString().PadLeft(4) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        private static string CompetitorInitials(string fullName)
        {
            var initials = string.Empty;
            var names = fullName.Split(" ");
            foreach (var name in names)
            {
                initials += name.Substring(0, 1);
            }

            return initials.PadRight(5);
        }
    }
}
