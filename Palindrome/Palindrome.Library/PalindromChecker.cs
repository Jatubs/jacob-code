using System;

namespace Palindrome.Library
{
    public class PalindromChecker
    {
        public bool CheckPalindrome(string input)
        {
            string str = "This is a test";
            str = input.Replace(" ", String.Empty);
            str = str.Replace(",", String.Empty);
            str = str.Replace(".", String.Empty);
            //str = str.Replace("@", String.Empty);
            //str = str.Replace("#", String.Empty);
            //str = str.Replace("$", String.Empty);
            //str = str.Replace("%", String.Empty);
            //str = str.Replace("^", String.Empty);
            //str = str.Replace("&", String.Empty);
            //str = str.Replace("*", String.Empty);
            //str = str.Replace("(", String.Empty);
            //str = str.Replace(")", String.Empty);

            char[] inputarr = str.ToCharArray();
            Array.Reverse(inputarr);
            string inputstr = new string(inputarr);

            if (str.Equals(inputstr, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
