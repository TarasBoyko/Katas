using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    class CalculationResultConsoleWriter : IConsoleWriter
    {
        public virtual void Write(int value)
        {
            Console.Write("The result is " + value + Environment.NewLine);
        }
    }
}
