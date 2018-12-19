using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata1;
using System.Text.RegularExpressions;
using System.IO;
using UnitTestProject.BaseClasses;

namespace UnitTestProject
{
    [TestClass]
    public class OutputStringCalculator_Test : ConsoleOutput
    {

        [TestMethod]
        public void Add_PassValidArg_LoggingSuccess_ReturnCorrectValue()
        {            
            IStringCalculator calculator_stub = new IStringCalculator_Stub_Add_ReturnValue(10);
            ILogger logger_mock = new CalculationResultLogger_Mock_NormalWrite("OutputStringCalculator_logs.txt");
            IConsoleWriter_Mock_WriteData consoleWriter = new IConsoleWriter_Mock_WriteData("The result is 10");
            OutputStringCalculator calculator = new OutputStringCalculator(calculator_stub, logger_mock, consoleWriter, null);


            string fileContentBeforeOperation = File.ReadAllText("OutputStringCalculator_logs.txt");

            int addResult = calculator.Add("//[#@%][;&][!!!]\n6!!!2#@%0#@%1;&1");

            string fileContentAfterOperation = File.ReadAllText("OutputStringCalculator_logs.txt");
            bool isSuccess = new Regex("^" + fileContentBeforeOperation + "The last calculation result is " + addResult.ToString() + "\\. 12\\.12\\.2018 16:03:26" + Environment.NewLine + "$").IsMatch(fileContentAfterOperation);

            Assert.IsTrue(isSuccess);
            CheckInheritedAsserts(consoleWriter.WriteOutput);
        }

        [TestMethod]
        public void Add_PassValidArg_LoggingFailure_WebServiceNotificationSuccess_ReturnCorrectValue()
        {
            IStringCalculator calculator_stub = new IStringCalculator_Stub_Add_ReturnValue(11);
            ILogger logger_mock = new CalculationResultLogger_Mock_LoggingFailure(null);
            IConsoleWriter_Mock_WriteData consoleWriter = new IConsoleWriter_Mock_WriteData("The result is 10");
            IWebService_Stub webService_stub = new IWebService_Stub(true);
            OutputStringCalculator calculator = new OutputStringCalculator(calculator_stub, logger_mock, consoleWriter, webService_stub);

            calculator.Add("//[#@%][;&][!!!]\n6!!!2#@%0#@%1;&2");

            Assert.AreEqual("logging was failed", webService_stub.HandleLoggingFailure_param_message, "a mesaage for IWebService notification is incorrect" );
            CheckInheritedAsserts(consoleWriter.WriteOutput);
        }

    } // OutputStringCalculator_Test
} // UnitTestProject
