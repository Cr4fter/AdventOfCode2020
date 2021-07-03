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
            foreach (string line in inputLines)
            {
                Bag parsedBag = Bag.ParseBag(line); 
                bags.Add(parsedBag);
                BagRefference.Add(parsedBag.Color, parsedBag);
            }

            int counter = 0;
            
            foreach (Bag bag in bags)
            {
                if (CanContainBag(bag, "shiny gold"))
                {
                    counter++;
                }
            }
            Console.WriteLine($"CanContain {counter}");
        }

        public static bool CanContainBag(Bag bag, string bagColor)
        {
            if (bag.CanContain.Any(T => T.Item2 == bagColor))
            {
                return true;
            }

            foreach (Tuple<int,string> tuple in bag.CanContain)
            {
                if (CanContainBag(BagRefference[tuple.Item2], bagColor))
                {
                    return true;
                }
            }
            
            return false;
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
                    bag.Color = input.Substring(0, i+1);
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
