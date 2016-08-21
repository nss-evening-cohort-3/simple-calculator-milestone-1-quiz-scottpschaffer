using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleCalculator
{
    public class Expression
    {
        private Stack stack1 = new Stack();

        public string[] Extract(string exp)
        {
            string[] exp1 = new string[] { "Failed", "Failed", "Failed" };
            // r1 is initial regex for regular math expression without variables
            Regex r1 = new Regex(@"\s*(?<fNum>\d+)\s*(?<symbol>[\+\-\%\*\/])\s*(?<sNum>\d+)\s*");
            // r2 is variable assignment
            Regex r2 = new Regex(@"\s*(?<fNum>[a-z])\s*(?<symbol>\=)\s*(?<sNum>\d+)\s*");
            // r3 is typing in variable to get value
            Regex r3 = new Regex(@"\s*(?<vari>[a-z])\s*");
            // r4 is for variable on left side of equation
            Regex r4 = new Regex(@"\s*(?<vari>[a-z])\s*(?<symbol>[\+\-\%\*\/])\s*(?<sNum>\d+)\s*");
            // r5 is for variable on right side of equation
            Regex r5 = new Regex(@"\s*(?<fNum>\d+)\s*(?<symbol>[\+\-\%\*\/])\s*(?<vari>[a-z])\s*");


            Match m1 = r1.Match(exp);
            Match m2 = r2.Match(exp);
            Match m3 = r3.Match(exp);
            Match m4 = r4.Match(exp);
            Match m5 = r5.Match(exp);

            if (m1.Success)
            {
                GroupCollection g1 = m1.Groups;
                exp1[0] = g1["fNum"].Value;
                exp1[1] = g1["symbol"].Value;
                exp1[2] = g1["sNum"].Value;
            }
            else if ((exp == "list") || (exp == "listq"))
            {
                exp1[0] = exp;
            }
            else if (m2.Success)
            {
                GroupCollection g2 = m2.Groups;
                exp1[0] = g2["fNum"].Value;
                exp1[1] = g2["symbol"].Value;
                exp1[2] = g2["sNum"].Value;
            }
            else if (m3.Success)
            {
                GroupCollection g3 = m3.Groups;
                 exp1[0] = g3["vari"].Value;
            }
            else if (m4.Success)
            {
                GroupCollection g4 = m4.Groups;
                exp1[0] = g4["vari"].Value;
                exp1[1] = g4["symbol"].Value;
                exp1[2] = g4["sNum"].Value;
            }
            else if (m5.Success)
            {
                GroupCollection g5 = m5.Groups;
                exp1[0] = g5["fNum"].Value;
                exp1[1] = g5["symbol"].Value;
                exp1[2] = g5["vari"].Value;
            }

            return exp1;
        }

        public string Process(string[] formula, string originalInput)
        {
            Math m1 = new Math();

            string answer = "";
            switch (formula[1])
            {
                case "+":
                    answer = m1.AddNumbers(int.Parse(formula[0]), int.Parse(formula[2])).ToString();
                    break;
                case "-":
                    answer = m1.SubtractNumbers(int.Parse(formula[0]), int.Parse(formula[2])).ToString();
                    break;
                case "%":
                    answer = m1.ModuloNumbers(int.Parse(formula[0]), int.Parse(formula[2])).ToString();
                    break;
                case "*":
                    answer = m1.MultiplyNumbers(int.Parse(formula[0]), int.Parse(formula[2])).ToString();
                    break;
                case "/":
                    int f0 = int.Parse(formula[0]);
                    int f2 = int.Parse(formula[2]);
                    if (f2 != 0)
                    {
                        answer = m1.DivideNumbers(f0, f2).ToString();
                    }
                    else
                    {
                        goto default;
                    }
                       
                    break;
                case "=":
                    if (!stack1.doesKeyAlreadyExist(formula[0]))
                    {
                        stack1.add2Dictionary(formula[0], formula[2]);
                        Console.WriteLine("   = Saved \'" + formula[0] + "\' as \'" + formula[2] + "\'");
                    }
                    else
                        goto default;
                    break;
                case "Failed":
                    string ans = "";
                    if (formula[0] != "Failed")
                    {
                        if ((formula[0] == "list") || (formula[0] == "listq"))
                        {
                            answer = stack1.readFromStack(formula[0]);
                        }
                        else
                        {
                            answer = stack1.readFromDictionary(formula[0]);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            stack1.add2Stack(originalInput, answer);
            return answer;
        }
    }
}
