using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Day4_1
{
    class Passport
    {
        private bool byr;
        private bool iyr;
        private bool eyr;
        private bool hgt;
        private bool hcl;
        private bool ecl;
        private bool pid;
        private bool cid;

        public void addValue(string key, string value)
        {
            switch (key)
            {
                case "byr":
                    byr = true;
                    break;
                case "iyr":
                    iyr = true;
                    break;
                case "eyr":
                    eyr = true;
                    break;
                case "hgt":
                    hgt = true;
                    break;
                case "hcl":
                    hcl = true;
                    break;
                case "ecl":
                    ecl = true;
                    break;
                case "pid":
                    pid = true;
                    break;
                case "cid":
                    cid = true;
                    break;
            }
        }

        public bool isValid()
        {
            return byr && iyr && eyr && hgt && hcl && ecl && pid;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            Passport currentPassport = new Passport();

            int validPassports = 0;

            foreach (string line in input)
            {
                if (line == string.Empty)
                {
                    if (currentPassport.isValid())
                    {
                        validPassports++;
                    }
                    currentPassport = new Passport();
                    continue;
                }

                string[] items = line.Split(' ');
                foreach (string item in items)
                {
                    string[] parts = item.Split(':');
                    currentPassport.addValue(parts[0], parts[1]);
                }
            }

            if (currentPassport.isValid())
            {
                validPassports++;
            }

            Console.WriteLine($"Found {validPassports} Valid Passports.");
        }
    }
}
