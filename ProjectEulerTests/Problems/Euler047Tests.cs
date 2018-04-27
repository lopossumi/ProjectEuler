using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Problems.Tests
{
    [TestClass()]
    public class Euler047Tests
    {
        [TestMethod()]
        public void Euler047Test()
        {
            IEulerProblem p = new Euler047();
            Assert.AreEqual("134043", p.Result());
        }
    }
}