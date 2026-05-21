namespace Coding.Challenges.Medium;

/*
 * Difficulty: Medium
 * Problem:
 *  Given two non-negative integers num1 and num2, write a program to find the greatest common divisor (GCD) of both the numbers.
 *  GCD of 2 integers num1 and num2 is defined as the greatest integer k such that k is a divisor of both num1 and num2.
 *
 * Three approaches:
 *  1. Brute Force - Check all divisors from min(num1, num2) down to 1
 *  2. Euclidean Algorithm - Efficient recursive/iterative approach using modulo
 *  3. Prime Factorization - Find common prime factors and multiply them
 */

public class GreatestCommonDivisor
{
    /// <summary>
    ///     Brute force approach: Iterate from min(num1, num2) down to 1 to find the greatest common divisor.
    /// </summary>
    public static int FindGCD_BruteForce(int num1, int num2)
    {
        if (num1 == 0) return num2;
        if (num2 == 0) return num1;

        var minNum = Math.Min(num1, num2);

        for (var i = minNum; i >= 1; i--)
            if (num1 % i == 0 && num2 % i == 0)
                return i;

        return 1;
    }

    /// <summary>
    ///     Euclidean Algorithm: Most efficient approach using the property that GCD(a, b) = GCD(b, a mod b).
    /// </summary>
    public static int FindGCD_EuclideanAlgorithm(int num1, int num2)
    {
        if (num1 == 0) return num2;
        if (num2 == 0) return num1;

        while (num2 != 0)
        {
            var remainder = num1 % num2;
            num1 = num2;
            num2 = remainder;
        }

        return num1;
    }

    /// <summary>
    ///     Prime Factorization approach: Find prime factors of both numbers and multiply common ones.
    /// </summary>
    public static int FindGCD_PrimeFactorization(int num1, int num2)
    {
        if (num1 == 0) return num2;
        if (num2 == 0) return num1;

        var num1PrimeFactors = GetPrimeFactors(num1);
        var num2PrimeFactors = GetPrimeFactors(num2);
        var commonPrimeFactors = GetCommonPrimeFactors(num1PrimeFactors, num2PrimeFactors);

        var gcd = 1;
        foreach (var factor in commonPrimeFactors)
            gcd *= factor;

        return gcd;
    }

    private static List<int> GetCommonPrimeFactors(List<int> num1PrimeFactors, List<int> num2PrimeFactors)
    {
        var commonPrimeFactors = new List<int>();
        var num2FactorsCopy = new List<int>(num2PrimeFactors);

        foreach (var factor in num1PrimeFactors)
            if (num2FactorsCopy.Contains(factor))
            {
                num2FactorsCopy.Remove(factor);
                commonPrimeFactors.Add(factor);
            }

        return commonPrimeFactors;
    }

    private static List<int> GetPrimeFactors(int num)
    {
        var primeFactors = new List<int>();

        while (num % 2 == 0)
        {
            primeFactors.Add(2);
            num /= 2;
        }

        // Check odd factors from 3 onwards, only up to sqrt(num)
        for (var i = 3; i * i <= num; i += 2)
            while (num % i == 0)
            {
                primeFactors.Add(i);
                num /= i;
            }

        // If num is still greater than 1, it's a prime factor
        if (num > 1)
            primeFactors.Add(num);

        return primeFactors;
    }

    /// <summary>
    ///     Calculate LCM using GCD: Uses the mathematical property that LCM(a, b) = (a * b) / GCD(a, b).
    /// </summary>
    public static int GetLCM_UsingGCD(int num1, int num2)
    {
        if (num1 == 0 || num2 == 0) return 0;

        var gcd = FindGCD_EuclideanAlgorithm(num1, num2);

        return num1 / gcd * num2;
    }

    /// <summary>
    ///     Calculate LCM using Prime Factorization: Find all prime factors and use the maximum count of each factor.
    /// </summary>
    public static int GetLCM_PrimeFactorization(int num1, int num2)
    {
        if (num1 == 0 || num2 == 0) return 0;

        var num1PrimeFactors = GetPrimeFactors(num1);
        var num2PrimeFactors = GetPrimeFactors(num2);

        var lcmFactors = GetLCMPrimeFactors(num1PrimeFactors, num2PrimeFactors);

        var lcm = 1;
        foreach (var factor in lcmFactors)
            lcm *= factor;

        return lcm;
    }

