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
    public class Euler041Tests
    {
        [TestMethod()]
        public void Euler041Test()
        {
            IEulerProblem p = new Euler041();
            Assert.AreEqual("7652413", p.Result());
        }
    }
}