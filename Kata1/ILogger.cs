using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // Interface for logging.
    public interface ILogger
    {
        // Appends to predefined resource @data in predefined format optionaly with some service data.
        void Write(string data);
    }
}
