namespace Coding.Challenges.Tests;

[TestFixture]
public class PowerFunctionTests
{
    [Test]
    [TestCase(4, 2, 16.00)]
    [TestCase(2, -3, 0.125)]
    [TestCase(-7, 3, -343.00)]
    [TestCase(4, 0, 1.00)]
    public void ComputePower_ReturnsThePower(int baseNumber, int exponent, double expected)
    {
        Assert.That(PowerFunction.ComputePowerIteratively(baseNumber, exponent), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(4, 2, 16.00)]
    [TestCase(2, -3, 0.125)]
    [TestCase(-7, 3, -343.00)]
    [TestCase(4, 0, 1.00)]
    public void ComputePowerDivideAndConquer_ReturnsThePower(int baseNumber, int exponent, double expected)
    {
        Assert.That(PowerFunction.ComputePowerDivideAndConquer(baseNumber, exponent), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(4, 2, 16.00)]
    [TestCase(2, -3, 0.125)]
    [TestCase(-7, 3, -343.00)]
    [TestCase(4, 0, 1.00)]
    public void ComputePowerDivideAndConquerOptimized_ReturnsThePower(int baseNumber, int exponent, double expected)
    {
        Assert.That(PowerFunction.ComputePowerDivideAndConquerOptimized(baseNumber, exponent), Is.EqualTo(expected));
    }
}