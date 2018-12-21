using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata1
{
    // Abstract logger, that contains the path to log file.
    abstract class AbstractLogger : ILogger
    {
        // @filePath specifies the path to log file
        public AbstractLogger(string filePath)
        {
            m_filePath = filePath;
        }

        public abstract void Write(string data);

        protected string m_filePath; // the path to log file.
    }
}
