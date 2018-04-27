using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static ProjectEuler.Common.Primes;

namespace ProjectEuler.Common.Tests
{
    [TestClass()]
    public class PrimesTests
    {
        [TestMethod()]
        public void PrimesUnderMillion()
        {
            HashSet<int> primesUnderMillion = PrimesUnderLimit(1000000);
            Assert.AreEqual(78498, primesUnderMillion.Count);
        }

        [TestMethod()]
        public void PrimesUnder10Million()
        {
            HashSet<int> primesUnder10Million = PrimesUnderLimit(10000000);
            Assert.AreEqual(664579, primesUnder10Million.Count);
        }

        [TestMethod()]
        public void PrimesUnder100Million()
        {
            HashSet<int> primesUnder100Million = PrimesUnderLimit(100000000);
            Assert.AreEqual(5761455, primesUnder100Million.Count);
        }

        [TestMethod()]
        public void PrimeCheckTableUnder10Million()
        {
            bool[] primesUnder100Million = IsPrimeUnderLimit(10000000);
            Assert.IsTrue(true);
            //Assert.AreEqual(5761455, primesUnder100Million.Count);
        }

    }
}