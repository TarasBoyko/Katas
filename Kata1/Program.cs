﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleCommandReader cr = new ConsoleCommandReader();
            cr.ListenForCommands();
        }
    }
}
