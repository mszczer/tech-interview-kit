using System;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestBinomialCoefficient
{
    [Test]
    [TestCase(5, 3, 10)]
    [TestCase(5, 2, 10)]
    [TestCase(10, 5, 252)]
    [TestCase(6, 0, 1)]
    [TestCase(6, 6, 1)]
    [TestCase(4, 2, 6)]
    [TestCase(10, 1, 10)]
    [TestCase(10, 9, 10)]
    [TestCase(20, 10, 184756)]
    public void CalculateNChooseR_ReturnsCorrectBinomialCoefficient(int n, int r, int expected)
    {
        Assert.That(BinomialCoefficient.CalculateNChooseR(n, r), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(5, 6, 0)]
    [TestCase(0, 1, 0)]
    public void CalculateNChooseR_ReturnsZeroWhenRGreaterThanN(int n, int r, int expected)
    {
        Assert.That(BinomialCoefficient.CalculateNChooseR(n, r), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(-1, 5)]
    [TestCase(5, -1)]
    [TestCase(-5, -3)]
    public void CalculateNChooseR_ThrowsOnNegativeInputs(int n, int r)
    {
        Assert.Throws<ArgumentException>(() => BinomialCoefficient.CalculateNChooseR(n, r));
    }
}
