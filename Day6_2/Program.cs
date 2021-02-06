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

            int personsIngroup = 0;
            Dictionary<char, int> YesAnsweres = new Dictionary<char, int>();

            int totalYesAnswers = 0;
            foreach (string answers in input)
            {
                if (answers == String.Empty)
                {
                    foreach (KeyValuePair<char, int> answer in YesAnsweres)
                    {
                        if (answer.Value == personsIngroup) totalYesAnswers++;
                    }
                    YesAnsweres.Clear();
                    personsIngroup = 0;
                    continue;
                }

                foreach (char answer in answers)
                {
                    if (YesAnsweres.ContainsKey(answer) == false)
                    {
                        YesAnsweres.Add(answer, 1);
                    }
                    else
                    {
                        YesAnsweres[answer]++;
                    }
                }

                personsIngroup++;
            }

            foreach (KeyValuePair<char, int> answer in YesAnsweres)
            {
                if (answer.Value == personsIngroup) totalYesAnswers++;
            }

            Console.WriteLine($"All groups answered yes to {totalYesAnswers} Yes.");
        }
    }
}