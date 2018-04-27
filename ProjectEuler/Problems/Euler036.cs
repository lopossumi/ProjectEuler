using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectEuler.Common.Numerology;

namespace ProjectEuler.Problems
{

    public class Euler036 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            int sum = 0;
            // Check only odd numbers as the binary must end in 1
            for (int i = 1; i < 1000000; i = i + 2)
            {
                if (IsPalindromic(i))
                {
                    string binary = Convert.ToString(i, 2);

                    if (IsPalindromic(binary))
                    {
                        sum += i;
                    }
                }
            }
            return sum;
        }
    }
}


