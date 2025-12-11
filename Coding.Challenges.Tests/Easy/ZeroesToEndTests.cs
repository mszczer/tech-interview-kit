using System;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ZeroesToEndTests
{
    private static IEnumerable<TestCaseData> MoveZeroesToEndTestCases()
    {
        yield return new TestCaseData(new[] { 1, 8, 0, 2, 0, 1, 13, 0 }, new[] { 1, 8, 2, 1, 13, 0, 0, 0 });
        yield return new TestCaseData(new[] { 0, 0, 0, 23, 2 }, new[] { 23, 2, 0, 0, 0 });
        yield return new TestCaseData(Array.Empty<int>(), Array.Empty<int>()); // Empty array
        yield return new TestCaseData(new[] { 0, 0, 0 }, new[] { 0, 0, 0 }); // All zeroes
        yield return new TestCaseData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }); // No zeroes
        yield return new TestCaseData(new[] { 0 }, new[] { 0 }); // Single zero
        yield return new TestCaseData(new[] { 5 }, new[] { 5 }); // Single non-zero
        yield return new TestCaseData(new[] { 1, 2, 3, 0, 0 }, new[] { 1, 2, 3, 0, 0 }); // Already sorted
    }

    [Test]
    [TestCaseSource(nameof(MoveZeroesToEndTestCases))]
    public void MoveZeroesToEnd_ReturnsArrayWithZeroesAtEnd(int[] input, int[] expected)
    {
        Assert.That(ZeroesToEnd.MoveZeroesToEnd(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 1, 8, 0, 2, 0, 1, 13, 0 })]
    [TestCase(new[] { 0, 0, 0, 23, 2 })]
    [TestCase(new int[0])]
    [TestCase(new[] { 0, 0, 0 })]
    [TestCase(new[] { 1, 2, 3 })]
    [TestCase(new[] { 0 })]
    [TestCase(new[] { 5 })]
    [TestCase(new[] { 1, 2, 3, 0, 0 })]
    public void NoNonZeroElementAfterZeroes(int[] array)
    {
        var result = ZeroesToEnd.MoveZeroesToEnd(array);

        var nonZeroEncountered = false;

        foreach (var num in result)
            if (num == 0)
                nonZeroEncountered = true;
            else if (nonZeroEncountered) Assert.Fail("Non-zero element encountered after zero(s) in the array.");
    }

    [Test]
    public void MoveZeroesToEnd_ThrowsOnNullInput()
    {
        Assert.Throws<ArgumentNullException>(() => ZeroesToEnd.MoveZeroesToEnd(null));
    }
}