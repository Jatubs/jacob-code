using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Library;
namespace Palindrome.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PalindromChecker newchecker = new PalindromChecker();

            Assert.IsTrue(newchecker.CheckPalindrome("hello olleh"));
        }
    }
}
