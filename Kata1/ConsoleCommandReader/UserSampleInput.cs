using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // An interface for standard simple user input.
    class UserSampleInput : IUserInput
    {
        // Implements IUserInput.ReadLine().
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
