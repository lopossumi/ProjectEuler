using System;
using System.Collections.Generic;
using System.Linq;
using static ProjectEuler.Common.Numerology;
using static ProjectEuler.Common.Primes;

namespace ProjectEuler.Problems
{
    // We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once.
    // For example, 2143 is a 4-digit pandigital and is also prime.

    // What is the largest n-digit pandigital prime that exists?

    public class Euler041 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private int run()
        {
            //generate ordered list of 1-7 pandigitals (8 and 9 digit numbers are always divisible by 3)
            string digits = "1234567";
            List<string> permutations = Permutations(digits);
            permutations.Sort();
            Console.WriteLine("Sorted {0} of 1...7 pandigitals", permutations.Count);

            int[] primes = PrimesUnderLimit(
                (int)Math.Sqrt(7654321))
                .ToArray();

            Console.WriteLine($"Loaded {primes.Length} primes");

            for (int i = permutations.Count - 1; i > 0; i--)
            {
                bool primeCandidate = true;
                foreach (int prime in primes)
                {
                    long number = int.Parse(permutations[i]);
                    if (number % prime == 0)
                    {
                        //Console.WriteLine("Testing pandigital {0}: divided even by {1}", number, prime);
                        primeCandidate = false;
                        break;
                    }
                }
                if (primeCandidate)
                {
                    return (int.Parse(permutations[i]));
                }
            }
            return 0;
        }
    }
}
