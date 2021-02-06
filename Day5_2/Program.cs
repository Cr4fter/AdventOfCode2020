using System;
using System.Collections.Generic;
using System.IO;

namespace Day5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            List<int> foundSeatIDs = new List<int>();

            foreach (string seat in input)
            {
                int row = BinaryToInt(127, seat.Substring(0, 7), 'F', 'B');
                int column = BinaryToInt(7, seat.Substring(7, 3), 'L', 'R');
                int id = (int)((row * 8f) + column);
                
                foundSeatIDs.Add(id);
            }

            foundSeatIDs.Sort();

            for (int i = 0; i < foundSeatIDs.Count - 1; i++)
            {
                int id = foundSeatIDs[i];
                if (id + 1 != foundSeatIDs[i + 1])
                {
                    Console.WriteLine($"SeatID {id+1} is missing.");
                    return;
                }
            }
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