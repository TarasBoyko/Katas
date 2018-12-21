using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kata1
{
    // A class for listening for user's commands from command line or terminal.
    class ConsoleCommandReader
    {
        // Initializes "ConsoleCommandReader" object.
        public ConsoleCommandReader()
        {
            m_OutputStringCalculator = new OutputStringCalculator(new StringCalculator(),
                new CalculationResultLogger("OutputStringCalculator_logs.txt"),
                new CalculationResultConsoleWriter(),
                null);
            m_userInput = new UserSampleInput();
        }

        // Initializes "ConsoleCommandReader" object.
        // @outputStringCalculator specifies "IOutputStringCalculator" instance.
        // @userInput specifies "IUserInput" instance.
        public ConsoleCommandReader(IOutputStringCalculator outputStringCalculator, IUserInput userInput)
        {
            m_OutputStringCalculator = outputStringCalculator; 
            m_userInput = userInput;
        }

        // Listens for user's commands for "OutputStringCalculator" instance and executes them.
        // indicator of the end of the command input process - empty string.
        public void ListenForCommands()
        {
            string command;
            while((command = m_userInput.ReadLine()) != "")
            {
                try
                {
                    Execute(command);
                }
                catch (Exception e)
                {
                    Console.WriteLine("The command is not valid. Exception message \"" + e.Message + "\"");
                }
                Console.WriteLine("Another input please");
            }
        }

        // Executes @command.
        // In case of invalid @command throws an exception.
        // @command specifies command for "OutputStringCalculator" instance.
        protected void Execute(string command)
        {
            //string commandRegex = ;
            Regex commandRegex = new Regex("^calc '(.|\n)*'$");
            if( commandRegex.IsMatch(command) )
            {
                int firstApostropheIndex = command.IndexOf('\'');
                int lastApostropheIndex = command.LastIndexOf('\'');
                string OutputStringCalculator_Add_Arg = command.Substring(firstApostropheIndex + 1, lastApostropheIndex - firstApostropheIndex - 1);

                m_OutputStringCalculator.Add(OutputStringCalculator_Add_Arg);
            }
            else
            {
                throw new ArgumentException("The commad for calculation is not valid");
            }
        }

        protected IOutputStringCalculator m_OutputStringCalculator; // "IOutputStringCalculator" instance.
        protected IUserInput m_userInput; // "IUserInput" instance
    } // ConsoleCommandReader
} // Kata1
