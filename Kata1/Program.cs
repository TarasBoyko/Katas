using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A class, that constains the application entry point.
    class Program
    {
        // The application entry point.
        // Reads user's commands from commnad-line or terminal.
        // @args specifies arguments command-line or terminal arguments.
        static void Main(string[] args)
        {
            ConsoleCommandReader cr = new ConsoleCommandReader();
            cr.ListenForCommands();
        }
    }
}
