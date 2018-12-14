using Kata1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    // A stub class for "IWebService".
    class IWebService_Stub : IWebService
    {
        // Initialize "IWebService_Stub" object.
        // @HandleLoggingFailure_return specified assing value for "m_HandleLoggingFailure_return".
        public IWebService_Stub(bool HandleLoggingFailure_return)
        {
            m_HandleLoggingFailure_return = HandleLoggingFailure_return;
        }

        // Always returns "m_HandleLoggingFailure_param_message".
        // @message specifies fake parameter of the method and assigns "HandleLoggingFailure_param_message".
        public bool HandleLoggingFailure(string message)
        {
            HandleLoggingFailure_param_message = message;
            return m_HandleLoggingFailure_return;
        }

        protected readonly bool m_HandleLoggingFailure_return; // a value, that "HandleLoggingFailure" always returns
        public string HandleLoggingFailure_param_message { get; protected set; } // the last value of parameter @message of "HandleLoggingFailure" method
    }
}
