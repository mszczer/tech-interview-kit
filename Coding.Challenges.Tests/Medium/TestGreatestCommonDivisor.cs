using NUnit.Framework.Internal;

namespace Coding.Challenges.Tests.Medium;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestGreatestCommonDivisor
{
    private static readonly object[] GcdTestCases =
    [
        new object[] { 54, 24, 6 },
        new object[] { 48, 18, 6 },
        new object[] { 100, 50, 50 },
        new object[] { 17, 19, 1 },         // Co-prime numbers
        new object[] { 0, 5, 5 },           // Zero edge case
        new object[] { 5, 0, 5 },           // Zero edge case
        new object[] { 0, 0, 0 },           // Both zero
        new object[] { 1, 1, 1 },           // Smallest positive numbers
        new object[] { 13, 13, 13 },        // Same numbers
        new object[] { 1071, 462, 21 },     // Large numbers
        new object[] { 270, 192, 6 },       // Standard case
        new object[] { 1, 100, 1 },         // GCD with 1
        new object[] { 97, 89, 1 },         // Prime numbers
        new object[] { 36, 60, 12 },        // Multiple common factors
        new object[] { 144, 233, 1 },       // Consecutive Fibonacci numbers (always coprime)
        new object[] { 1024, 768, 256 },    // Powers of 2
        new object[] { 7, 14, 7 },          // One divides the other
        new object[] { 21, 49, 7 },         // Both multiples of 7
        new object[] { 2, 2, 2 },           // Small prime
        new object[] { 12345, 54321, 3 }    // Larger numbers
    ];

