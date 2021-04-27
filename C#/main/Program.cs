using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace main
{
    class Program
    {
        static int UPPER_BOUND;
        static void Main(string[] args)
        {
            if (args.Length == 0) 
            {
                Console.WriteLine("Please pass an upper bound");
                return;
            }
            if (int.TryParse(args[0], out UPPER_BOUND) == false)
            {
                Console.WriteLine($"Failed to parse '{args[0]}' as an integer");
                return;
            }

            var sw = Stopwatch.StartNew();

            var primeGaps = new Dictionary<int, int>();

            int prevPrime = 2;
            int numPrimes = 1;

            for (int i = 1; i < UPPER_BOUND; i += 2) 
            {
                if (IsPrime(i))
                {
                    numPrimes++;
                    int primeGap = i - prevPrime;
                    prevPrime = i;
                    if (primeGaps.ContainsKey(primeGap))
                    {
                        primeGaps[primeGap] = primeGaps[primeGap] + 1;
                    }
                    else
                    {
                        primeGaps.Add(primeGap, 1);
                    }
                }
            }

            sw.Stop();

            Console.WriteLine("***** C# Complete *****");
            Console.WriteLine($"- Run time: {sw.Elapsed.TotalSeconds} s");
            Console.WriteLine($"- Estimated prime numbers: {Math.Floor(UPPER_BOUND / Math.Log(UPPER_BOUND))}");
            Console.WriteLine($"- Found {numPrimes} prime numbers between 1 and {UPPER_BOUND}");
            Console.WriteLine($"- Count of gaps between prime numbers");
            PrettyPrint(primeGaps);
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            if (number % 2 == 0)
            {
                return number == 2;
            }

            int root = (int)Math.Sqrt(number) + 1;

            for (int i = 3; i < root; i += 2) 
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrettyPrint(Dictionary<int, int> dict) 
        {
            Console.WriteLine("{" + string.Join(", ", dict.Select(kvp => $"{kvp.Key}: {kvp.Value}")) + "}");
        }
    }
}
