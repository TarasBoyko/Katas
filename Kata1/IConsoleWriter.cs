using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // Interface for writting to the console or terminal with some additional data.
    interface IConsoleWriter
    {
        // Writes @data to the console or terminal with some additional data.
        // @value specifies value for writting to the console or terminal with some additional data.
        void Write(int data);
    }
}
