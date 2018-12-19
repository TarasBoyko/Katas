using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.BaseClasses;
using Kata1;

namespace UnitTestProject
{
    [TestClass]
    public class ConsoleCommandReader_Test : ConsoleOutput
    {
        public ConsoleCommandReader_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        public void ListenForCommands_InputOfValidUsersCommands_CommandsExecuted()
        {
            IStringCalculator calculator_stub = new IStringCalculator_Stub_Add_ReturnValue(90);
            ILogger logger_mock = new CalculationResultLogger_Mock_NormalWrite("OutputStringCalculator_logs.txt");
            IConsoleWriter_Mock_WriteData consoleWriter = new IConsoleWriter_Mock_WriteData("The result is 10" + Environment.NewLine);
            OutputStringCalculator calculator = new OutputStringCalculator(calculator_stub, logger_mock, consoleWriter, null);

            List<string> userInputs = new List<string>
            {
                "calc '1,3,5'",
                ""
            };
            IUserInput_Stub userInput_stub = new IUserInput_Stub(userInputs);
            ConsoleCommandReader commandReader = new ConsoleCommandReader(calculator, userInput_stub);

            commandReader.ListenForCommands();

            CheckInheritedAsserts("The result is 10" + Environment.NewLine + "Another input please" + Environment.NewLine);


            //
            // TODO: Add test logic here
            //
        }
    }
}
