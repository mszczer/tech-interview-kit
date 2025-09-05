namespace Coding.Challenges;

/*
 * Difficulty: Easy
 * Problem:
 *  Given two integers k and n , write a function to compute k^n.
 *  You can assume that k and n are small and overflow cannot happen.
 * Ideas to think:
 *  Complexity analysis
 */
public abstract class PowerFunction
{
  
    public static double ComputePowerIteratively(double baseNumber, int exponent)
    {
        if (baseNumber == 0 && exponent == 0)
            throw new ArgumentException("0^0 is undefined.");

        var power = 1.0;
        var absExponent = Math.Abs(exponent);

        for (var i = 0; i < absExponent; i++)
            power *= baseNumber;

        return exponent < 0 ? 1.0 / power : power;
    }

    public static double ComputePowerDivideAndConquerOptimized(double baseNumber, int exponent)
    {
        if (baseNumber == 0 && exponent == 0)
            throw new ArgumentException("0^0 is undefined.");

        if (exponent == 0)
            return 1.0;

        var isNegative = exponent < 0;
        var exp = Math.Abs((long)exponent);

        var result = 1.0;
        var currBase = baseNumber;

        while (exp > 0)
        {
            if ((exp & 1) == 1)
                result *= currBase;
            currBase *= currBase;
            exp >>= 1;
        }

        return isNegative ? 1.0 / result : result;
    }
}
