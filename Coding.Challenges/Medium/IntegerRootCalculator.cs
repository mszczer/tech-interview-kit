namespace Coding.Challenges.Medium;

/*
 * Difficulty: Medium
 * Problem:
 *  Write a program to compute and return the square root of an integer num.
 *  Where num is guaranteed to be a non-negative integer.
 *  If num is not a perfect square, then return floor(√num)
 */

public class IntegerRootCalculator
{
    private const int MaxCubeRootValue = 2_097_151;

    public static int LinearSearchSquareRoot(int num)
    {
        if (num is 0 or 1) return num;
        var squareRoot = 2;
        while ((long)squareRoot * squareRoot <= num) squareRoot++;

        return squareRoot - 1;
    }

    public static int BinarySearchSquareRoot(int num)
    {
        if (num is 0 or 1) return num;
        var left = 2;
        var right = num / 2;
        while (left <= right)
        {
            var middle = left + (right - left) / 2;
            var middleSquared = (long)middle * middle;
            if (middleSquared == num) return middle;
            if (middleSquared < num) left = middle + 1;
            else right = middle - 1;
        }

        return right;
    }

    public static int LinearSearchCubeRoot(int num)
    {
        if (num is 0 or 1) return num;
        var cubeRoot = 2;
        while ((long)cubeRoot * cubeRoot * cubeRoot <= num) cubeRoot++;

        return cubeRoot - 1;
    }

    public static int BinarySearchCubeRoot(int num)
    {
        if (num is 0 or 1) return num;

        var left = 2;
        var right = Math.Min(num, MaxCubeRootValue);

        while (left <= right)
        {
            var middle = left + (right - left) / 2;
            var middleCubed = (long)middle * middle * middle;

            if (middleCubed == num) return middle;
            if (middleCubed < num)
                left = middle + 1;
            else
                right = middle - 1;
        }

        return right;
    }

    public static List<int> GetPrimeFactors(int num)
    {
        var primeFactors = new List<int>();

        if (num < 0)
        {
            primeFactors.Add(-1);
            num = Math.Abs(num);
        }

        for (var i = 2; i <= num / i; i++)
            while (num % i == 0)
            {
                primeFactors.Add(i);
                num /= i;
            }

        if (num > 1)
            primeFactors.Add(num);
        return primeFactors;
    }

    public static bool IsPerfectSquareIterative(int num)
    {
        if (num < 0) return false;
        var root = 1;
        while ((long)root * root < num)
            root++;
        return (long)root * root == num;
    }

    public static bool IsPerfectSquareOddSum(int num)
    {
        if (num < 0) return false;
        var odd = 1;
        while (num > 0)
        {
            num -= odd;
            odd += 2;
        }
        return num == 0;
    }

}
