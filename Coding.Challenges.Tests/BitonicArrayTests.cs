using System.Collections.Generic;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class BitonicArrayTests
{
    private static IEnumerable<TestCaseData> BitonicArrayTestCases()
    {
        yield return new TestCaseData(new[] { -2, 5, 10, 20, 15, 4, 1 }, 10, 2);
        yield return new TestCaseData(new[] { 5, 6, 7, 18, 29, 20, 13, 8, 1 }, 30, -1);
    }

    [Test]
    [TestCaseSource(nameof(BitonicArrayTestCases))]
    public void GetIdxInBitonicArray_ReturnsIndexOfGivenElement(int[] inputSequence, int inputElement, int expected)
    {
        Assert.That(BitonicArray.GetIdxInBitonicArray(inputSequence, inputElement), Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(BitonicArrayTestCases))]
    public void GetIdxInBitonicArray_Optimized_ReturnsIndexOfGivenElement(int[] inputSequence, int inputElement, int expected)
    {
        Assert.That(BitonicArray.GetIdxInBitonicArray_Optimized(inputSequence, inputElement), Is.EqualTo(expected));
    }
}
