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
        public LoggingStringCalculator_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

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


        [TestMethod]
        public void LoggingStringCalculator_Test_Add_NormalWork()
        {
            LoggingStringCalculator calculator = new LoggingStringCalculator(new StringCalculatorStub(), new CalculationResultLoggerMock("LoggingStringCalculator_logs.txt"));
            string fileContentBeforeOperation = File.ReadAllText("LoggingStringCalculator_logs.txt");

            int addResult = calculator.Add("//[#@%][;&][!!!]\n6!!!2#@%0#@%1;&1");

            string fileContentAfterOperation = File.ReadAllText("LoggingStringCalculator_logs.txt");
            bool isSuccess = new Regex("^" + fileContentBeforeOperation + "The last calculation result is " + addResult.ToString() + "\\. \\d\\d\\.\\d\\d\\.\\d\\d\\d\\d \\d\\d:\\d\\d:\\d\\d" + Environment.NewLine + "$").IsMatch(fileContentAfterOperation);
            Assert.IsTrue(isSuccess);
        }
    }
}
