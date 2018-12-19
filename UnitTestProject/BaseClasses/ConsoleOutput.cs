using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTestProject.BaseClasses
{
    // A base class for test classes, which test console output.
    // PRECONDITION: output stream should not be redirected after a testee operation of a testee class.
    [TestClass]
    public class ConsoleOutput
    {
        public ConsoleOutput()
        {
            if (Console.IsOutputRedirected)
            {
                Assert.Fail("standard output stream should not be redirected");
            }
            m_standardConsoleOutputStream = Console.Out;
        }

        // Checks asserts of class "ConsoleOutput".
        // @expectedConsoleOutput specifies expected console output.
        protected void CheckInheritedAsserts(string expectedConsoleOutput)
        {
            Assert.AreEqual(m_outputStreamBeforeOperation, Console.Out, "output stream should not be redirected after the operation (precondition of the test class)");
            Assert.AreEqual(expectedConsoleOutput, OutputStorage.Storage, "expected console output and actual console are not equal");
        }

        // A storage where redirect console output before a testee operation of a testee class.
        internal TextOutputStorageDevice OutputStorage
        {
            get
            {
                return m_outputStorage;
            }

            set
            {
                m_outputStorage = value;
            }
        }
        private TextOutputStorageDevice m_outputStorage;

        [TestInitialize()]
        public void TestInitialize()
        {
            OutputStorage = new TextOutputStorageDevice();
            Console.SetOut(OutputStorage);
            m_outputStreamBeforeOperation = Console.Out;
        }

        [TestCleanup()]
        public void TestCleanUp()
        {
            Console.SetOut(m_standardConsoleOutputStream);
            OutputStorage = null;
            m_outputStreamBeforeOperation = null;
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
        private TestContext testContextInstance;

        protected readonly TextWriter m_standardConsoleOutputStream;
        // output stream before a testee operation of a testee class
        protected TextWriter m_outputStreamBeforeOperation;
    }
}
