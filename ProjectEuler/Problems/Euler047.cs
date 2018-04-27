using System;
using System.Collections.Generic;
using System.Linq;
using static ProjectEuler.Common.Primes;

namespace ProjectEuler.Problems
{
    // The first two consecutive numbers to have two distinct prime factors are:

    // 14 = 2 × 7
    // 15 = 3 × 5

    // The first three consecutive numbers to have three distinct prime factors are:

    // 644 = 2² × 7 × 23
    // 645 = 3 × 5 × 43
    // 646 = 2 × 17 × 19.

    // Find the first four consecutive integers to have four distinct prime factors each.
    // What is the first of these numbers?

    public class Euler047 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            int limit = 1000000;
            HashSet<int> primes = PrimesUnderLimit(limit);

            List<int> consecutiveComposites = new List<int>(
                Enumerable.Range(1, limit - 3)
                .Where(x => !primes.Contains(x)
                && !primes.Contains(x + 1)
                && !primes.Contains(x + 2)
                && !primes.Contains(x + 3)
                ));

            Console.WriteLine($"got {consecutiveComposites.Count} candidates");

            foreach (int number in consecutiveComposites)
            {
                bool ok = true;
                // Scan through the composites
                for (int i = 0; i < 4 && ok; i++)
                {
                    int counter = 0;

                    int candidate = number + i;

                    foreach (int prime in primes)
                    {
                        if (candidate % prime == 0)
                        {
                            // is a factor
                            candidate /= prime;
                            counter++;
                            if (counter > 4) break;
                            if (prime > candidate * candidate) break;
                        }
                    }
                    if (counter != 4)
                    {
                        // go to next number
                        ok = false;
                        break;
                    }
                }
                if (ok) return number;
            }
            return -1;
        }
    }
}