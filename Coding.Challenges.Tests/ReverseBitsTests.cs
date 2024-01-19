using System.Collections.Generic;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ReverseBitsTests
{
    private static IEnumerable<TestCaseData> ReverseBitNumberTestCases()
    {
        yield return new TestCaseData(6, 3);
        yield return new TestCaseData(13, 11);
    }

    [Test]
    [TestCaseSource(nameof(ReverseBitNumberTestCases))]
    public void GetReverseBitNumber_ReturnsTheReversedNumber(int input, int expected)
    {
        Assert.That(ReverseBits.GetReverseBitNumber(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(ReverseBitNumberTestCases))]
    public void GetReverseBitNumberShiftingBits_ReturnsTheReversedNumber(int input, int expected)
    {
        Assert.That(ReverseBits.GetReverseBitNumberShiftingBits(input), Is.EqualTo(expected));
    }
}