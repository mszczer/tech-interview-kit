/*
 * Difficulty: Hard
 * Problem:
 *  Given an integer num, write a program to find the closest palindrome to integer num. (excluding num).
 *  The output need not be larger than num. It can be smaller or larger than num.
 *  Problem Note:
 *      An integer is said to be a palindrome if it remains the same when its digits are reversed.
 *      'Closest' means that the absolute difference between two integers should be minimum.
 *      num is a positive integer represented by a string, whose length will not exceed 15 digits.
 *      If two palindromic integers are closest to num and there is a tie between them, then return the smaller one as output.
 */

namespace Coding.Challenges.Hard;

public static class ClosestPalindrome
{
    public static string FindClosestPalindrome(string num)
    {
        ArgumentNullException.ThrowIfNull(num);

        var originalNum = long.Parse(num);
        var closestPalindrome = long.MinValue;

        for (long i = 1;; i++)
        {
            // Check lower palindrome
            var lowerCandidate = originalNum - i;
            if (lowerCandidate >= 0 && IsPalindrome(lowerCandidate))
            {
                closestPalindrome = lowerCandidate;
                break;
            }

            // Check upper palindrome
            var upperCandidate = originalNum + i;
            if (IsPalindrome(upperCandidate))
            {
                closestPalindrome = upperCandidate;
                break;
            }
        }

        return closestPalindrome.ToString();
    }

    private static bool IsPalindrome(long num)
    {
        var str = num.ToString();
        for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            if (str[i] != str[j])
                return false;

        return true;
    }
}