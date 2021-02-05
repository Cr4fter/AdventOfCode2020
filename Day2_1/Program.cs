using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = File.ReadAllLines("input.txt");
            int validPassowrds = 0;
            Regex passwordParser = new Regex("^(?<min>[0-9]+)-(?<max>[0-9]+) (?<char>[a-zA-Z]): (?<pw>[a-zA-Z]+)$", RegexOptions.Compiled);
            foreach (string line in passwords)
            {
                Match match = passwordParser.Match(line);
                if (match.Success)
                {
                    int min = int.Parse(match.Groups["min"].Value);
                    int max = int.Parse(match.Groups["max"].Value);
                    char symbol = match.Groups["char"].Value[0];
                    string password = match.Groups["pw"].Value;

                    if (InRange(CountOccurrence(password, symbol), min, max))
                    {
                        validPassowrds++;
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to parse Line \"{line}\"");
                }
            }
            Console.WriteLine($"Found {validPassowrds} valid Passwords.");
        }

        private static bool InRange(int value, int min, int max)
        {
            return value <= max && value >= min;
        }

        private static int CountOccurrence(string input, char symbol)
        {
            int occurrence = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == symbol)
                {
                    occurrence++;
                }
            }
            return occurrence;
        }
    }
}
