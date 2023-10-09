using Coding.Challenges.Easy;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]

public class BitonicArrayTests
{
    [Test]
    [TestCase(new[] { -2, 5, 10, 20, 15, 4, 1 },10, 2)]
    [TestCase(new[] { 5, 6, 7, 18, 29, 20, 13, 8, 1 },30, -1)]
    public void GetIdxInBitonicArray_ReturnsIndexOfGivenElement(int[] inputSequence,int inputElement, int expected)
    {
        Assert.That(BitonicArray.GetIdxInBitonicArray(inputSequence, inputElement), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { -2, 5, 10, 20, 15, 4, 1 }, 10, 2)]
    [TestCase(new[] { 5, 6, 7, 18, 29, 20, 13, 8, 1 }, 30, -1)]
    public void GetIdxInBitonicArray_Optimized_ReturnsIndexOfGivenElement(int[] inputSequence, int inputElement, int expected)
    {
        Assert.That(BitonicArray.GetIdxInBitonicArray_Optimized(inputSequence, inputElement), Is.EqualTo(expected));
    }
}