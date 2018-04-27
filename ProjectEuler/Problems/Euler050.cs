using System.Linq;
using static ProjectEuler.Common.Primes;

namespace ProjectEuler.Problems
{
    // The prime 41, can be written as the sum of six consecutive primes:

    // 41 = 2 + 3 + 5 + 7 + 11 + 13
    // This is the longest sum of consecutive primes that adds to a prime below one-hundred.

    // The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
    // Which prime, below one-million, can be written as the sum of the most consecutive primes?

    public class Euler050 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            int limit = 1000000;
            int[] primeArray = PrimesUnderLimit(limit).ToArray();
            bool[] isPrime = IsPrimeUnderLimit(limit);
            int result = 0;

            // theoretical limit for chain is (2+3+5....+n) < 1000 000
            int maxLength = 0;
            int sum = 0;
            while (sum < limit)
            {
                sum += primeArray[maxLength];
                maxLength++;
            }

            // count down from maximum length chain
            for (; maxLength > 0; maxLength--)
            {
                sum = 0;
                for (int i = 0; i < maxLength; i++)
                {
                    sum += primeArray[i];
                }

                for (int i = 0; i < primeArray.Length - maxLength; i++)
                {
                    if (sum >= limit) break;
                    if (isPrime[sum])
                    {
                        return sum;
                    }
                    sum = sum - primeArray[i] + primeArray[i + maxLength];
                }
            }
            return result;
        }

    }
}
