using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] passwords = File.ReadAllLines("input.txt");
            int validPassowrds = 0;
            Regex passwordParser = new Regex("^(?<first>[0-9]+)-(?<second>[0-9]+) (?<char>[a-zA-Z]): (?<pw>[a-zA-Z]+)$", RegexOptions.Compiled);
            foreach (string line in passwords)
            {
                Match match = passwordParser.Match(line);
                if (match.Success)
                {
                    int first = int.Parse(match.Groups["first"].Value);
                    int second = int.Parse(match.Groups["second"].Value);
                    char symbol = match.Groups["char"].Value[0];
                    string password = match.Groups["pw"].Value;

                    if (password[first - 1] == symbol ^ password[second - 1] == symbol)
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
    }
}
