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
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("password should not be null" + Environment.NewLine + "Parameter name: password", e.Message);
                return;
            }
            catch (Exception)
            {
                Assert.Fail("the thrown exception is not ArgumentNullException");
            }
         
            Assert.Fail("exception is not thrown");
        }

        [TestMethod]
        public void Verify_PassArgWithLenghtLessThanMin_ThrowArgumentException()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            try
            {
                verifier.Verify("Uj3hdf78");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("password should be larger than 8 chars", e.Message);
                return;
            }
            catch (Exception)
            {
                Assert.Fail("the thrown exception is not ArgumentException");
            }

            Assert.Fail("exception is not thrown");
        }

        [TestMethod]
        public void Verify_PassLowerLessArg_ThrowArgumentException()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            try
            {
                verifier.Verify("123456345BG");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("password should have one lowercase letter at least", e.Message);
                return;
            }
            catch (Exception)
            {
                Assert.Fail("the thrown exception is not ArgumentException");
            }

            Assert.Fail("exception is not thrown");
        }

        [TestMethod]
        public void Verify_PassUpperLessArg_ThrowArgumentException()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            try
            {
                verifier.Verify("12345dfs6345");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("password should have one uppercase letter at least", e.Message);
                return;
            }
            catch (Exception)
            {
                Assert.Fail("the thrown exception is not ArgumentException");
            }

            Assert.Fail("exception is not thrown");
        }

        [TestMethod]
        public void Verify_PassNumberLessArg_ThrowArgumentException()
        {
            PasswordVerifier verifier = new PasswordVerifier();

            try
            {
                verifier.Verify("hfdskfhJHHFjfdsheu");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("password should have one number at least", e.Message);
                return;
            }
            catch (Exception)
            {
                Assert.Fail("the thrown exception is not ArgumentException");
            }

            Assert.Fail("exception is not thrown");
        }
    }
}
