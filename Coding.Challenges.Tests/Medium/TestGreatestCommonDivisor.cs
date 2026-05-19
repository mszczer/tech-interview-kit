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
}