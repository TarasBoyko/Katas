using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // An interface for user's input.
    interface IUserInput
    {
        // Reads user's until new line character.
        string ReadLine();
    }
}
