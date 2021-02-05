using System;
using System.IO;

namespace Day3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            int lineLength = input[0].Length;

            int line = 0;
            int index = 0;

            int treeCount = 0;

            while (true)
            {
                line++;
                index += 3;
                if (line == input.Length) break;
                index = index % lineLength;
                if (input[line][index] == '#')
                {
                    treeCount++;
                }
            }
            Console.WriteLine($"The route contains {treeCount} Trees.");
        }
    }
}
