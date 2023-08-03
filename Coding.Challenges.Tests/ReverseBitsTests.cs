namespace Coding.Challenges.Tests;

public class ReverseBitsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(6, 3)]
    [TestCase(13, 11)]
    public void GetReverseBitNumber_ReturnsTheReversedNumber(int inputNum, int resultNum)
    {
        Assert.That(ReverseBits.GetReverseBitNumber(inputNum), Is.EqualTo(resultNum));
    }
}