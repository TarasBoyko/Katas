using Kata1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    // A stub class for "StringCalculator".
    class StringCalculatorStub : StringCalculator
    {
        // Always returns 10
        // @inputString specifies fictive parameter of the method.
        public override int Add(string inputString)
        {
            return 10;
        }
    }
}