    private static List<int> GetLCMPrimeFactors(List<int> num1PrimeFactors, List<int> num2PrimeFactors)
    {
        var lcmFactors = new List<int>();
        var num1FactorsCopy = new List<int>(num1PrimeFactors);
        var num2FactorsCopy = new List<int>(num2PrimeFactors);

        // Group factors by value and count
        var num1FactorCounts = num1FactorsCopy.GroupBy(f => f).ToDictionary(g => g.Key, g => g.Count());
        var num2FactorCounts = num2FactorsCopy.GroupBy(f => f).ToDictionary(g => g.Key, g => g.Count());

        // Get all unique prime factors
        var allPrimes = num1FactorCounts.Keys.Union(num2FactorCounts.Keys);

        // For each prime, take the maximum count from either number
        foreach (var prime in allPrimes)
        {
            var count1 = num1FactorCounts.GetValueOrDefault(prime, 0);
            var count2 = num2FactorCounts.GetValueOrDefault(prime, 0);
            var maxCount = Math.Max(count1, count2);

            for (var i = 0; i < maxCount; i++)
                lcmFactors.Add(prime);
        }

        return lcmFactors;
    }

    /// <summary>
    ///     Calculate GCD for floating-point numbers by converting to rational representation.
    ///     Note: GCD is mathematically defined for integers. This method approximates GCD for floats
    ///     by treating them as rational numbers with a specific precision.
    /// </summary>
    public static decimal CalculateGCDUsingFloat(decimal num1, decimal num2)
    {
        if (num1 == 0) return num2;
        if (num2 == 0) return num1;

        // Work with absolute values
        num1 = Math.Abs(num1);
        num2 = Math.Abs(num2);

        // Count decimal places for each number
        var num1DecimalPlaces = CountDecimalPlaces(num1);
        var num2DecimalPlaces = CountDecimalPlaces(num2);
        var maxDecimalPlaces = Math.Max(num1DecimalPlaces, num2DecimalPlaces);

        // Scale both numbers to integers
        var multiplier = (decimal)Math.Pow(10, maxDecimalPlaces);
        var num1Scaled = (long)(num1 * multiplier);
        var num2Scaled = (long)(num2 * multiplier);

        // Calculate GCD of scaled integers
        var gcdScaled = FindGCD_EuclideanAlgorithmLong(num1Scaled, num2Scaled);

        // Scale back to decimal
        return gcdScaled / multiplier;
    }

    private static long FindGCD_EuclideanAlgorithmLong(long num1, long num2)
    {
        num1 = Math.Abs(num1);
        num2 = Math.Abs(num2);

        while (num2 != 0)
        {
            var remainder = num1 % num2;
            num1 = num2;
            num2 = remainder;
        }

        return num1;
    }

    private static int CountDecimalPlaces(decimal value)
    {
        var bits = decimal.GetBits(value);
        var scale = (bits[3] >> 16) & 0x7F;
        return scale;
    }

    /// <summary>
    ///     Calculate GCD of an array of integers using the Euclidean Algorithm iteratively.
    /// </summary>
    /// <param name="numbers">Array of integers to find the GCD for. Must not be null or empty.</param>
    /// <returns>The greatest common divisor of all numbers in the array.</returns>
    /// <exception cref="ArgumentException">Thrown when the input array is null or empty.</exception>
    public static int FindGCD_Array(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Input array cannot be null or empty.", nameof(numbers));

        var result = 0;
        foreach (var number in numbers)
            result = FindGCD_EuclideanAlgorithm(result, number);

        return result;
    }

    /// <summary>
    ///     Calculate the sum of squares of the first n natural numbers using an iterative approach.
    /// </summary>
    /// <param name="n">A positive integer representing how many natural numbers to square and sum.</param>
    /// <returns>The sum of squares of the first n natural numbers.</returns>
    /// <exception cref="ArgumentException">Thrown when n is less than or equal to 0.</exception>
    public static long CalculateSumOfSquares(int n)
    {
        if (n <= 0)
            throw new ArgumentException("Input must be a positive integer.", nameof(n));

        long result = 0;
        for (var i = 1; i <= n; i++) 
            result += (long)i * i;

        return result;
    }

    /// <summary>
    ///     Calculate the sum of squares of the first n natural numbers using the mathematical formula.
    ///     Formula: n(n + 1)(2n + 1) / 6
    /// </summary>
    /// <param name="n">A positive integer representing how many natural numbers to square and sum.</param>
    /// <returns>The sum of squares of the first n natural numbers.</returns>
    /// <exception cref="ArgumentException">Thrown when n is less than or equal to 0.</exception>
    public static long CalculateSumOfSquaresOptimized(int n)
    {
        if (n <= 0)
            throw new ArgumentException("Input must be a positive integer.", nameof(n));

        return (long)n * (n + 1) * (2 * n + 1) / 6;
    }

}