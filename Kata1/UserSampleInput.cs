using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    class UserSampleInput : IUserInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
