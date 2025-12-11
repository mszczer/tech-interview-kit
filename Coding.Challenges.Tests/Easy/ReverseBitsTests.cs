namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ReverseBitsTests
{
    private static IEnumerable<TestCaseData> ReverseBitNumberTestCases()
    {
        yield return new TestCaseData(0, 0);
        yield return new TestCaseData(1, 1);
        yield return new TestCaseData(6, 3);
        yield return new TestCaseData(13, 11);
        yield return new TestCaseData(8, 1);
        yield return new TestCaseData(255, 255);
        yield return new TestCaseData(16, 1);
        yield return new TestCaseData(1023, 1023);
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