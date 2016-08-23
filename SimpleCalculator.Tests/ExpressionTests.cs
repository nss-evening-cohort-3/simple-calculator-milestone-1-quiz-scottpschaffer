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
            Assert.AreEqual(symbol[0], "Error!");
        }

        [TestMethod]
        public void SpecifyBadOperand1()
        {
            string operand1 = " 1 q 321533";
            Expression ExpOp1 = new Expression();
            string[] symbol = ExpOp1.Extract(operand1);
            Assert.AreEqual(symbol[0], "Error!");
        }

        [TestMethod]
        public void SpecifyBadOperand2()
        {
            string operand2 = " 1 6 321533";
            Expression ExpOp2 = new Expression();
            string[] symbol = ExpOp2.Extract(operand2);
            Assert.AreEqual(symbol[0], "Error!");
        }

        [TestMethod]
        public void TestQuit1()
        {
            string command1 = "quit";
            Expression ExQuit1 = new Expression();
            string[] com1 = ExQuit1.Extract(command1);
            Assert.AreEqual(com1[0], "quit");
        }

        [TestMethod]
        public void TestQuit2()
        {
            string command2 = "QUIT";
            Expression ExQuit2 = new Expression();
            string[] com2 = ExQuit2.Extract(command2);
            Assert.AreEqual(com2[0], "quit");
        }

        [TestMethod]
        public void TestExit1()
        {
            string command3 = "exit";
            Expression ExExit1 = new Expression();
            string[] com3 = ExExit1.Extract(command3);
            Assert.AreEqual(com3[0], "exit");
        }

        [TestMethod]
        public void TestExit2()
        {
            string command4 = "EXIT";
            Expression ExExit2 = new Expression();
            string[] com4 = ExExit2.Extract(command4);
            Assert.AreEqual(com4[0], "exit");
        }

        [TestMethod]
        public void TestList()
        {
            string express1 = "1+3";
            Expression ExList1 = new Expression();
            string[] list1 = ExList1.Extract(express1);
            string answer1 = ExList1.Process(list1, express1);
            string[] list2 = ExList1.Extract("list");
            string answer2 = ExList1.Process(list2, "list");
            Assert.AreEqual(answer1, answer2);
        }

        [TestMethod]
        public void TestListq()
        {
            string express3 = "1+3";
            Expression ExList3 = new Expression();
            string[] list3 = ExList3.Extract(express3);
            string answer3 = ExList3.Process(list3, express3);
            string[] list4 = ExList3.Extract("listq");
            string answer4 = ExList3.Process(list4, "listq");
            Assert.AreEqual(answer4, express3);
        }

        [TestMethod]
        public void TestAdditionProcess()
        {
            string[] Add1 = new string[3] { "19", "+", "87" };
            int ans1 = 0;
            Expression ExAdd1 = new Expression();
            int.TryParse(ExAdd1.Process(Add1, "19+87"), out ans1);
            Assert.AreEqual(ans1, 106);
        }


        [TestMethod]
        public void TestSubtractionProcess()
        {
            string[] Sub1 = new string[3] { "19", "-", "87" };
            int ans2 = 0;
            Expression ExSub1 = new Expression();
            int.TryParse(ExSub1.Process(Sub1, "19-87"), out ans2);
            Assert.AreEqual(ans2, -68);
        }

        [TestMethod]
        public void TestMultiplicationProcess()
        {
            string[] Mul1 = new string[3] { "19", "*", "87" };
            int ans3 = 0;
            Expression ExMul1 = new Expression();
            int.TryParse(ExMul1.Process(Mul1, "19*87"), out ans3);
            Assert.AreEqual(ans3, 1653);
        }

        [TestMethod]
        public void TestDivisionProcess()
        {
            string[] Div1 = new string[3] { "1934", "/", "87" };
            int ans4 = 0;
            Expression ExDiv1 = new Expression();
            int.TryParse(ExDiv1.Process(Div1, "1934/87"), out ans4);
            Assert.AreEqual(ans4, 22);
        }

        [TestMethod]
        public void TestModulusProcess()
        {
            string[] Mod1 = new string[3] { "1955", "%", "87" };
            int ans5 = 0;
            Expression ExMod1 = new Expression();
            int.TryParse(ExMod1.Process(Mod1, "1955%87"), out ans5);
            Assert.AreEqual(ans5, 41);
        }

        [TestMethod]
        public void TestAssignmentProcess()
        {
            string[] Assign1 = new string[3] { "x", "=", "457" };
            string[] Assign2 = new string[3] { "x", "Error!", "Error" };
            int ans6 = 0;
            Expression ExAssign1 = new Expression();
            ExAssign1.Process(Assign1, "  x  =  457  ");
            int.TryParse(ExAssign1.Process(Assign2, "x"), out ans6);
            Assert.AreEqual(ans6, 457);
        }
    }
}
