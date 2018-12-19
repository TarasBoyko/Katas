using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata1;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class StringCalculator_Test
    {
        [TestMethod]
        public void Add_PassEmptyString_ReturnZero()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int result = stringCalculator.Add("");

            Assert.AreEqual(0, result);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_PassOneNumber_ReturnSum.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_PassOneNumber_ReturnSum()
        {
            StringCalculator stringCalculator = new StringCalculator();
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult, "arg " + arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_PassTwoNumbers_ReturnSum.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_PassTwoNumbers_ReturnSum()
        {
            StringCalculator stringCalculator = new StringCalculator();
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult, "arg " + arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_PassArgWithDifferentSeparators_ReturnSum.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_PassArgWithDifferentSeparators_ReturnSum()
        {
            StringCalculator stringCalculator = new StringCalculator();
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult,"arg "+ arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_Add_PassArgWithNegativeNumbers_ExceptionIsThrown.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_PassArgWithNegativeNumbers_ExceptionIsThrown()
        {
            StringCalculator stringCalculator = new StringCalculator();
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
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_PassArgWithNumbersWithValueMoreThan1000_ReturnSumIgnoringTheseNumbers.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_PassArgWithNumbersWithValueMoreThan1000_ReturnSumIgnoringTheseNumbers()
        {
            StringCalculator stringCalculator = new StringCalculator();
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult, "arg " + arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TestData\\StringCalculator_Test_Add_PassArgWithUnlimitedDelimiter_ReturnSum.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Add_PassArgWithUnlimitedDelimiter_ReturnSum()
        {
            StringCalculator stringCalculator = new StringCalculator();
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["result"]);

            int actualResult = stringCalculator.Add(arg);

            Assert.AreEqual(expectedResult, actualResult, "arg " + arg + "\nexpected " + expectedResult + "\nactual " + actualResult);
        }

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
    } // StringCalculator_Test
} // UnitTestProject
