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
            exp = exp.ToLower();
            string[] exp1 = new string[] { "Error!", "Error!", "Error!" };
            // r1 is initial regex for regular math expression without variables
            Regex r1 = new Regex(@"\s*(?<fNum>\d+)\s*(?<symbol>[\+\-\%\*\/])\s*(?<sNum>\d+)\s*");
            // r2 is variable assignment
            Regex r2 = new Regex(@"\s*(?<fVari>[a-z])\s*(?<symbol>\=)\s*(?<sNum>\d+)\s*");
            // r3 is equation with 2 variables
            Regex r3 = new Regex(@"\s*(?<fVari>[a-z])\s*(?<symbol>[\+\-\%\*\/])\s*(?<sVari>[a-z])\s*");
            // r4 is for variable on left side of equation
            Regex r4 = new Regex(@"\s*(?<vari>[a-z])\s*(?<symbol>[\+\-\%\*\/])\s*(?<sNum>\d+)\s*");
            // r5 is for variable on right side of equation
            Regex r5 = new Regex(@"\s*(?<fNum>\d+)\s*(?<symbol>[\+\-\%\*\/])\s*(?<vari>[a-z])\s*");
            // r6 is quit
            Regex r6 = new Regex(@"\s*(?<quit1>quit)\s*");
            // r7 is exit
            Regex r7 = new Regex(@"\s*(?<exit1>exit)\s*");
            // r8 is typing in variable to get value
            Regex r8 = new Regex(@"^\s*(?<vari>[a-z])\s*");

            // Assigning results of Regex Matching values
            Match m1 = r1.Match(exp);
            Match m2 = r2.Match(exp);
            Match m3 = r3.Match(exp);
            Match m4 = r4.Match(exp);
            Match m5 = r5.Match(exp);
            Match m6 = r6.Match(exp);
            Match m7 = r7.Match(exp);
            Match m8 = r8.Match(exp);

            // if match is successful, then assign Regex values to variables
            if (m1.Success)
            {
                // Regular equation with first Number, the math symbol, then second number
                GroupCollection g1 = m1.Groups;
                exp1[0] = g1["fNum"].Value;
                exp1[1] = g1["symbol"].Value;
                exp1[2] = g1["sNum"].Value;
            }

            // If "list" or "listq" was entered
            else if ((exp == "list") || (exp == "listq"))
            {
                exp1[0] = exp;
            }

            // If variable assignment, symbol should be "="
            else if (m2.Success)
            {
                GroupCollection g2 = m2.Groups;
                exp1[0] = g2["fVari"].Value;
                exp1[1] = g2["symbol"].Value;
                exp1[2] = g2["sNum"].Value;
            }

            // If two variables in same equation assign first variable, symbol, then second variable
            else if (m3.Success)
            {
                GroupCollection g3 = m3.Groups;
                exp1[0] = g3["fVari"].Value;
                exp1[1] = g3["symbol"].Value;
                exp1[2] = g3["sVari"].Value;
            }

            // Math with variable on left side of equation
            else if (m4.Success)
            {
                GroupCollection g4 = m4.Groups;
                exp1[0] = g4["vari"].Value;
                exp1[1] = g4["symbol"].Value;
                exp1[2] = g4["sNum"].Value;
            }

            // Math with variable on right side of equation
            else if (m5.Success)
            {
                GroupCollection g5 = m5.Groups;
                exp1[0] = g5["fNum"].Value;
                exp1[1] = g5["symbol"].Value;
                exp1[2] = g5["vari"].Value;
            }

            // If "quit" is entered
            else if (m6.Success)
            {
                GroupCollection g6 = m6.Groups;
                exp1[0] = g6["quit1"].Value;
            }

            // If "exit" is entered
            else if (m7.Success)
            {
                GroupCollection g7 = m7.Groups;
                exp1[0] = g7["exit1"].Value;
            }

            // If entering just variable to get value it stores
            else if (m8.Success)
            {
                GroupCollection g8 = m8.Groups;
                exp1[0] = g8["vari"].Value;
            }

            return exp1;
        }

        public string Process(string[] formula, string originalInput)
        {
            Math m1 = new Math();
            int x, y;

            // If formula[0] is number, then it is parsed and put into x.
            // Otherwise it is a variable and is passed to Dictionary so
            // return value is written to x.
            if (!int.TryParse(formula[0], out x))
            {
                bool x1 = int.TryParse(stack1.readFromDictionary(formula[0]), out x);
            }

            // If parsing formula[2] fails, then read value from Dictionary 
            if (!int.TryParse(formula[2], out y))
            {
                bool y1 = int.TryParse(stack1.readFromDictionary(formula[2]), out y);
            }

            string answer = "";
            // performs steps according to Math symbol (stored in formula[1])
            switch (formula[1])
            {
                case "+":
                    answer = m1.AddNumbers(x, y).ToString();
                    break;
                case "-":
                    answer = m1.SubtractNumbers(x, y).ToString();
                    break;
                case "%":
                    answer = m1.ModuloNumbers(x, y).ToString();
                    break;
                case "*":
                    answer = m1.MultiplyNumbers(x, y).ToString();
                    break;
                case "/":
                    // Check if divide by 0
                    if (y != 0)
                    {
                        answer = m1.DivideNumbers(x, y).ToString();
                    }
                    else
                    {
                        // if divide by 0 then go to default for error message
                        goto default;
                    }
                       
                    break;
                case "=":

                    // first check if Dictionary already contains Key
                    if (!stack1.doesKeyAlreadyExist(formula[0]))
                    {
                        // If not in Dictionary, then add to Dictionary (Key, Value)
                        stack1.add2Dictionary(formula[0], formula[2]);
                        Console.WriteLine("   = Saved \'" + formula[0] + "\' as \'" + formula[2] + "\'");
                    }
                    else
                        // Go to default if already assigned value to constant
                        goto default;
                    break;
                case "Error!":
                    // if formula[1] is "Error!", but formula[0] is not, then
                    // it is a 1-word command or entering just constant to get value
                    if (formula[0] != "Error!")
                    {
                        // If command was "list" or "listq", read from stack
                        if ((formula[0] == "list") || (formula[0] == "listq"))
                        {
                            answer = stack1.readFromStack(formula[0]);
                        }
                        
                        // If command was quit or exit, then return blank
                        else if ((formula[0] == "quit") || (formula[0] == "exit"))
                        {
                            answer = "";
                        }
                        else
                        {
                            // If just constant, then look up value from Dictionary
                            // and return value
                            answer = stack1.readFromDictionary(formula[0]);
                        }
                    }
                    break;
                default:
                    // If all else fails, then return "Error!"
                    Console.WriteLine("Error!");
                    break;
            }
            // If finished Processing, then add equation and result to Stack.
            stack1.add2Stack(originalInput, answer);
            return answer;
        }
    }
}
