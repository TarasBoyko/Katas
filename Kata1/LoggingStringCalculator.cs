using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A class for logging results of "StringCalculator" instance.
    // The logging happens depend on "ILogger" instance.
    // The calculation happens depend on "StringCalculator" instance.
    public class LoggingStringCalculator
    {
        // Initializes "LoggingStringCalculator" object.
        // @stringCalculator specifies instance of "StringCalculator".
        // @logger specifies instance of "ILogger".
        public LoggingStringCalculator(StringCalculator stringCalculator, ILogger logger)
        {
            m_stringCalculator = stringCalculator;
            m_logger = logger;
        }

        // Calculates the amount of number list in special string format and logs and returns the result.
        // @inputString specifies string in the special string format, that will be calculated.
        public int Add(string inputString)
        {
            int result = m_stringCalculator.Add(inputString);
            m_logger.Write(result.ToString());
            return result;
        }

        protected StringCalculator m_stringCalculator; // "StringCalculator" instance
        protected ILogger m_logger; // "ILogger" instance.
    }
}
