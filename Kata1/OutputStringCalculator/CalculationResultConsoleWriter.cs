using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A writer for console output about result of calculation.
    class CalculationResultConsoleWriter : IConsoleWriter
    {
        // Implements IConsoleWriter.Write(int).
        // @value specifies a value for console output.
        public virtual void Write(int value)
        {
            Console.Write("The result is " + value + Environment.NewLine);
        }
    }
}
