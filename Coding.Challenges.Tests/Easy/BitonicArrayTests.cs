using System;
namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class BitonicArrayTests
{
    private static IEnumerable<TestCaseData> BitonicArrayTestCases()
    {
        yield return new TestCaseData(new[] { -2, 5, 10, 20, 15, 4, 1 }, 10, 2);
        yield return new TestCaseData(new[] { 5, 6, 7, 18, 29, 20, 13, 8, 1 }, 30, -1);
        // Element in ascending part
        // Element not present
        // Element at peak
        yield return new TestCaseData(new[] { 1, 3, 8, 12, 4, 2 }, 12, 3);
        // Element at start
        yield return new TestCaseData(new[] { 1, 3, 8, 12, 4, 2 }, 1, 0);
        // Element at end
        yield return new TestCaseData(new[] { 1, 3, 8, 12, 4, 2 }, 2, 5);
        // Element in descending part
        yield return new TestCaseData(new[] { 1, 3, 8, 12, 4, 2 }, 4, 4);
        // Single element array
        yield return new TestCaseData(new[] { 7 }, 7, 0);
        yield return new TestCaseData(new[] { 7 }, 1, -1);
        // Two element array
        yield return new TestCaseData(new[] { 1, 0 }, 0, 1);
        yield return new TestCaseData(new[] { 1, 0 }, 1, 0);
        // Empty array
        yield return new TestCaseData(Array.Empty<int>(), 5, -1);
        // Negative numbers
        yield return new TestCaseData(new[] { -10, -5, 0, 5, 3, -1 }, -1, 5);
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
