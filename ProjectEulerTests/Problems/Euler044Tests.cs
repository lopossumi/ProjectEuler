using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Problems.Tests
{
    [TestClass()]
    public class Euler044Tests
    {
        [TestMethod()]
        public void Euler044Test()
        {
            IEulerProblem p = new Euler044();
            Assert.AreEqual("5482660", p.Result());
        }
    }
}