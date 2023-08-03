namespace Coding.Challenges;

public abstract class ReverseBits
{
    /*
     * Given a non-negative integer num , write a program to return the number obtained after reversing the bits of num.
     * The actual binary representation of the number is being considered for reversing the bits, no leading 0’s are being considered.
     * Example: 
     *  Input: 13
     *  Output: 11
     *  Explanation: Binary representation of 13 is 1101. After reversing the bits we get 1011 which is equal to 11.
     */
    public static int GetReverseBitNumber(int num)
    {
        var binaryStr = DecIntToBinary(num);
        var reversedBinary = Reverse(binaryStr);

        return BinaryToDecInt(reversedBinary);
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
        var binaryString = "";

        while (quotient > 0)
        {
            var reminder = quotient % 2;
            quotient /= 2;
            binaryString += reminder.ToString();
        }

        return Reverse(binaryString);
    }

    private static string Reverse(string inputString)
    {
        var stringArray = inputString.ToCharArray();
        Array.Reverse(stringArray);
        var reversedString = new string(stringArray);
        return reversedString;
    }
}