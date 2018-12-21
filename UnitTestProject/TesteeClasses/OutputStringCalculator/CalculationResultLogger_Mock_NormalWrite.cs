using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // A mock class for "AbstractLogger".
    class CalculationResultLogger_Mock_NormalWrite : AbstractLogger
    {
        // Always assigns "OutputStringCalculator_logs.txt" as path to log file.
        // @filePath specifies fake parameter of the method.
        public CalculationResultLogger_Mock_NormalWrite(string filePath) : base("OutputStringCalculator_logs.txt")
        {
            ;
        }

        // Always adds string "The last calculation result is 10. 12.12.2018 16:03:26\r\n" to
        // log file with path "OutputStringCalculator_logs.txt".
        // If predefined log file does not exist, exception "FileNotFoundException" is thrown.
        // @data specifies fake parameter of the method.
        public override void Write(string data)
        {
            if (!File.Exists("OutputStringCalculator_logs.txt"))
            {
                throw new FileNotFoundException();
            }

            File.AppendAllText("OutputStringCalculator_logs.txt", "The last calculation result is 10. 12.12.2018 16:03:26" + Environment.NewLine);
        }
    }
}
