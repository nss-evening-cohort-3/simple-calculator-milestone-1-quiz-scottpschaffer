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
        public string[] Extract(string exp)
        {
            string[] exp1 = new string[3];
            Regex r1 = new Regex(@"\s*(?<fNum>\d+)\s*(?<symbol>[\+\-\%\*\/])\s*(?<sNum>\d+)\s*");
            Match m1 = r1.Match(exp);
            if (m1.Success)
            {
                GroupCollection g1 = m1.Groups;
                exp1[0] = g1["fNum"].Value;
                exp1[1] = g1["symbol"].Value;
                exp1[2] = g1["sNum"].Value;
            }
            else
            {
                exp1[0] = exp1[1] = exp1[2] = "Failed";
            }

            return exp1;
        }

        public int Process(string[] formula)
        {
            Math m1 = new Math();
            int answer = 0;
            switch (formula[1])
            {
                case "+":
                    answer = m1.AddNumbers(int.Parse(formula[0]), int.Parse(formula[2]));
                    break;
                case "-":
                    answer = m1.SubtractNumbers(int.Parse(formula[0]), int.Parse(formula[2]));
                    break;
                case "%":
                    answer = m1.ModuloNumbers(int.Parse(formula[0]), int.Parse(formula[2]));
                    break;
                case "*":
                    answer = m1.MultiplyNumbers(int.Parse(formula[0]), int.Parse(formula[2]));
                    break;
                case "/":
                    answer = m1.DivideNumbers(int.Parse(formula[0]), int.Parse(formula[2]));
                    if (answer == 0)
                        goto default;
                    break;
                default:
                    Console.WriteLine("Answer is either too small or divide by Zero");
                    break;
            }

            return answer;
        }
    }
}
