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
            Expression e1 = new Expression();
            string[] x1 = e1.Extract(" / 321533");
            Console.Write(x1[0]);
        }
    }
}
