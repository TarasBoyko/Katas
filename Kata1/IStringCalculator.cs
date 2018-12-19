using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // Provides methods for calculation expressions in special string format, defined by derived classes.
    interface IStringCalculator
    {
        // Returns the amount of number list in special string format.
        // @inputString specifies string in the special string format, that will be calculated.
        int Add(string inputString);
    }
}
