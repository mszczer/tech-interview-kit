using System.Collections.Generic;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ZeroesToEndTests
{
    private static IEnumerable<TestCaseData> MoveZeroesToEndTestCases()
    {
        yield return new TestCaseData(new[] { 1, 8, 0, 2, 0, 1, 13, 0 }, new[] { 1, 8, 2, 1, 13, 0, 0, 0 });
        yield return new TestCaseData(new[] { 0, 0, 0, 23, 2 }, new[] { 23, 2, 0, 0, 0 });
    }

    [Test]
    [TestCaseSource(nameof(MoveZeroesToEndTestCases))]
    public void MoveZeroesToEnd_ReturnsArrayWithZeroesAtEnd(int[] input, int[] expected)
    {
        Assert.That(ZeroesToEnd.MoveZeroesToEnd(input), Is.EqualTo(expected));
    }
}