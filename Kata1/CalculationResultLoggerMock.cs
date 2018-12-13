using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A mock class for "CalculationResultLogger".
    public class CalculationResultLoggerMock : AbstractLogger
    {
        // Always assigns "LoggingStringCalculator_logs.txt" as path to log file.
        // @filePath specifies fictive parameter of the method.
        public CalculationResultLoggerMock(string filePath) : base("LoggingStringCalculator_logs.txt")
        {
            ;
        }

        // Always adds string "The last calculation result is 10. 12.12.2018 16:03:26\r\n" to
        // log file with path "LoggingStringCalculator_logs.txt".
        // If predefined log file does not exist, exception "FileNotFoundException" is thrown.
        // @data specifies fictive parameter of the method.
        public override void Write(string data)
        {
            if (!File.Exists("LoggingStringCalculator_logs.txt"))
            {
                throw new FileNotFoundException();
            }

            File.AppendAllText("LoggingStringCalculator_logs.txt", "The last calculation result is 10. 12.12.2018 16:03:26" + Environment.NewLine);
        }
    }
}
