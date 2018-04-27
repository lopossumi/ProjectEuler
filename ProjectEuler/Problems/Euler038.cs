using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectEuler.Common.Numerology;

namespace ProjectEuler.Problems
{
    // Take the number 192 and multiply it by each of 1, 2, and 3:
    //
    //    192 × 1 = 192
    //    192 × 2 = 384
    //    192 × 3 = 576
    //
    // By concatenating each product we get the 1 to 9 pandigital, 192384576.
    // We will call 192384576 the concatenated product of 192 and (1, 2, 3)
    //
    // The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, 
    // giving the pandigital, 918273645, which is the concatenated product of 9 and (1, 2, 3, 4, 5).
    //
    // What is the largest 1 to 9 pandigital 9 - digit number that can be formed as the concatenated 
    // product of an integer with (1, 2, ... , n) where n > 1 ?
    public class Euler038 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            int largestPan = 0;

            for (int n = 2; n <= 5; n++)
            {
                int x = 9999;
                while (true)
                {
                    string number = "";
                    foreach (int k in Enumerable.Range(1, n))
                    {
                        number += (k * x);
                    }

                    if (number.Length > 9) break;
                    if (number.First() != '9') break;
                    if (number.Length == 9)
                    {
                        if (IsPandigital(number))
                        {
                            //Console.WriteLine($"{x} x (1..{n}) is pan");
                            largestPan = Math.Max(largestPan, Int32.Parse(number));
                        }
                    }
                    x--;
                }
            }

            return largestPan;
        }
    }
}


