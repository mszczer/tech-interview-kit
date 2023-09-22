namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ReverseBitsTests
{
    [Test]
    [TestCase(6, 3)]
    [TestCase(13, 11)]
    public void GetReverseBitNumber_ReturnsTheReversedNumber(int input, int expected)
    {
        Assert.That(ReverseBits.GetReverseBitNumber(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(6, 3)]
    [TestCase(13, 11)]
    public void GetReverseBitNumberShiftingBits_ReturnsTheReversedNumber(int input, int expected)
    {
        Assert.That(ReverseBits.GetReverseBitNumberShiftingBits(input), Is.EqualTo(expected));
    }
}