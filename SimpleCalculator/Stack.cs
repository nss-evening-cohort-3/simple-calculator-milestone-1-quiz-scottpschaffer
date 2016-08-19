using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Stack
    {
        List<string> theStack = new List<string>();
        
        public void add2Stack(string listq, string list)
        {
            theStack.Add(listq);
            theStack.Add(list);
        }

        public string readFromStack(string which)
        {
            string result = "empty stack";
            if (theStack.Count > 0)
            {
                switch (which)
                {
                    case "listq":
                        result = theStack[theStack.Count - 2];
                        break;
                    case "list":
                        result = theStack[theStack.Count - 1];
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
       
    }
}
