using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectEuler.Common.Numerology;

namespace ProjectEuler.Problems
{

    public class Euler033 : IEulerProblem
    {
        public string Result()
        {
            return run().ToString();
        }

        private static int run()
        {
            List<int> up = new List<int>();
            List<int> down = new List<int>();

            for (int x = 11; x < 99; x++)
            {
                if (x % 10 == 0) continue;

                for (int y = x + 1; y < 99; y++)
                {
                    if (y % 10 == 0) continue;

                    if (x / 10 == y % 10)
                    {
                        double frac1 = (x / (double)y);
                        double frac2 = ((x % 10) / (double)(y / 10));
                        if (Math.Abs(frac1 - frac2) < 0.000001)
                        {
                            Console.WriteLine($"{x}/{y}");
                            up.Add(x);
                            down.Add(y);
                        }
                    }
                    if (x % 10 == y / 10)
                    {
                        double frac1 = (x / (double)y);
                        double frac2 = ((x / 10) / (double)(y % 10));
                        if (Math.Abs(frac1 - frac2) < 0.000001)
                        {
                            Console.WriteLine($"{x}/{y}");
                            up.Add(x);
                            down.Add(y);
                        }
                    }
                }
            }

            int ups = 1;
            int downs = 1;

            foreach (var item in up)
            {
                ups *= item;
            }
            foreach (var item in down)
            {
                downs *= item;
            }

            return downs/GCD(ups, downs);
        }
    }
}


