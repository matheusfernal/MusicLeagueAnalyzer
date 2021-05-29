using MusicLeague.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicLeague.Repository.Loaders
{
    class CompetitorsLoader
    {
        public static List<Competitor> Load(string path)
        {
            var competitors = new List<Competitor>();

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
                var competitor = new Competitor
                {
                    Id = columns[0],
                    Name = columns[1]
                };

                competitors.Add(competitor);
            }

            return competitors;
        }
    }
}
