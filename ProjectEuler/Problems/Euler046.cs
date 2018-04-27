using System;
using System.Collections.Generic;
using System.Linq;
using static ProjectEuler.Common.Primes;

namespace ProjectEuler.Problems
{
    //It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a 
    //prime and twice a square.

    //9 = 7 + 2×1^2
    //15 = 7 + 2×2^2
    //21 = 3 + 2×3^2
    //25 = 7 + 2×3^2
    //27 = 19 + 2×2^2
    //33 = 31 + 2×1^2

    //It turns out that the conjecture was false.

    //What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?

    public class Euler046 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            int limit = 10000;
            HashSet<int> primes = PrimesUnderLimit(limit);
            Console.WriteLine($"Loaded {primes.Count} primes under {limit}");

            HashSet<int> doubleSquares = new HashSet<int>(
                Enumerable.Range(1, limit)
                .Select(x => 2 * x * x)
                .TakeWhile(x => x < limit));
            Console.WriteLine($"Loaded {doubleSquares.Count} doubled squares");

            HashSet<int> oddComposites = new HashSet<int>(
                Enumerable.Range(2, limit - 1)
                .Where(x => (x % 2 != 0))
                .Where(x => !primes.Contains(x)));
            Console.WriteLine($"Found {oddComposites.Count} odd composites");

            foreach (int candidate in oddComposites)
            {
                bool conjectureOk = false;
                foreach (int prime in primes.TakeWhile(x => x < candidate))
                {
                    if (doubleSquares.Contains(candidate - prime))
                    {
                        conjectureOk = true;
                        break;
                    }
                }
                if (!conjectureOk) return candidate;
            }
            return -1;
        }
    }
}
