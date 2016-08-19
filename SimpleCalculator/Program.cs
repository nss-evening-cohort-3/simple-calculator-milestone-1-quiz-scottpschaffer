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
            int x2 = 0;
            Expression e1 = new Expression();
            //
            do
            {
                Console.Write("[" + c + "]>");
                inp = Console.ReadLine();
                string[] x1 = e1.Extract(inp);
                if (x1[0] != "Failed")
                {
                    x2 = e1.Process(x1);
                }

                Console.WriteLine("   =" + x2);

                //Console.WriteLine("First#: " + x1[0] + " Operand: " + x1[1] + " Second#: " + x1[2]);
                c++;
            } while ((inp.ToLower() != "quit") && (inp.ToLower() != "exit"));

            Console.WriteLine("Bye!!");
            Console.ReadLine();
            
        }
    }
}
