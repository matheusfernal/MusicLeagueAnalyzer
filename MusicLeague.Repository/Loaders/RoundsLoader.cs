using MusicLeague.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicLeague.Repository.Loaders
{
    class RoundsLoader
    {
        public static List<Round> Load(string path)
        {
            var rounds = new List<Round>();

            using var file = new StreamReader(path);

            string line;
            var header = true;
            while ((line = file.ReadLine()) != null)
            {
                if (header)
                {
                    header = false;
                    continue;
                }

                var columns = line.Split(',');
                var round = new Round
                {
                    Id = columns[0],
                    Created = DateTime.Parse(columns[1]),
                    Name = columns[2],
                    Description = columns[3],
                    PlaylistUrl = columns[4]
                };

                rounds.Add(round);
            }

            return rounds;
        }
    }
}
