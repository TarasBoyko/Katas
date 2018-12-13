using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // Logger for calculation results.
    public class CalculationResultLogger : AbstractLogger
    {
        // Initializes "CalculationResultLogger" object.
        // @filePath specifies the path to log file.
        public CalculationResultLogger(string filePath) : base(filePath)
        {
            ;
        }

        // Overrides "AbstractLogger.Write(string)".
        // If predefined log file does not exist, exception "FileNotFoundException" is thrown.
        public override void Write(string data)
        {
            if (!File.Exists(m_filePath))
            {
                throw new FileNotFoundException("Log file \"" + m_filePath + "\" is not found");
            }

            string logMessage = "The last calculation result is " + data + ". " + DateTime.Now.ToString() + Environment.NewLine;
            File.AppendAllText(m_filePath, logMessage);
        }
    }
}
