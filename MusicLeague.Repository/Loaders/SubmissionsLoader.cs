using MusicLeague.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MusicLeague.Repository.Loaders
{
    class SubmissionsLoader
    {
        public static List<Submission> Load(string path)
        {
            var submissions = new List<Submission>();

            using var file = new StreamReader(path);

            string line;
            file.ReadLine(); // header
            while ((line = file.ReadLine()) != null)
            {
                var columns = line.Split(',');
                var submission = new Submission
                {
                    SpotifyUri = columns[0],
                    SubmitterId = columns[1],
                    Created = DateTime.Parse(columns[2]),
                    Commennt = columns[3],
                    RoundId = columns[4]
                };

                submissions.Add(submission);
            }

            return submissions;
        }
    }
}
