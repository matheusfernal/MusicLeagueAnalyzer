using System;
using MusicLeague.Repository;

namespace MusicLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new DataRepository("Data/competitors.csv", "Data/rounds.csv", "Data/submissions.csv", "Data/votes.csv");

            Console.WriteLine("Hello World!");
        }
    }
}
