using System;
using System.Collections.Generic;
using System.IO;

namespace Day6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            HashSet<char> yesAnswers = new HashSet<char>();

            int totalYesAnswers = 0;

            foreach (string answers in input)
            {
                if (answers == String.Empty)
                {
                    totalYesAnswers += yesAnswers.Count;
                    yesAnswers.Clear();
                }

                foreach (char answer in answers)
                {
                    yesAnswers.Add(answer);
                }
            }
            totalYesAnswers += yesAnswers.Count;
            yesAnswers.Clear();

            Console.WriteLine($"All groups answered yes to {totalYesAnswers} Yes.");
        }
    }
}
