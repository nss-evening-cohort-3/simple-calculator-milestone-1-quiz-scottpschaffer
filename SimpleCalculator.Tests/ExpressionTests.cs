using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void ExtractAddOneDigit()
        {
            string addition1 = "1+1";
            Expression ExpAdd1 = new Expression();
            string[] symbol = ExpAdd1.Extract(addition1);
            Assert.AreEqual(symbol[1], "+");
        }

        [TestMethod]
        public void ExtractAddTwoDigits()
        {
            string addition2 = "12+12";
            Expression ExpAdd2 = new Expression();
            string[] symbol = ExpAdd2.Extract(addition2);
            Assert.AreEqual(symbol[1], "+");
        }

        [TestMethod]
        public void ExtractAddTwoDigitsWithSpaces()
        {
            string addition3 = "12 +  12";
            Expression ExpAdd3 = new Expression();
            string[] symbol = ExpAdd3.Extract(addition3);
            Assert.AreEqual(symbol[1], "+");
        }

        [TestMethod]
        public void ExtractSubMultipleDigits()
        {
            string subtraction1 = "15 - 3";
            Expression ExpSub1 = new Expression();
            string[] symbol = ExpSub1.Extract(subtraction1);
            Assert.AreEqual(symbol[1], "-");
        }

        [TestMethod]
        public void ExtractMulMultipleDigits()
        {
            string multiplication1 = "250 * 32";
            Expression ExpMul1 = new Expression();
            string[] symbol = ExpMul1.Extract(multiplication1);
            Assert.AreEqual(symbol[1], "*");
        }

        [TestMethod]
        public void ExtractDivSingleDigitsLotsOfNumbersAndSpaces()
        {
            string division1 = "   2543205435    /     36374652        ";
            Expression ExpDiv1 = new Expression();
            string[] symbol = ExpDiv1.Extract(division1);
            Assert.AreEqual(symbol[1], "/");
        }

        [TestMethod]
        public void ExtractModTwoDigits()
        {
            string modulus1 = " 321 % 36 ";
            Expression ExpMod1 = new Expression();
            string[] symbol = ExpMod1.Extract(modulus1);
            Assert.AreEqual(symbol[1], "%");
        }

        [TestMethod]
        public void ExtractFirstNumberFromExpression()
        {
            string multiplication2 = "8374 * 321";
            Expression ExpMul2 = new Expression();
            string[] symbol = ExpMul2.Extract(multiplication2);
            Assert.AreEqual(int.Parse(symbol[0]), 8374);
        }

        [TestMethod]
        public void ExtractSecondNumberFromExpression()
        {
            string division2 = "8345821 / 321533";
            Expression ExpDiv2 = new Expression();
            string[] symbol = ExpDiv2.Extract(division2);
            Assert.AreEqual(int.Parse(symbol[2]), 321533);
        }

        [TestMethod]
        public void ExtractInvalidFirstNumber()
        {
            string division3 = " / 321533";
            Expression ExpDiv3 = new Expression();
            string[] symbol = ExpDiv3.Extract(division3);
            Assert.AreEqual(symbol[0], "Failed");
        }

        [TestMethod]
        public void SpecifyBadOperand1()
        {
            string operand1 = " 1 q 321533";
            Expression ExpOp1 = new Expression();
            string[] symbol = ExpOp1.Extract(operand1);
            Assert.AreEqual(symbol[0], "Failed");
        }

        [TestMethod]
        public void SpecifyBadOperand2()
        {
            string operand2 = " 1 6 321533";
            Expression ExpOp2 = new Expression();
            string[] symbol = ExpOp2.Extract(operand2);
            Assert.AreEqual(symbol[0], "Failed");
        }
    }
}
