using ProjectEuler.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ProjectEuler.Common.Numerology;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Common.Tests
{
    [TestClass()]
    public class NumerologyTests
    {
        [TestMethod()]
        public void HasEvenDigitsTest()
        {
            Assert.IsTrue(HasEvenDigits(123));
            Assert.IsTrue(HasEvenDigits(21353));
            Assert.IsFalse(HasEvenDigits(115377));
        }

        [TestMethod()]
        public void IsPandigitalTest()
        {
            Assert.IsTrue(IsPandigital("123456789"));
            Assert.IsTrue(IsPandigital("987654321"));
            Assert.IsTrue(IsPandigital("654987321"));
            Assert.IsFalse(IsPandigital("54987321"));
            Assert.IsFalse(IsPandigital("554987321"));
            Assert.IsFalse(IsPandigital("054987321"));
        }

        [TestMethod()]
        public void TruncateLeftTest()
        {
            Assert.AreEqual(7896, TruncateLeft(17896));
            Assert.AreEqual(0, TruncateLeft(5));
        }

        [TestMethod()]
        public void FirstDigitTest()
        {
            Assert.AreEqual(5, FirstDigit(523));
            Assert.AreEqual(3, FirstDigit(3));
            Assert.AreEqual(0, FirstDigit(0));
        }

        [TestMethod()]
        public void IsPalindromicTest()
        {
            Assert.IsTrue(IsPalindromic(313));
            Assert.IsTrue(IsPalindromic(5445));
            Assert.IsFalse(IsPalindromic(540144));
            Assert.IsTrue(IsPalindromic(8));
        }

        [TestMethod()]
        public void IsHexagonalTest()
        {
            int[] array = { 1, 6, 15, 28, 45 };
            HashSet<int> hexagonals = new HashSet<int>(array);

            foreach (int i in Enumerable.Range(1, 45))
            {
                if (hexagonals.Contains(i))
                {
                    Assert.IsTrue(IsHexagonal(i));
                }
                else
                {
                    Assert.IsFalse(IsHexagonal(i));
                }
            }
            Assert.IsFalse(IsHexagonal(40754));
            Assert.IsTrue(IsHexagonal(40755));
            Assert.IsFalse(IsHexagonal(40756));
        }

        [TestMethod()]
        public void IsPentagonalTest()
        {
            int[] array = { 1, 5, 12, 22, 35 };
            HashSet<int> pentagonals = new HashSet<int>(array);

            foreach (int i in Enumerable.Range(1, 35))
            {
                if (pentagonals.Contains(i))
                {
                    Assert.IsTrue(IsPentagonal(i));
                }
                else
                {
                    Assert.IsFalse(IsPentagonal(i));
                }
            }
            Assert.IsFalse(IsPentagonal(40754));
            Assert.IsTrue(IsPentagonal(40755));
            Assert.IsFalse(IsPentagonal(40756));
        }

        [TestMethod()]
        public void IsTriangleTest()
        {
            int[] array = { 1, 3, 6, 10, 15 };
            HashSet<int> triangles = new HashSet<int>(array);

            foreach (int i in Enumerable.Range(1, 15))
            {
                if (triangles.Contains(i))
                {
                    Assert.IsTrue(IsTriangle(i));
                }
                else
                {
                    Assert.IsFalse(IsTriangle(i));
                }
            }
            Assert.IsFalse(IsTriangle(40754));
            Assert.IsTrue(IsTriangle(40755));
            Assert.IsFalse(IsTriangle(40756));
        }
    }
}