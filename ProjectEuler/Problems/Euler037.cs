using System;
using System.Collections.Generic;
using System.Linq;
using static ProjectEuler.Common.Numerology;
using static ProjectEuler.Common.Primes;

namespace ProjectEuler.Problems
{

    public class Euler037 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            HashSet<int> primes = PrimesUnderLimit(1000000);
            Console.WriteLine($"Loaded {primes.Count()} primes");

            int sum = 0;
            foreach (int cand in primes.Where(x => x > 10))
            {
                int left = cand;
                int right = cand;
                bool ok = true;

                while (left > 10 && ok)
                {
                    left = TruncateLeft(left);
                    if (!primes.Contains(left)) ok = false;
                }
                while (right > 10 && ok)
                {
                    right /= 10;
                    if (!primes.Contains(right)) ok = false;
                }

                if (ok) sum += cand;
            }

            return sum;
        }
    }
}


