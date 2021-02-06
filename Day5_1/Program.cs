using System;
using System.IO;

namespace Day5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            int highestEcnounteredID = 0;

            foreach (string seat in input)
            {
                int row = BinaryToInt(127, seat.Substring(0, 7), 'F', 'B');
                int column = BinaryToInt(7, seat.Substring(6, 3), 'L', 'R');
                int id = row * 8 + column;
                if (id > highestEcnounteredID)
                {
                    highestEcnounteredID = id;
                }
            }
            Console.WriteLine($"The highest Encountered Seat was {highestEcnounteredID}");
        }

        static int BinaryToInt(int max, string input, char lower, char upper)
        {
            int minConcidered = 0;
            int maxConcidered = max;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == lower)
                {
                    maxConcidered = (int)Math.Floor((maxConcidered - minConcidered) * 0.5f) + minConcidered;
                    continue;
                }
                if (input[i] == upper)
                {
                    minConcidered = (int)Math.Ceiling((maxConcidered - minConcidered) * 0.5f) + minConcidered;
                    continue;
                }
            }

            return minConcidered;
        }
    }
}
