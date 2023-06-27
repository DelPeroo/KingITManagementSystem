using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PasswordCheckerUnitTest
{
    [TestClass]
    public class CheckSafenessTest
    {
        [TestMethod]
        public void CheckSafeness_abc_0returned()
        {
            string password = "abc";
            int expected = 0;

            int actual = PasswordChecker.SafenessChecker.CheckSafeness(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckSafeness_abC_1returned()
        {
            string password = "abC";
            int expected = 1;

            int actual = PasswordChecker.SafenessChecker.CheckSafeness(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckSafeness_abCspecsymbol_2returned()
        {
            string password = "abC*";
            int expected = 2;

            int actual = PasswordChecker.SafenessChecker.CheckSafeness(password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckSafeness_abCspecsymbol9_3returned()
        {
            string password = "abC*9";
            int expected = 3;

            int actual = PasswordChecker.SafenessChecker.CheckSafeness(password);

            Assert.AreEqual(expected, actual);
        }
    }
}
