using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Problems.Tests
{
    [TestClass()]
    public class Euler046Tests
    {
        [TestMethod()]
        public void Euler046Test()
        {
            IEulerProblem p = new Euler046();
            Assert.AreEqual("5777", p.Result());
        }
    }
}