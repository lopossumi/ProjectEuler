using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    public class Euler039 : IEulerProblem
    {

        // If p is the perimeter of a right angle triangle with integral length sides, { a, b, c }, there are exactly three 
        // solutions for p = 120.

        // { 20, 48, 52 }, { 24, 45, 51 }, { 30, 40, 50 }

        // For which value of p ≤ 1000, is the number of solutions maximised?

        public string Result()
        {
            return run().ToString();
        }

        private int run()
        {
            int perimeterLimit = 1000;
            int result = 0;

            int maxNumberOfSolutions = 0;
            for (int p = 10; p < perimeterLimit; p++)
            {
                int numberOfSolutions = 0;
                for (int a = 2; a * 2 < p; a++)
                {
                    for (int b = 2; b < a; b++)
                    {
                        int c = p - a - b;

                        if (a * a + b * b == c * c)
                        {
                            numberOfSolutions++;
                            if (numberOfSolutions > maxNumberOfSolutions)
                            {
                                maxNumberOfSolutions = numberOfSolutions;
                                result = p;
                                //Console.WriteLine($"{p} ({a} {b} {c})");
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}


