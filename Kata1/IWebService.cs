using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // Interface for web service
    interface IWebService
    {
        // Handles logging failure.
        // In the case of success returns true,
        // otherwise - returns false.
        // @message specifies failure explaining message.
        bool HandleLoggingFailure(string message);
    }
}
