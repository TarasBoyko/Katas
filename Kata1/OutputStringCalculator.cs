using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A class for logging results of "StringCalculator" instance and output it to the standart output stream.
    // The logging happens depend on "ILogger" instance.
    // The calculation happens depend on "IStringCalculator" instance.
    // The output to the standart output stream happens depend on "IConsoleWriter" instance.
    class OutputStringCalculator
    {
        // Initializes "OutputStringCalculator" object.
        // @stringCalculator specifies instance of "IStringCalculator".
        // @consoleWriter specifies instance of "IConsoleWriter".
        // @logger specifies instance of "ILogger".
        public OutputStringCalculator(IStringCalculator stringCalculator, ILogger logger, IConsoleWriter consoleWriter, IWebService webService)
        {
            m_stringCalculator = stringCalculator;
            m_logger = logger;
            m_consoleWriter = consoleWriter;
            m_webService = webService;
        }

        // Calculates the amount of number list in special string format and logs, output the result to the standart output stream and returns the result.
        // @inputString specifies string in the special string format, that will be calculated.
        public int Add(string inputString)
        {
            int result = m_stringCalculator.Add(inputString);
            m_consoleWriter.Write(result);
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
        protected IConsoleWriter m_consoleWriter; // "IConsoleWriter" instance
        protected IWebService m_webService; // "IWebService" instance
    }
}
