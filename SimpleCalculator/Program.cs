using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            string inp = "";
            string x2 = "";
            Expression e1 = new Expression();
            Stack s1 = new Stack();
            // Loop until "quit" or "exit" is entered
            do
            {
                // Prompt - c is incrementing number
                Console.Write("[" + c + "]> ");
                // inputting command
                inp = Console.ReadLine();
                // Extract take formula and splits it up into array of Strings
                string[] x1 = e1.Extract(inp);
                // x1[0] is "Error!" if Extract fails
                if (x1[0] != "Error!")
                {
                    // Process gets the formula-array and performs action
                    // Passing original inputted string for adding to Stack
                    x2 = e1.Process(x1, inp);
                    // After Process, we output the result
                    Console.WriteLine("   = " + x2);
                }
                // Increment Prompt counter
                c++;
            } while ((inp.ToLower() != "quit") && (inp.ToLower() != "exit"));
            // If typed "quit" or "exit", then write message and end after hitting Enter button
            Console.WriteLine("Bye!!");
            Console.ReadLine();
            
        }
    }
}
