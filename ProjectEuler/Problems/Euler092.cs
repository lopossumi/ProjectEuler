using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectEuler.Common.Numerology;

namespace ProjectEuler.Problems
{

    public class Euler092 : IEulerProblem
    {
        public string Result()
        {
            return run3().ToString();
        }

        private static int run()
        {
            int MAX = 9999999;
            int eightyNines = 0;
            for (int i = 1; i <= MAX; i++)
            {
                int n = i;
                while (true)
                {
                    if (n == 1)
                    {
                        //Console.WriteLine(i + ": 1");
                        break;
                    }
                    else if (n == 89)
                    {
                        eightyNines++;
                        //Console.WriteLine(i + ": 89");
                        break;
                    }
                    n = sumDigitSquares(n);
                }
            }
            return eightyNines;
        }

        // Optimized with precomputed table of 89 ending values
        private static int run2()
        {
            int MAX = 9999999;
            int precomputeLimit = 600;

            bool[] ups = preCompute(precomputeLimit);

            return countEightyNines(1, MAX, ups);
        }

        private static int countEightyNines(int min, int max, bool[] ups)
        {
            int eightyNines = 0;
            //skip zero
            min = (min == 0) ? 1 : min;

            for (int i = min; i <= max; i++)
            {
                int n = i;
                while (true)
                {
                    if (n == 1)
                    {
                        //Console.WriteLine(i + ": 1");
                        break;
                    }
                    else if (n == 89)
                    {
                        eightyNines++;
                        //Console.WriteLine(i + ": 89");
                        break;
                    }
                    else if (n < ups.Length)
                    {
                        if (ups[n]) eightyNines++;
                        break;
                    }
                    n = sumDigitSquares(n);
                }
            }
            return eightyNines;
        }

        private static bool[] preCompute(int limit)
        {
            bool[] ups = new bool[limit];
            for (int i = 1; i < limit; i++)
            {
                int n = i;
                while (true)
                {
                    if (n == 1) break;
                    if (n == 89)
                    {
                        ups[i] = true;
                        break;
                    }
                    n = sumDigitSquares(n);
                }
            }
            return ups;
        }

        private static int sumDigitSquares(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += (number % 10) * (number % 10);
                number /= 10;
            }
            return sum;
        }

        // With threading (when you can't think of a better solution, throw cores at it)
        public static int run3()
        {
            int MAX = 9999999;
            var threads = Environment.ProcessorCount;
            int windowSize = MAX / threads;
            //Console.WriteLine($"Window size is {windowSize}");

            bool[] ups = preCompute(600);

            var tasks = new Task<int>[threads];

            for (int i = 0; i < threads; i++)
            {
                int windowStart = i;
                tasks[windowStart] = Task<int>.Run(() =>
                {
                    int lowLimit = windowStart * (windowSize + 1);
                    int highLimit = Math.Min((windowStart+1) * windowSize + windowStart, MAX);
                    //Console.WriteLine($"thread{windowStart} working on {lowLimit}...{highLimit}");
                    return countEightyNines(lowLimit, highLimit, ups);
                });
            }

            int count = 0;
            foreach (var task in tasks)
            {
                count += task.Result;
            }
            return count;

        }

    }
}


