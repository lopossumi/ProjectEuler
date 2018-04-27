using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectEuler.Common.Primes;
using static ProjectEuler.Common.Numerology;

namespace ProjectEuler.Problems
{
    public class Euler049 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            //This doesn't find the other sequence and is an awful hack. Oh well.
            int limit = 10000;
            HashSet<int> primes = new HashSet<int>(PrimesUnderLimit(limit).SkipWhile(x => x < 1000));
            Dictionary<int, int> candidates = new Dictionary<int, int>();

            foreach (int prime in primes)
            {
                string primeString = prime.ToString();

                SortedSet<int> perms = new SortedSet<int>(
                    Permutations(primeString)
                    .Select(x => Int32.Parse(x))
                    .Where(x => primes.Contains(x)));

                if (perms.Count >= 3 && !candidates.ContainsKey(perms.First()))
                {
                    //new set of primes
                    candidates.Add(prime, perms.Count);

                    for (int i = 0; i < perms.Count - 1; i++)
                    {
                        int diff = perms.ElementAt(i + 1) - perms.ElementAt(i);
                        if (perms.Contains(perms.ElementAt(i) + 2 * diff))
                        {
                            Console.WriteLine($"{perms.ElementAt(i)} {perms.ElementAt(i + 1)} {perms.ElementAt(i) + 2 * diff}");
                        }
                    }

                }
            }

            //foreach (int c in candidates.Keys)
            //{
            //    Console.WriteLine($"{c} has {candidates[c]} perms");
            //}
            //Console.WriteLine($"Got {primes.Count} 4-digit primes");
            //Console.WriteLine($"Got {candidates.Count} 4-digit permutable primes");
            return 0;
        }
    }
}
