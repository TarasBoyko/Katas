using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // An interface for a class, that gets a string (contains an expressions), parses it,
    //calculates it and outputs the result.
    interface IOutputStringCalculator
    {
        // Calculate the expression in @inputString
        // @inputString specifies a string, that contains an expression.
        int Add(string inputString);
    }
}
