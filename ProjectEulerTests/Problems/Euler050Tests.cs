using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectEuler.Problems.Tests
{
    [TestClass()]
    public class Euler050Tests
    {
        [TestMethod()]
        public void Euler050Test()
        {
            IEulerProblem p = new Euler050();
            Assert.AreEqual("997651", p.Result());
        }
    }
}