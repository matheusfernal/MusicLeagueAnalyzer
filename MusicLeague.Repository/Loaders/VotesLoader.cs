using MusicLeague.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicLeague.Repository.Loaders
{
    class VotesLoader
    {
        public static List<Vote> Load(string path)
        {
            var votes = new List<Vote>();

            using var file = new StreamReader(path);

            string line;
            file.ReadLine(); // header
            while ((line = file.ReadLine()) != null)
            {
                var columns = line.Split(',');
                var vote = new Vote
                {
                    SpotifyUri = columns[0],
                    VoterId = columns[1],
                    Created = DateTime.Parse(columns[2]),
                    PointsAssigned = int.Parse(columns[3]),
                    Comment = columns[4],
                    RoundId = columns[5]
                };

                votes.Add(vote);
            }

            return votes;
        }
    }
}
