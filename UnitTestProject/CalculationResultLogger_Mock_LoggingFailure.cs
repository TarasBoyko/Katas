using Kata1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    // A mock class for "CalculationResultLogger". The class specifies logging failure.
    class CalculationResultLogger_Mock_LoggingFailure : AbstractLogger
    {
        // Initializes "CalculationResultLogger_Mock_LoggingFailure" object.
        // @filePath specifies fake parameter of the method.
        public CalculationResultLogger_Mock_LoggingFailure(string filePath) : base("")
        {
            ;
        }

        // Always throws an exception with message "logging was failed".
        // @data specifies fake parameter of the method.
        public override void Write(string data)
        {
            throw new Exception("logging was failed");
        }
    }
}
