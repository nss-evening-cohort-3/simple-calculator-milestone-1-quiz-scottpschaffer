using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Stack
    {
        private List<string> theStack = new List<string>();
        private Dictionary<string, string> theVariables = new Dictionary<string, string>();

        public void add2Stack(string listq, string list)
        {
            theStack.Add(listq);
            theStack.Add(list);
        }

        public string readFromStack(string which)
        {
            string result = "Error!";
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

        public void add2Dictionary(string theKey, string theValue)
        {
            theVariables.Add(theKey, theValue);
        }

        public string readFromDictionary(string theKey)
        {
            string theValue = "Error!";
            if (theVariables.ContainsKey(theKey))
            {
                theValue = theVariables[theKey];
            }
            return theValue;
        }

        public bool doesKeyAlreadyExist(string theKey)
        {
            bool isThere = false;
            if (theVariables.ContainsKey(theKey))
            {
                isThere = true;
            }
            return isThere;
        }
    }
}
