using System;
using System.IO;

namespace Day3_2
{
    class Program
    {
        private static string[] input;
        private static int lineLength;

        static void Main(string[] args)
        {
            input = File.ReadAllLines("input.txt");

            lineLength = input[0].Length;

            ulong result1 = CheckPath(1, 1);
            Console.WriteLine(result1);

            ulong result2 = CheckPath(1, 3);
            Console.WriteLine(result2);

            ulong result3 = CheckPath(1, 5);
            Console.WriteLine(result3);

            ulong result4 = CheckPath(1, 7);
            Console.WriteLine(result4);

            ulong result5 = CheckPath(2, 1);
            Console.WriteLine(result5);

            ulong treeSum = result1 * result2 * result3 * result4 * result5;

            Console.WriteLine($"The route contains {treeSum} Trees.");
        }

        private static uint CheckPath(int down, int right)
        {
            int currLine = 0;
            int currIndex = 0;

            uint treeCount = 0;

            while (true)
            {
                currLine += down;
                currIndex += right;

                if (currLine >= input.Length) break;

                currIndex = currIndex % lineLength;
                if (input[currLine][currIndex] == '#')
                {
                    treeCount++;
                }
            }

            return treeCount;
        }
    }
}
