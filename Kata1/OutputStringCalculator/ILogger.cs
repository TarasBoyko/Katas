using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // Interface for logging.
    interface ILogger
    {
        // Appends to predefined resource @data in predefined format optionaly with some service data.
        // @data specifies data, that will be logged.
        void Write(string data);
    }
}
