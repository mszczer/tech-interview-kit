namespace Coding.Challenges.Tests;

public class ReverseBitsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReverseBits_ReturnTheNumber()
    {
        Assert.That(ReverseBits.GetReverseBit(13), Is.EqualTo(11));
    }
}