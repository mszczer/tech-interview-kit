using Coding.Challenges.Medium;

namespace Coding.Challenges.Tests.Medium;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestSquareRootOfInteger
{
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(4, 2)]
    [TestCase(11, 3)]
    public void LinearSearchSquareRoot_ReturnsExpectedResult(int input, int expectedResult)
    {
        var result = SquareRootOfInteger.LinearSearchSquareRoot(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(4, 2)]
    [TestCase(11, 3)]
    [TestCase(2147395600, 46340)]
    [TestCase(2147483647, 46340)]
    public void BinarySearchSquareRoot_ReturnsExpectedResult(int input, int expectedResult)
    {
        var result = SquareRootOfInteger.BinarySearchSquareRoot(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(2, new[] { 2 })]
    [TestCase(12, new[] { 2, 2, 3 })]
    [TestCase(17, new[] { 17 })]
    [TestCase(60, new[] { 2, 2, 3, 5 })]
    [TestCase(100, new[] { 2, 2, 5, 5 })]
    public void GetPrimeFactors_ReturnsExpectedResult(int input, int[] expectedFactors)
    {
        var result = SquareRootOfInteger.GetPrimeFactors(input);
        Assert.That(result, Is.EqualTo(expectedFactors));
    }
}