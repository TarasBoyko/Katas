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
    class LoggingStringCalculator
    {
        // Initializes "LoggingStringCalculator" object.
        // @stringCalculator specifies instance of "StringCalculator".
        // @logger specifies instance of "ILogger".
        public LoggingStringCalculator(IStringCalculator stringCalculator, ILogger logger, IWebService webService)
        {
            m_stringCalculator = stringCalculator;
            m_logger = logger;
            m_webService = webService;
        }

        // Calculates the amount of number list in special string format and logs and returns the result.
        // @inputString specifies string in the special string format, that will be calculated.
        public int Add(string inputString)
        {
            int result = m_stringCalculator.Add(inputString);
            try
            {
                m_logger.Write(result.ToString());
            }
            catch (Exception e)
            {
                m_webService.HandleLoggingFailure(e.Message);
            }
            return result;
        }

        protected IStringCalculator m_stringCalculator; // "IStringCalculator" instance
        protected ILogger m_logger; // "ILogger" instance
        protected IWebService m_webService; // "IWebService" instance
    }
}
