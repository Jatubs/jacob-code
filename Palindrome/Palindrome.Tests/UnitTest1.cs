using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindrome.Library;
namespace Palindrome.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPalindrome1ShouldPass()
        {
            PalindromChecker newchecker = new PalindromChecker();
            Assert.IsTrue(newchecker.CheckPalindrome("hello olleh"));
        }
       
        [TestMethod]
        public void TestPalindrome2ShouldPass()
        {
            PalindromChecker newchecker = new PalindromChecker();
            Assert.IsTrue(newchecker.CheckPalindrome("never odd, or even"));
        }
        [TestMethod]
        public void TestPalindrome3ShouldPass()
        {
            PalindromChecker newchecker = new PalindromChecker();
            Assert.IsTrue(newchecker.CheckPalindrome("racecar"));
        }
        [TestMethod]
        public void TestPalindrome4ShouldFail()
        {
            PalindromChecker newchecker = new PalindromChecker();
            Assert.IsTrue(newchecker.CheckPalindrome("hello, fred! hello..."));
        }
        [TestMethod]
        public void TestPalindrome5ShouldPass()
        {
            PalindromChecker newchecker = new PalindromChecker();
            Assert.IsTrue(newchecker.CheckPalindrome("12233221"));
        }
        [TestMethod]
        public void TestPalindrome6ShouldPass()
        {
            PalindromChecker newchecker = new PalindromChecker();
            Assert.IsTrue(newchecker.CheckPalindrome("122.33221"));
        }
    }
}
