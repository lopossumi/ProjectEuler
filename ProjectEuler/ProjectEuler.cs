using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    class ProjectEuler
    {
        static void Main(string[] args)
        {
            Stopwatch t = new Stopwatch();
            IEulerProblem p = new Euler092();
            t.Start();
            var result = p.Result();
            t.Stop();
            Console.WriteLine("Result: " + result + ", time elapsed: " + t.ElapsedMilliseconds + "ms");
            Console.ReadLine();
        }      
    }
}
