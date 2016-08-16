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
            Regex r1 = new Regex(@"\s*(?<fNum>\d+)\s*(?<symbol>[\D])\s*(?<sNum>\d+)\s*");
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
    }
}
