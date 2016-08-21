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
            //
            do
            {
                Console.Write("[" + c + "]> ");
                inp = Console.ReadLine().ToLower();
                string[] x1 = e1.Extract(inp);
                if (x1[0] != "Failed")
                {
                    x2 = e1.Process(x1, inp);
                    Console.WriteLine("   = " + x2);
                }
                
                c++;
            } while ((inp.ToLower() != "quit") && (inp.ToLower() != "exit"));

            Console.WriteLine("Bye!!");
            Console.ReadLine();
            
        }
    }
}
