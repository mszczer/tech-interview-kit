namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class PowerFunctionTests
{
    private static IEnumerable<TestCaseData> PowerFunctionTestCases()
    {
        yield return new TestCaseData(4, 2, 16.00);
        yield return new TestCaseData(2, -3, 0.125);
        yield return new TestCaseData(-7, 3, -343.00);
        yield return new TestCaseData(4, 0, 1.00);
    }

    [Test]
    [TestCaseSource(nameof(PowerFunctionTestCases))]
    public void ComputePowerIteratively_ReturnsThePower(int baseNumber, int exponent, double expected)
    {
        Assert.That(PowerFunction.ComputePowerIteratively(baseNumber, exponent), Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(PowerFunctionTestCases))]
    public void ComputePowerDivideAndConquer_ReturnsThePower(int baseNumber, int exponent, double expected)
    {
        Assert.That(PowerFunction.ComputePowerDivideAndConquer(baseNumber, exponent), Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(PowerFunctionTestCases))]
    public void ComputePowerDivideAndConquerOptimized_ReturnsThePower(int baseNumber, int exponent, double expected)
    {
        Assert.That(PowerFunction.ComputePowerDivideAndConquerOptimized(baseNumber, exponent), Is.EqualTo(expected));
    }
}