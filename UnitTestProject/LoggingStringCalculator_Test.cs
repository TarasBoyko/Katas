using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata1;
using System.Text.RegularExpressions;
using System.IO;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for LoggingStringCalculator_Test
    /// </summary>
    [TestClass]
    public class LoggingStringCalculator_Test
    {
        [TestMethod]
        public void Add_PassValidArg_LoggingSuccess_ReturnCorrectValue()
        {
            IStringCalculator calculator_stub = new IStringCalculator_Stub_Add_ReturnValue(10);
            ILogger logger_mock = new CalculationResultLogger_Mock_NormalWrite("LoggingStringCalculator_logs.txt");
            LoggingStringCalculator calculator = new LoggingStringCalculator(calculator_stub, logger_mock, null);
            string fileContentBeforeOperation = File.ReadAllText("LoggingStringCalculator_logs.txt");

            int addResult = calculator.Add("//[#@%][;&][!!!]\n6!!!2#@%0#@%1;&1");

            string fileContentAfterOperation = File.ReadAllText("LoggingStringCalculator_logs.txt");
            bool isSuccess = new Regex("^" + fileContentBeforeOperation + "The last calculation result is " + addResult.ToString() + "\\. 12\\.12\\.2018 16:03:26" + Environment.NewLine + "$").IsMatch(fileContentAfterOperation);

            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void Add_PassValidArg_LoggingFailure_WebServiceNotificationSuccess_ReturnCorrectValue()
        {
            IStringCalculator calculator_stub = new IStringCalculator_Stub_Add_ReturnValue(11);
            ILogger logger_mock = new CalculationResultLogger_Mock_LoggingFailure(null);
            IWebService_Stub webService_stub = new IWebService_Stub(true);
            LoggingStringCalculator calculator = new LoggingStringCalculator(calculator_stub, logger_mock, webService_stub);

            calculator.Add("//[#@%][;&][!!!]\n6!!!2#@%0#@%1;&2");

            Assert.AreEqual("logging was failed", webService_stub.HandleLoggingFailure_param_message, "a mesaage for IWebService notification is incorrect" );
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private TestContext testContextInstance;
    } // LoggingStringCalculator_Test
} // UnitTestProject
