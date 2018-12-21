using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestProject.BaseClasses;
using Kata1;
using UnitTestProject.TesteeClasses.ConsoleCommandReader;

namespace UnitTestProject
{
    [TestClass]
    public class ConsoleCommandReader_Test : ConsoleOutput_AbstractTest
    {

        [TestMethod]
        public void ListenForCommands_UserInputsEmptyString_CommandListeningFinished()
        {
            List<string> ReadLine_Returns = new List<string>
            {
                ""
            };
            IUserInput_Stub userInput_stub = new IUserInput_Stub(ReadLine_Returns);
            IOutputStringCalculator_Mock calcuator = new IOutputStringCalculator_Mock(new List<int>());
            ConsoleCommandReader commandReader = new ConsoleCommandReader(calcuator, userInput_stub);
            StartCheckingConsoleOutput();

            commandReader.ListenForCommands();

            CheckInheritedAsserts("");
        }

        [TestMethod]
        public void ListenForCommands_InputOfValidSimpleUsersCommands_CommandsExecuted()
        {
            IOutputStringCalculator_Mock calculator = new IOutputStringCalculator_Mock(10);

            List<string> ReadLine_Returns = new List<string>
            {
                "calc '1,3,5,1'",
                ""
            };
            IUserInput_Stub userInput_stub = new IUserInput_Stub(ReadLine_Returns);
            ConsoleCommandReader commandReader = new ConsoleCommandReader(calculator, userInput_stub);
            StartCheckingConsoleOutput();

            commandReader.ListenForCommands();

            CheckInheritedAsserts("The result is 10" + Environment.NewLine + "Another input please" + Environment.NewLine);
        }

        [TestMethod]
        public void ListenForCommands_InputOfValidComplexUsersCommands_CommandsExecuted()
        {
            IOutputStringCalculator_Mock calculator = new IOutputStringCalculator_Mock(new List<int> { 10, 20 });

            List<string> ReadLine_Returns = new List<string>
            {
                "calc '1,3,5,1'",
                "calc '//[%][##][+-+]\n2%7+-+11'",
                ""
            };
            IUserInput_Stub userInput_stub = new IUserInput_Stub(ReadLine_Returns);
            ConsoleCommandReader commandReader = new ConsoleCommandReader(calculator, userInput_stub);
            StartCheckingConsoleOutput();

            commandReader.ListenForCommands();

            CheckInheritedAsserts("The result is 10" + Environment.NewLine + "Another input please" + Environment.NewLine +
                                  "The result is 20" + Environment.NewLine + "Another input please" + Environment.NewLine);
        }
    } // ConsoleCommandReader_Test
} // UnitTestProject
