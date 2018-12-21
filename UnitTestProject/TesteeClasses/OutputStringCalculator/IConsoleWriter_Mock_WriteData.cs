using Kata1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    // A mock class for "IConsoleWriter".
    // "Write" method of the class writes to console or terminal defined in the ctor call data.
    class IConsoleWriter_Mock_WriteData : IConsoleWriter
    {
        // Initializes "IConsoleWriter_Mock_WriteData" object.
        // @WriteOutput specified assing value for property "WriteOutput".
        public IConsoleWriter_Mock_WriteData(string WriteOutput)
        {
            this.WriteOutput = WriteOutput;
        }

        // Always writes to console or terminal property "WriteOutput".
        // @data specifies fake parameter of the method.
        public void Write(int data)
        {
            Console.Write(WriteOutput);
        }

        public string WriteOutput { get; protected set; }  // a value, that "Write" always writes to console or terminal
    }
}
