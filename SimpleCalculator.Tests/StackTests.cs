using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestStackListq()
        {
            Stack st1 = new Stack();
            st1.add2Stack("1+2", "3");
            string result1 = st1.readFromStack("listq");
            Assert.AreEqual(result1, "1+2");
        }

        [TestMethod]
        public void TestStackList()
        {
            Stack st2 = new Stack();
            st2.add2Stack("1+2", "3");
            string result2 = st2.readFromStack("list");
            Assert.AreEqual(result2, "3");
        }

        [TestMethod]
        public void TestDictionary()
        {
            Stack st3 = new Stack();
            st3.add2Dictionary("n", "35");
            string result3 = st3.readFromDictionary("n");
            Assert.AreEqual(result3, "35");
        }
    }
}
