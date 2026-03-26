using System.Text;

namespace Coding.Challenges.Easy;

public abstract class ReverseBits
{
    /*
     * Difficulty: Easy
     * Problem:
     *  Given a non-negative integer num, write a program to return the number obtained after reversing the bits of num.
     *  The actual binary representation of the number is being considered for reversing the bits, no leading 0’s are being considered.
     *  Example:
     *   Input: 13
     *   Output: 11
     *   Explanation: Binary representation of 13 is 1101. After reversing the bits we get 1011 which is equal to 11.
     */
    public static int GetReverseBitNumber(int num)
    {
        var binaryStr = DecIntToBinary(num);
        var reversedBinary = Reverse(binaryStr);

        return BinaryToDecInt(reversedBinary);
    }

    /*
     * Bitwise and shift operators:
     *  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator
     * Step 1: Create a variable result and initialize it with 0
     * Step 2: If num > 0
     *  Multiply res with 2
     *  If num is odd then add 1 to res.
     *  Divide num by 2.
     * Step 3: Repeat step 2, until num > 0.
     * Step 4: Return res.
     */
    public static int GetReverseBitNumberShiftingBits(int num)
    {
        var result = 0;

        // traversing bits of 'num' from the right 
        while (num > 0)
        {
            // bitwise left shift  
            // 'result' by 1 
            result <<= 1;

            // if current bit is '1' or num is odd
            if ((num & 1) == 1)
                result ^= 1; // Convert 0 to 1

            // bitwise right shift  
            // 'num' by 1 
            num >>= 1; // divide num by 2 
        }

        return result;
    }

    /*
     * Binary to decimal:
     * Step 1: Write the binary number and count the powers of 2 from right to left(starting from 0).
     * Step 2: Write each binary digit(right to left) with corresponding powers of 2 from right to left, such that first binary digit will be multiplied by the greatest power of 2.
     * Step 3: Add all the products in the step 2.
     */
    private static int BinaryToDecInt(string binaryStr)
    {
        var power = binaryStr.Length - 1;
        var result = 0;
        foreach (var c in binaryStr)
        {
            result += Convert.ToInt32(char.GetNumericValue(c)) * Convert.ToInt32(Math.Pow(2, power));
            power--;
        }

        return result;
    }

    /*
     * Decimal integers to binary:
     * Step 1. Divide the integer by 2, while noting the quotient and remainder.
     * Step 2. Divide the quotient again by 2, and record the 3rd quotient and remainder.
     * Step 3. Keep dividing each successive quotient by 2 until you get a quotient of zero.
     * Step 4. After this, write all the remainders in reverse order to get the binary representation of the integer.
     */
    private static string DecIntToBinary(int num)
    {
        var quotient = num;
        var binaryString = new StringBuilder();

        while (quotient > 0)
        {
            var reminder = quotient % 2;
            quotient /= 2;
            binaryString.Append(reminder);
        }

        return Reverse(binaryString.ToString());
    }

    private static string Reverse(string inputString)
    {
        var stringArray = inputString.ToCharArray();
        Array.Reverse(stringArray);
        var reversedString = new string(stringArray);
        return reversedString;
    }

    public static string InvertActualBits(string binaryStr)
    {
        var invertedBinary = new StringBuilder();
        var foundFirstOne = false;

        foreach (var c in binaryStr)
            if (c == '1')
            {
                foundFirstOne = true;
                invertedBinary.Append('0');
            }
            else if (foundFirstOne)
            {
                invertedBinary.Append('1');
            }

        return invertedBinary.Length == 0 ? "1" : invertedBinary.ToString();
    }

    public static string SetOddBitsToOne(string binaryStr)
    {
        var coreBinary = binaryStr.TrimStart('0');

        if (string.IsNullOrEmpty(coreBinary))
            return "0";

        var oddBitsSetToOne = new StringBuilder();

        for (var i = 0; i < coreBinary.Length; i++)
            oddBitsSetToOne.Append(i % 2 == 1 ? '1' : coreBinary[i]);

        return oddBitsSetToOne.ToString();
    }

    public static string SetEvenBitsToZero(string binaryStr)
    {
        var coreBinary = binaryStr.TrimStart('0');

        if (string.IsNullOrEmpty(coreBinary))
            return "0";

        var evenBitsSetToZero = new StringBuilder(coreBinary.Length);

        for (var i = 0; i < coreBinary.Length; i++)
            evenBitsSetToZero.Append(i % 2 == 0 ? '0' : coreBinary[i]);

        return evenBitsSetToZero.ToString();
    }

    public static bool IsPalindrome(int num)
    {
        var binaryStr = DecIntToBinary(num);

        var left = 0;
        var right = binaryStr.Length - 1;

        while (left < right)
        {
            if (binaryStr[left] != binaryStr[right])
                return false;

            left++;
            right--;
        }

        return true;
    }

    // Given an integer n, rotate its bits left/right by k positions (within a fixed bit width).
    // k > 0 => rotate right, k < 0 => rotate left
    public static string RotateBitsOfNumber(string binaryStr, int k)
    {
        var coreBinary = binaryStr.TrimStart('0');

        if (string.IsNullOrEmpty(coreBinary))
            return "0";

        if (coreBinary.Length == 1)
            return coreBinary;

        // Normalize to rotate RIGHT by r in [0..coreBinary.Length-1]
        var r = k % coreBinary.Length;
        if (r < 0)
            r += coreBinary.Length;

        if (r == 0)
            return coreBinary;

        // Rotate right by r: last r bits + first (n-r) bits
        var suffix = coreBinary.Substring(coreBinary.Length - r, r);
        var prefix = coreBinary[..^r];
        return suffix + prefix;
    }
}