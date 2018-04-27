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
    public class Euler033Tests
    {
        [TestMethod()]
        public void Euler033Test()
        {
            IEulerProblem p = new Euler033();
            Assert.AreEqual("100", p.Result());
        }
    }
}