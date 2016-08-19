using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void TestAddition1()
        {
            Math m1 = new Math();
            int answer1 = m1.AddNumbers(1, -8);
            Assert.AreEqual(answer1, -7);
        }

        [TestMethod]
        public void TestAddition2()
        {
            Math m2 = new Math();
            int answer2 = m2.AddNumbers(4321, 9876);
            Assert.AreEqual(answer2, 14197);
        }

        [TestMethod]
        public void TestSubtraction1()
        {
            Math m3 = new Math();
            int answer3 = m3.SubtractNumbers(5432, 765);
            Assert.AreEqual(answer3, 4667);
        }

        [TestMethod]
        public void TestSubtraction2()
        {
            Math m4 = new Math();
            int answer4 = m4.SubtractNumbers(654, 876);
            Assert.AreEqual(answer4, -222);
        }

        [TestMethod]
        public void TestModulo1()
        {
            Math m5 = new Math();
            int answer5 = m5.ModuloNumbers(93, 5);
            Assert.AreEqual(answer5, 3);
        }

        [TestMethod]
        public void TestModulo2()
        {
            Math m6 = new Math();
            int answer6 = m6.ModuloNumbers(93, 3);
            Assert.AreEqual(answer6, 0);
        }

        [TestMethod]
        public void TestMultiplication1()
        {
            Math m7 = new Math();
            int answer7 = m7.MultiplyNumbers(98, 322);
            Assert.AreEqual(answer7, 31556);
        }

        [TestMethod]
        public void TestMultiplication2()
        {
            Math m8 = new Math();
            int answer8 = m8.MultiplyNumbers(-40, 987);
            Assert.AreEqual(answer8, -39480);
        }

        [TestMethod]
        public void TestDivision1()
        {
            Math m9 = new Math();
            int answer9 = m9.DivideNumbers(987, 3);
            Assert.AreEqual(answer9, 329);
        }

        [TestMethod]
        public void TestDivision2()
        {
            Math m10 = new Math();
            int answer10 = m10.DivideNumbers(54, -3);
            Assert.AreEqual(answer10, -18);
        }

        [TestMethod]
        public void TestDivision3()
        {
            Math m11 = new Math();
            int answer11 = m11.DivideNumbers(77, 2);
            Assert.AreEqual(answer11, 38);
        }

        [TestMethod]
        public void TestDivision4SmallResult()
        {
            Math m12 = new Math();
            int answer12 = m12.DivideNumbers(333, 555);
            Assert.AreEqual(answer12, 0);
        }

        [TestMethod]
        public void TestDivision5DivBy0()
        {
            Math m13 = new Math();
            int answer13 = m13.DivideNumbers(9, 0);
            Assert.AreEqual(answer13, 0);
        }
    }
}
