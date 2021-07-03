using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day7_1
{
    class Program
    {
        public static Dictionary<string, Bag> BagRefference = new Dictionary<string, Bag>();

        static void Main(string[] args)
        {
            string[] inputLines = File.ReadAllLines("Input.txt");
            List<Bag> bags = new List<Bag>();
            foreach (Bag bag in bags)
            {
                bag.Print();
            }
            foreach (string line in inputLines)
            {
                Bag parsedBag = Bag.ParseBag(line);
                bags.Add(parsedBag);
                BagRefference.Add(parsedBag.Color, parsedBag);
            }

            Bag goldBag = BagRefference["shiny gold"];
            
            int counter = CountBags(goldBag) -1;

            Console.WriteLine($"CanContain {counter}");
        }

        public static int CountBags(Bag bag)
        {
            int output = 1;
            foreach (Tuple<int, string> tuple in bag.CanContain)
            {
                output += CountBags(BagRefference[tuple.Item2]) * tuple.Item1;
            }

            return output;
        }
    }

    class Bag
    {
        public string Color;
        public List<Tuple<int, string>> CanContain = new List<Tuple<int, string>>();

        public void Print()
        {
            Console.Write($"A \"{Color}\" bag Can Contain:");
            foreach (var otherColor in CanContain)
            {
                Console.Write($" {otherColor},");
            }

            Console.WriteLine(";");
        }

        public override string ToString()
        {
            return $"{this.Color} Bag";
        }

        public static Bag ParseBag(string input)
        {
            Bag bag = new Bag();

            int spaceCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                {
                    spaceCount++;
                }

                if (spaceCount == 1)
                {
                    bag.Color = input.Substring(0, i + 1);
                }
            }

            if (input.EndsWith("no other bags."))
            {
                return bag;
            }

            Regex regex = new Regex("([0-9]) ([a-z ]*) bags?");
            foreach (Match match in regex.Matches(input))
            {
                if (!match.Success)
                {
                    Console.WriteLine($"Error Parsing line:{input};");
                    break;
                }

                int amount = int.Parse(match.Groups[1].Value);
                bag.CanContain.Add(new Tuple<int, string>(amount, match.Groups[2].Value));
            }

            return bag;
        }
    }
}