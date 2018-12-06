using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata1;
using System.Diagnostics;

namespace UnitTestProject
{
    /// <summary>
    /// Tests StringCalculator class.
    /// </summary>
    [TestClass]
    public class StringCalculator_Test
    {
        static StringCalculator stringCalculator;

        [TestMethod]
        public void Add_InputEmptyString()
        {
            int result = stringCalculator.Add("");
            Assert.AreEqual(0, result);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_InputOneNumber.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_InputOneNumber()
        {
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult, "arg " + arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_InputOneNumber.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_InputTwoNumbers()
        {
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult, "arg " + arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_DifferentSeparators.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_DifferentSeparators()
        {
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult,"arg "+ arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_NegativeNumbers.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_NegativeNumbers()
        {
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            string exceptionMessage = Convert.ToString(TestContext.DataRow["exceptionMessage"]);

            try
            {
                int actualResult = stringCalculator.Add(arg);
            }
            catch(ArgumentException e)
            {
                Assert.AreEqual(e.Message, exceptionMessage, "exception is thrown, but the message is incorrect\n" + e.Message);
                Debug.WriteLine(e.Message);
                return;
            }
            Assert.Fail("exception is not thrown");

            //Assert.Fail()
            //Assert.AreEqual(expectedResult, actualResult, "arg " + arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
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

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            Debug.WriteLine("Initialization of StringCalculatior_Test class");
            stringCalculator = new StringCalculator();
        }

        public StringCalculator_Test()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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
    }
}
