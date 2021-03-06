﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Day1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            foreach (string line in File.ReadAllLines("input.txt"))
            {
                numbers.Add(int.Parse(line));
            }

            foreach (int firstNumber in numbers)
            {
                foreach (int secondNumber in numbers)
                {
                    if (firstNumber + secondNumber < 2020)
                    {
                        foreach (int thirdNumber in numbers)
                        {
                            if (firstNumber + secondNumber + thirdNumber == 2020)
                            {
                                Console.WriteLine(firstNumber * secondNumber * thirdNumber);
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
