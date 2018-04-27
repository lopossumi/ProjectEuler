using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectEuler.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems.Tests
{
    [TestClass()]
    public class Euler039Tests
    {
        [TestMethod()]
        public void Euler039Test()
        {
            IEulerProblem p = new Euler039();
            Assert.AreEqual("840", p.Result());
        }
    }
}