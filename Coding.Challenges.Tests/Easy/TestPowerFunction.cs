using System;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestPowerFunction
{
    private static IEnumerable<TestCaseData> PowerFunctionTestCases()
    {
        yield return new TestCaseData(4.0, 2, 16.0);
        yield return new TestCaseData(2.0, -3, 0.125);
        yield return new TestCaseData(-7.0, 3, -343.0);
        yield return new TestCaseData(4.0, 0, 1.0);
        yield return new TestCaseData(-2.0, 4, 16.0);
        yield return new TestCaseData(-2.0, 5, -32.0);
        yield return new TestCaseData(0.5, 2, 0.25);
    }

    [Test]
    [TestCaseSource(nameof(PowerFunctionTestCases))]
    public void ComputePowerIteratively_ReturnsThePower(double baseNumber, int exponent, double expected)
    {
        Assert.That(Challenges.PowerFunction.ComputePowerIteratively(baseNumber, exponent), Is.EqualTo(expected).Within(1e-9));
    }

    [Test]
    [TestCaseSource(nameof(PowerFunctionTestCases))]
    public void ComputePowerDivideAndConquerOptimized_ReturnsThePower(double baseNumber, int exponent, double expected)
    {
        Assert.That(Challenges.PowerFunction.ComputePowerDivideAndConquerOptimized(baseNumber, exponent), Is.EqualTo(expected).Within(1e-9));
    }

    [Test]
    [TestCase(0.0, 0)]
    public void ComputePowerIteratively_ThrowsOnZeroToZero(double baseNumber, int exponent)
    {
        Assert.Throws<ArgumentException>(() => Challenges.PowerFunction.ComputePowerIteratively(baseNumber, exponent));
    }

    [Test]
    [TestCase(0.0, 0)]
    public void ComputePowerDivideAndConquerOptimized_ThrowsOnZeroToZero(double baseNumber, int exponent)
    {
        Assert.Throws<ArgumentException>(() => Challenges.PowerFunction.ComputePowerDivideAndConquerOptimized(baseNumber, exponent));
    }
}