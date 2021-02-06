using System;
using System.IO;
using System.Text.RegularExpressions;

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

        public void AddValue(string key, string value)
        {
            switch (key)
            {
                case "byr":
                    byr = valByr(value);
                    break;
                case "iyr":
                    iyr = valIyr(value);
                    break;
                case "eyr":
                    eyr = valEyr(value);
                    break;
                case "hgt":
                    hgt = valHgt(value);
                    break;
                case "hcl":
                    hcl = valHcl(value);
                    break;
                case "ecl":
                    ecl = valEcl(value);
                    break;
                case "pid":
                    pid = valPid(value);
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

        #region Validation

        private bool valByr(string value)
        {
            int birthYear = int.Parse(value);
            return birthYear >= 1920 && birthYear <= 2002;
        }

        private bool valIyr(string value)
        {
            int issueYear = int.Parse(value);
            return issueYear >= 2010 && issueYear <= 2020;
        }

        private bool valEyr(string value)
        {
            int expirationYear = int.Parse(value);
            return expirationYear >= 2020 && expirationYear <= 2030;
        }

        private bool valHgt(string value)
        {
            Regex regex = new Regex("(?<size>[0-9]+)(?<unit>cm|in)", RegexOptions.Compiled);
            Match match = regex.Match(value);
            if (match.Success == false) return false;

            int size = int.Parse(match.Groups["size"].Value);
            if (match.Groups["unit"].Value == "cm")
            {
                return size >= 150 && size <= 193;
            }
            else if (match.Groups["unit"].Value == "in")
            {
                return size >= 59 && size <= 76;
            }

            return false;
        }

        private bool valHcl(string value)
        {
            Regex regex = new Regex("#[0-9a-f]+", RegexOptions.Compiled);
            return regex.IsMatch(value);
        }

        private bool valEcl(string value)
        {
            switch (value)
            {
                case "amb":
                case "blu":
                case "brn":
                case "gry":
                case "grn":
                case "hzl":
                case "oth":
                    return true;
                default:
                    return false;
            }
        }

        private bool valPid(string value)
        {
            Regex regex = new Regex("^[0-9]{9}$", RegexOptions.Compiled);
            return regex.IsMatch(value);
        }
        #endregion
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
                    currentPassport.AddValue(parts[0], parts[1]);
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
