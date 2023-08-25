namespace Coding.Challenges;

/*
 * Difficulty: Easy
 * Problem:
 *  Given two integers k and n , write a function to compute k^n.
 *  You can assume that k and n are small and overflow cannot happen.
 */
public abstract class PowerFunction
{
    public static double ComputePowerIteratively(int baseNumber, int exponent)
    {
        var power = 1.00;

        for (var i = 0; i < Math.Abs(exponent); i++)
            power *= baseNumber;

        return exponent < 0 ? 1 / power : power;
    }

    /*
     * 1. Check if the exponent is 0 then return 1 otherwise
     * 2. if exponent is even: power(base, expo) = power(base, expo/2) * power(base, expo/2)
     * 3. if exponent is odd : power(base, expo) = base * power(base, expo/2)*power(base, expo/2)
     */
    public static double ComputePowerDivideAndConquer(int baseNumber, int exponent)
    {
        if (exponent == 0) return 1;

        if (exponent % 2 == 0)  // exponent is even
            return ComputePowerDivideAndConquer(baseNumber, exponent / 2) *
                   ComputePowerDivideAndConquer(baseNumber, exponent / 2);
        else                    // exponent is odd
        {
            if (exponent > 0)
                return baseNumber * ComputePowerDivideAndConquer(baseNumber, exponent / 2) * 
                       ComputePowerDivideAndConquer(baseNumber, exponent / 2);
            else 
                return 1/(ComputePowerDivideAndConquer(baseNumber, exponent / 2) * 
                          ComputePowerDivideAndConquer(baseNumber, exponent / 2));
        }
    }

    public static double ComputePowerDivideAndConquerOptimized(int baseNumber, int exponent)
    {
        throw new NotImplementedException();
    }
}