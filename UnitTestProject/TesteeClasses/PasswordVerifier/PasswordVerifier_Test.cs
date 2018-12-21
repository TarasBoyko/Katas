using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata1;

namespace UnitTestProject
{
    [TestClass]
    public class PasswordVerifier_Test
    {
        [TestMethod]
        public void Verify_PassNull_ThrowNullArgumentException()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            try
            {
                verifier.Verify(null);
            }          
            catch (ArgumentNullException)
            {
                return; // the test passes
            }
            catch (Exception)
            {
                Assert.Fail("the thrown exception is not ArgumentNullException");
            }

            Assert.Fail("exception is not thrown");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "TesteeClasses\\PasswordVerifier\\TestData\\PasswordVerifier_Test_Verify_PassNonNullArg_ReturnResultOfVerification.xml",
            "Row",
            DataAccessMethod.Sequential)
        ]
        [TestMethod]
        public void Verify_PassNonNullArg_ReturnResultOfVerification()
        { 
            PasswordVerifier verifier = new PasswordVerifier();
            string arg = Convert.ToString(TestContext.DataRow["arg"]);
            bool expectedResult = Convert.ToBoolean(TestContext.DataRow["result"]);

            bool actualResult = verifier.Verify(arg);

            Assert.AreEqual(expectedResult, actualResult, "expected and actual results are not equal.\n arg = " + arg + "\nexpected = " + expectedResult + "\nactual = " + actualResult);
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
    } // PasswordVerifier_Test
} // UnitTestProject
