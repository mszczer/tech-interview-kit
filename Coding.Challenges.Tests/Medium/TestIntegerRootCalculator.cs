using Coding.Challenges.Medium;

namespace Coding.Challenges.Tests.Medium;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestIntegerRootCalculator
{
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(4, 2)]
    [TestCase(11, 3)]
    public void LinearSearchSquareRoot_ReturnsExpectedResult(int input, int expectedResult)
    {
        var result = IntegerRootCalculator.LinearSearchSquareRoot(input);
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
        var result = IntegerRootCalculator.BinarySearchSquareRoot(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(2, new[] { 2 })]
    [TestCase(12, new[] { 2, 2, 3 })]
    [TestCase(17, new[] { 17 })]
    [TestCase(60, new[] { 2, 2, 3, 5 })]
    [TestCase(100, new[] { 2, 2, 5, 5 })]
    public void GetPrimeFactors_ReturnsExpectedResult(int input, int[] expectedFactors)
    {
        var result = IntegerRootCalculator.GetPrimeFactors(input);
        Assert.That(result, Is.EqualTo(expectedFactors));
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(8, 2)]
    [TestCase(11, 2)]
    [TestCase(2147395600, 1290)]
    public void LinearSearchCubeRoot_ReturnsExpectedResult(int input, int expectedResult)
    {
        var result = IntegerRootCalculator.LinearSearchCubeRoot(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(8, 2)]
    [TestCase(11, 2)]
    [TestCase(2147395600, 1290)]
    public void BinarySearchCubeRoot_ReturnsExpectedResult(int input, int expectedResult)
    {
        var result = IntegerRootCalculator.BinarySearchCubeRoot(input);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}