    [TestCaseSource(nameof(GcdTestCases))]
    public void FindGCD_BruteForce_ReturnsExpectedResult(int num1, int num2, int expectedResult)
    {
        var result = GreatestCommonDivisor.FindGCD_BruteForce(num1, num2);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(nameof(GcdTestCases))]
    public void FindGCD_EuclideanAlgorithm_ReturnsExpectedResult(int num1, int num2, int expectedResult)
    {
        var result = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num1, num2);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(nameof(GcdTestCases))]
    public void FindGCD_PrimeFactorization_ReturnsExpectedResult(int num1, int num2, int expectedResult)
    {
        var result = GreatestCommonDivisor.FindGCD_PrimeFactorization(num1, num2);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    private static readonly object[] MathematicalPropertyTestCases =
    [
        new object[] { 54, 24 },        // Common case with multiple factors
        new object[] { 100, 50 },       // One divides the other
        new object[] { 1071, 462 },     // Larger numbers
        new object[] { 17, 19 },        // Co-prime numbers
        new object[] { 270, 192 },      // Standard case
        new object[] { 1024, 768 },     // Powers of 2
        new object[] { 12345, 54321 }   // Large numbers
    ];

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void EuclideanAlgorithm_ProducesSameResultAs_BruteForce(int num1, int num2)
    {
        var bruteForceResult = GreatestCommonDivisor.FindGCD_BruteForce(num1, num2);
        var euclideanResult = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num1, num2);

        Assert.That(euclideanResult, Is.EqualTo(bruteForceResult));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void PrimeFactorization_ProducesSameResultAs_BruteForce(int num1, int num2)
    {
        var bruteForceResult = GreatestCommonDivisor.FindGCD_BruteForce(num1, num2);
        var primeFactorizationResult = GreatestCommonDivisor.FindGCD_PrimeFactorization(num1, num2);

        Assert.That(primeFactorizationResult, Is.EqualTo(bruteForceResult));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void BruteForce_IsCommutative(int num1, int num2)
    {
        var result1 = GreatestCommonDivisor.FindGCD_BruteForce(num1, num2);
        var result2 = GreatestCommonDivisor.FindGCD_BruteForce(num2, num1);

        Assert.That(result2, Is.EqualTo(result1));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void EuclideanAlgorithm_IsCommutative(int num1, int num2)
    {
        var result1 = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num1, num2);
        var result2 = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num2, num1);

        Assert.That(result2, Is.EqualTo(result1));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void PrimeFactorization_IsCommutative(int num1, int num2)
    {
        var result1 = GreatestCommonDivisor.FindGCD_PrimeFactorization(num1, num2);
        var result2 = GreatestCommonDivisor.FindGCD_PrimeFactorization(num2, num1);

        Assert.That(result2, Is.EqualTo(result1));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void BruteForce_ResultDividesNum1(int num1, int num2)
    {
        if (num1 == 0) return;

        var gcd = GreatestCommonDivisor.FindGCD_BruteForce(num1, num2);

        Assert.That(num1 % gcd, Is.Zero);
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void BruteForce_ResultDividesNum2(int num1, int num2)
    {
        if (num2 == 0) return;

        var gcd = GreatestCommonDivisor.FindGCD_BruteForce(num1, num2);

        Assert.That(num2 % gcd, Is.Zero);
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void EuclideanAlgorithm_ResultDividesNum1(int num1, int num2)
    {
        if (num1 == 0) return;

        var gcd = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num1, num2);

        Assert.That(num1 % gcd, Is.Zero);
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void EuclideanAlgorithm_ResultDividesNum2(int num1, int num2)
    {
        if (num2 == 0) return;

        var gcd = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num1, num2);

        Assert.That(num2 % gcd, Is.Zero);
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void PrimeFactorization_ResultDividesNum1(int num1, int num2)
    {
        if (num1 == 0) return;

        var gcd = GreatestCommonDivisor.FindGCD_PrimeFactorization(num1, num2);

        Assert.That(num1 % gcd, Is.Zero);
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void PrimeFactorization_ResultDividesNum2(int num1, int num2)
    {
        if (num2 == 0) return;

        var gcd = GreatestCommonDivisor.FindGCD_PrimeFactorization(num1, num2);

        Assert.That(num2 % gcd, Is.Zero);
    }

    [Test]
    public void EuclideanAlgorithm_ProducesCorrectResult_ForLargeNumbers()
    {
        const int num1 = 987654321;
        const int num2 = 123456789;

        var euclideanResult = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num1, num2);
        var bruteForceResult = GreatestCommonDivisor.FindGCD_BruteForce(num1, num2);

        Assert.That(euclideanResult, Is.EqualTo(bruteForceResult));
    }

    private static readonly object[] LcmTestCases =
    [
        new object[] { 12, 18, 36 },        // Basic case: 12 = 2^2 * 3, 18 = 2 * 3^2, LCM = 2^2 * 3^2 = 36
        new object[] { 4, 6, 12 },          // Simple case
        new object[] { 21, 6, 42 },         // 21 = 3 * 7, 6 = 2 * 3, LCM = 2 * 3 * 7 = 42
        new object[] { 15, 20, 60 },        // 15 = 3 * 5, 20 = 2^2 * 5, LCM = 2^2 * 3 * 5 = 60
        new object[] { 7, 13, 91 },         // Co-prime numbers: LCM = product
        new object[] { 1, 5, 5 },           // LCM with 1
        new object[] { 5, 1, 5 },           // LCM with 1 (commutative)
        new object[] { 0, 5, 0 },           // Zero case
        new object[] { 5, 0, 0 },           // Zero case (commutative)
        new object[] { 0, 0, 0 },           // Both zero
        new object[] { 10, 10, 10 },        // Same numbers
        new object[] { 8, 12, 24 },         // 8 = 2^3, 12 = 2^2 * 3, LCM = 2^3 * 3 = 24
        new object[] { 14, 21, 42 },        // 14 = 2 * 7, 21 = 3 * 7, LCM = 2 * 3 * 7 = 42
        new object[] { 48, 18, 144 },       // 48 = 2^4 * 3, 18 = 2 * 3^2, LCM = 2^4 * 3^2 = 144
        new object[] { 54, 24, 216 },       // Larger result
        new object[] { 100, 50, 100 },      // One divides the other
        new object[] { 7, 14, 14 },         // One divides the other
        new object[] { 17, 19, 323 },       // Prime numbers: LCM = product
        new object[] { 2, 2, 2 },           // Same prime
        new object[] { 3, 5, 15 },          // Small co-primes
        new object[] { 25, 35, 175 }        // 25 = 5^2, 35 = 5 * 7, LCM = 5^2 * 7 = 175
    ];

    [TestCaseSource(nameof(LcmTestCases))]
    public void GetLCM_UsingGCD_ReturnsExpectedResult(int num1, int num2, int expectedResult)
    {
        var result = GreatestCommonDivisor.GetLCM_UsingGCD(num1, num2);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(nameof(LcmTestCases))]
    public void GetLCM_PrimeFactorization_ReturnsExpectedResult(int num1, int num2, int expectedResult)
    {
        var result = GreatestCommonDivisor.GetLCM_PrimeFactorization(num1, num2);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void GetLCM_UsingGCD_ProducesSameResultAs_PrimeFactorization(int num1, int num2)
    {
        var lcmUsingGcd = GreatestCommonDivisor.GetLCM_UsingGCD(num1, num2);
        var lcmUsingPrimeFactorization = GreatestCommonDivisor.GetLCM_PrimeFactorization(num1, num2);

        Assert.That(lcmUsingGcd, Is.EqualTo(lcmUsingPrimeFactorization));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void GetLCM_IsCommutative(int num1, int num2)
    {
        var lcm1 = GreatestCommonDivisor.GetLCM_UsingGCD(num1, num2);
        var lcm2 = GreatestCommonDivisor.GetLCM_UsingGCD(num2, num1);

        Assert.That(lcm1, Is.EqualTo(lcm2));
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void GetLCM_IsDivisibleByNum1(int num1, int num2)
    {
        if (num1 == 0 || num2 == 0) return;

        var lcm = GreatestCommonDivisor.GetLCM_UsingGCD(num1, num2);

        Assert.That(lcm % num1, Is.Zero, $"LCM {lcm} should be divisible by {num1}");
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void GetLCM_IsDivisibleByNum2(int num1, int num2)
    {
        if (num1 == 0 || num2 == 0) return;

        var lcm = GreatestCommonDivisor.GetLCM_UsingGCD(num1, num2);

        Assert.That(lcm % num2, Is.Zero, $"LCM {lcm} should be divisible by {num2}");
    }

    [TestCaseSource(nameof(MathematicalPropertyTestCases))]
    public void GCD_And_LCM_Satisfy_MathematicalProperty(int num1, int num2)
    {
        if (num1 == 0 || num2 == 0) return;

        // Mathematical property: GCD(a,b) * LCM(a,b) = a * b
        var gcd = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(num1, num2);
        var lcm = GreatestCommonDivisor.GetLCM_UsingGCD(num1, num2);

        Assert.That((long)gcd * lcm, Is.EqualTo((long)num1 * num2));
    }

    [Test]
    public void CalculateGCDUsingFloat_ReturnsExpectedResult()
    {
        const decimal num1 = 1.2m;
        const decimal num2 = 22.5m;
        const decimal expectedResult = 0.3m;

        var result = GreatestCommonDivisor.CalculateGCDUsingFloat(num1, num2);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    private static readonly object[] FloatGcdTestCases =
    [
        new object[] { 1.2m, 22.5m, 0.3m },           // Original test case
        new object[] { 0.5m, 1.5m, 0.5m },            // Simple decimals
        new object[] { 2.4m, 3.6m, 1.2m },            // Common divisor
        new object[] { 0.25m, 0.75m, 0.25m },         // Quarter divisions
        new object[] { 0.6m, 0.9m, 0.3m },            // Tenths
        new object[] { 1.5m, 2.5m, 0.5m },            // Different denominators
        new object[] { 0.12m, 0.18m, 0.06m },         // Hundredths
        new object[] { 0.0m, 5.5m, 5.5m },            // Zero case
        new object[] { 5.5m, 0.0m, 5.5m },            // Zero case (commutative)
        new object[] { 3.5m, 3.5m, 3.5m },            // Same numbers
        new object[] { 0.001m, 0.003m, 0.001m },      // Very small numbers
        new object[] { 10.5m, 7.5m, 1.5m },           // Larger decimals
        new object[] { 0.125m, 0.375m, 0.125m },      // Eighths
        new object[] { 2.0m, 3.0m, 1.0m },            // Whole numbers as decimals
        new object[] { 0.333m, 0.666m, 0.333m },      // Three decimal places
        new object[] { 1.44m, 2.4m, 0.48m },          // Multiple decimal places result
        new object[] { 0.7m, 1.4m, 0.7m },            // One divides the other
        new object[] { 0.15m, 0.25m, 0.05m },         // Small common divisor
    ];

    [TestCaseSource(nameof(FloatGcdTestCases))]
    public void CalculateGCDUsingFloat_VariousCases_ReturnsExpectedResult(decimal num1, decimal num2, decimal expected)
    {
        var result = GreatestCommonDivisor.CalculateGCDUsingFloat(num1, num2);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(FloatGcdTestCases))]
    public void CalculateGCDUsingFloat_IsCommutative(decimal num1, decimal num2, decimal expected)
    {
        var result1 = GreatestCommonDivisor.CalculateGCDUsingFloat(num1, num2);
        var result2 = GreatestCommonDivisor.CalculateGCDUsingFloat(num2, num1);

        Assert.That(result2, Is.EqualTo(result1));
    }

    [TestCaseSource(nameof(FloatGcdTestCases))]
    public void CalculateGCDUsingFloat_ResultDividesNum1(decimal num1, decimal num2, decimal expected)
    {
        if (num1 == 0) return;

        var gcd = GreatestCommonDivisor.CalculateGCDUsingFloat(num1, num2);
        var quotient = num1 / gcd;
        var remainder = quotient - Math.Floor(quotient);

        Assert.That(remainder, Is.LessThan(0.0000001m),
            $"GCD {gcd} should divide {num1} evenly, but got remainder {remainder}");
    }

    [TestCaseSource(nameof(FloatGcdTestCases))]
    public void CalculateGCDUsingFloat_ResultDividesNum2(decimal num1, decimal num2, decimal expected)
    {
        if (num2 == 0) return;

        var gcd = GreatestCommonDivisor.CalculateGCDUsingFloat(num1, num2);
        var quotient = num2 / gcd;
        var remainder = quotient - Math.Floor(quotient);

        Assert.That(remainder, Is.LessThan(0.0000001m),
            $"GCD {gcd} should divide {num2} evenly, but got remainder {remainder}");
    }

    [Test]
    public void CalculateGCDUsingFloat_WithNegativeNum1_ReturnsPositiveResult()
    {
        var result = GreatestCommonDivisor.CalculateGCDUsingFloat(-1.2m, 2.4m);
        var expected = GreatestCommonDivisor.CalculateGCDUsingFloat(1.2m, 2.4m);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CalculateGCDUsingFloat_WithNegativeNum2_ReturnsPositiveResult()
    {
        var result = GreatestCommonDivisor.CalculateGCDUsingFloat(1.2m, -2.4m);
        var expected = GreatestCommonDivisor.CalculateGCDUsingFloat(1.2m, 2.4m);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CalculateGCDUsingFloat_WithBothNegative_ReturnsPositiveResult()
    {
        var result = GreatestCommonDivisor.CalculateGCDUsingFloat(-1.2m, -2.4m);
        var expected = GreatestCommonDivisor.CalculateGCDUsingFloat(1.2m, 2.4m);

        Assert.That(result, Is.EqualTo(expected));
    }

    private static readonly object[] ArrayGcdTestCases =
    [
        new object[] { new[] { 24, 36, 60 }, 12 },              // Example from requirement
        new object[] { new[] { 12, 18, 24 }, 6 },               // Multiple common factors
        new object[] { new[] { 8, 12, 16, 20 }, 4 },            // Four numbers
        new object[] { new[] { 100, 50, 25 }, 25 },             // Divisible by smallest
        new object[] { new[] { 7, 14, 21, 28 }, 7 },            // All multiples of 7
        new object[] { new[] { 17, 34, 51 }, 17 },              // Prime factor
        new object[] { new[] { 13, 26, 39, 52, 65 }, 13 },      // Five numbers with prime GCD
        new object[] { new[] { 10, 15, 20, 25, 30 }, 5 },       // Multiple numbers
        new object[] { new[] { 2, 4, 8, 16, 32 }, 2 },          // Powers of 2
        new object[] { new[] { 9, 27, 81 }, 9 },                // Powers of 3
        new object[] { new[] { 1, 2, 3, 4, 5 }, 1 },            // Co-prime numbers
        new object[] { new[] { 0, 5, 10 }, 5 },                 // Array with zero
        new object[] { new[] { 0, 0, 0 }, 0 },                  // All zeros
        new object[] { new[] { 42 }, 42 },                      // Single element
        new object[] { new[] { 100, 200 }, 100 },               // Two numbers
        new object[] { new[] { 12, 18, 24, 30, 36 }, 6 },       // Consistent GCD
        new object[] { new[] { 1024, 512, 256 }, 256 },         // Large powers of 2
        new object[] { new[] { 15, 25, 35, 45 }, 5 },           // Multiples of 5
        new object[] { new[] { 6, 9, 12, 15, 18 }, 3 },         // Multiples of 3
        new object[] { new[] { 144, 96, 48 }, 48 },             // Larger numbers
        new object[] { new[] { 120, 180, 240, 300, 360, 420, 480 }, 60 }, // Large array
        new object[] { new[] { 1000000, 500000, 250000 }, 250000 },       // Mixed sizes
        new object[] { new[] { 60, 24, 36 }, 12 },              // Order test - permutation 1
        new object[] { new[] { 36, 60, 24 }, 12 }               // Order test - permutation 2
    ];

    [TestCaseSource(nameof(ArrayGcdTestCases))]
    public void FindGCD_Array_ReturnsExpectedResult(int[] numbers, int expectedResult)
    {
        var result = GreatestCommonDivisor.FindGCD_Array(numbers);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void FindGCD_Array_WithNullArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.FindGCD_Array(null));
    }

    [Test]
    public void FindGCD_Array_WithEmptyArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.FindGCD_Array([]));
    }

    [Test]
    public void FindGCD_Array_WithTwoElements_ProducesSameResultAs_TwoNumberGCD()
    {
        var numbers = new[] { 24, 36 };
        var arrayResult = GreatestCommonDivisor.FindGCD_Array(numbers);
        var twoNumberResult = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(24, 36);

        Assert.That(arrayResult, Is.EqualTo(twoNumberResult));
    }

    [Test]
    public void FindGCD_Array_IsAssociative()
    {
        // GCD(GCD(a, b), c) = GCD(a, GCD(b, c))
        var numbers = new[] { 24, 36, 60 };

        var result1 = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(
            GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(numbers[0], numbers[1]),
            numbers[2]
        );

        var result2 = GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(
            numbers[0],
            GreatestCommonDivisor.FindGCD_EuclideanAlgorithm(numbers[1], numbers[2])
        );

        Assert.That(result1, Is.EqualTo(result2));
    }

    private static readonly object[] ArrayElementDivisibilityTestCases =
    [
        new object[] { new[] { 24, 36, 60 }, 24 },
        new object[] { new[] { 24, 36, 60 }, 36 },
        new object[] { new[] { 24, 36, 60 }, 60 },
        new object[] { new[] { 12, 18, 24 }, 12 },
        new object[] { new[] { 12, 18, 24 }, 18 },
        new object[] { new[] { 12, 18, 24 }, 24 },
        new object[] { new[] { 8, 12, 16, 20 }, 8 },
        new object[] { new[] { 8, 12, 16, 20 }, 12 },
        new object[] { new[] { 8, 12, 16, 20 }, 16 },
        new object[] { new[] { 8, 12, 16, 20 }, 20 }
    ];

    [TestCaseSource(nameof(ArrayElementDivisibilityTestCases))]
    public void FindGCD_Array_ResultDividesElement(int[] numbers, int element)
    {
        var gcd = GreatestCommonDivisor.FindGCD_Array(numbers);
        Assert.That(element % gcd, Is.Zero, $"GCD {gcd} should divide {element}");
    }

    private static readonly object[] SumOfSquaresTestCases =
    [
        new object[] { 1, 1L },                     // 1² = 1
        new object[] { 2, 5L },                     // 1² + 2² = 1 + 4 = 5
        new object[] { 3, 14L },                    // 1² + 2² + 3² = 1 + 4 + 9 = 14
        new object[] { 4, 30L },                    // 1² + 2² + 3² + 4² = 1 + 4 + 9 + 16 = 30
        new object[] { 5, 55L },                    // Sum = 55
        new object[] { 10, 385L },                  // Sum = 385
        new object[] { 20, 2870L },                 // Sum = 2870
        new object[] { 50, 42925L },                // Sum = 42925
        new object[] { 100, 338350L },              // Sum = 338350
        new object[] { 1000, 333833500L },          // Large number
        new object[] { 5000, 41679167500L }         // Very large number
    ];

    [TestCaseSource(nameof(SumOfSquaresTestCases))]
    public void CalculateSumOfSquares_ReturnsExpectedResult(int n, long expected)
    {
        var result = GreatestCommonDivisor.CalculateSumOfSquares(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(SumOfSquaresTestCases))]
    public void CalculateSumOfSquaresOptimized_ReturnsExpectedResult(int n, long expected)
    {
        var result = GreatestCommonDivisor.CalculateSumOfSquaresOptimized(n);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(SumOfSquaresTestCases))]
    public void CalculateSumOfSquares_BothMethodsProduceSameResult(int n, long expected)
    {
        var iterativeResult = GreatestCommonDivisor.CalculateSumOfSquares(n);
        var optimizedResult = GreatestCommonDivisor.CalculateSumOfSquaresOptimized(n);

        Assert.That(iterativeResult, Is.EqualTo(optimizedResult),
            $"Both methods should produce the same result for n={n}");
    }

    [Test]
    public void CalculateSumOfSquares_WithZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.CalculateSumOfSquares(0));
    }

    [Test]
    public void CalculateSumOfSquares_WithNegativeNumber_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.CalculateSumOfSquares(-5));
    }

    [Test]
    public void CalculateSumOfSquaresOptimized_WithZero_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.CalculateSumOfSquaresOptimized(0));
    }

    [Test]
    public void CalculateSumOfSquaresOptimized_WithNegativeNumber_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => GreatestCommonDivisor.CalculateSumOfSquaresOptimized(-5));
    }
}
