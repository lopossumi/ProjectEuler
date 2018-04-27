﻿using System;
using System.Collections.Generic;
using System.Linq;
using static ProjectEuler.Common.Numerology;

namespace ProjectEuler.Problems
{
    // Pentagonal numbers are generated by the formula, Pn = n(3n−1) / 2. The first ten pentagonal numbers are:
    //
    // 1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...
    //
    // It can be seen that P4 + P7 = 22 + 70 = 92 = P8.
    // However, their difference, 70 − 22 = 48, is not pentagonal.
    //
    // Find the pair of pentagonal numbers, Pj and Pk, for which their sum and difference are pentagonal and 
    // D = | Pk − Pj | is minimised; what is the value of D ?

    public class Euler044 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        // This will return the first value found, which also is the smallest.
        static long run()
        {
            int limit = int.MaxValue;

            List<long> pentagons = new List<long>();

            for (int k = 0; k < limit; k++)
            {
                long p = k * (3 * k - 1) / 2;
                pentagons.Add(p);

                for (int j = (k - 1); j > 1; j--)
                {
                    long d = pentagons[k] - pentagons[j];

                    if(IsPentagonal(pentagons[k] + pentagons[j]) && IsPentagonal(d))
                    {
                        Console.WriteLine($"P{k} P{j}; D={d}");
                        return d;
                    }
                }
            }

            return -1;
        }
    }
}
