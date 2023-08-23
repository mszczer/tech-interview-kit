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

    public static double ComputePowerDivideAndConquer(int baseNumber, int exponent)
    {
        throw new NotImplementedException();
    }

    public static double ComputePowerDivideAndConquerOptimized(int baseNumber, int exponent)
    {
        throw new NotImplementedException();
    }
}