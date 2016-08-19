using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Math
    {
        public int AddNumbers(int num1, int num2)
        {
            return (num1 + num2);
        }

        public int SubtractNumbers(int num1, int num2)
        {
            return (num1 - num2);
        }

        public int ModuloNumbers(int num1, int num2)
        {
            return (num1 % num2);
        }

        public int MultiplyNumbers(int num1, int num2)
        {
            return (num1 * num2);
        }

        public int DivideNumbers(int num1, int num2)
        {
            if (num2 == 0)
            {
                return 0;
            }
            else
            {
                return (num1 / num2);
            }
        }
    }
}
