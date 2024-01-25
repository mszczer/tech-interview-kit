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

    [Test]
    [TestCase(new[] { 1, 8, 0, 2, 0, 1, 13, 0 })]
    [TestCase(new[] { 0, 0, 0, 23, 2 })]
    public void NoNonZeroElementAfterZeroes(int[] array)
    {
        var result = ZeroesToEnd.MoveZeroesToEnd(array);

        var nonZeroEncountered = false;

        foreach (var num in result)
            if (num == 0)
                nonZeroEncountered = true;
            else if (nonZeroEncountered) Assert.Fail("Non-zero element encountered after zero(s) in the array.");
    }
}