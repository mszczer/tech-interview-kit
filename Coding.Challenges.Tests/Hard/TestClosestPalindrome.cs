using Coding.Challenges.Hard;

namespace Coding.Challenges.Tests.Hard;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestClosestPalindrome
{
    [Test]
    [TestCase("88", "77")]
    [TestCase("1", "0")]
    [TestCase("9", "8")]
    [TestCase("10", "9")]
    [TestCase("11", "9")]
    [TestCase("121", "111")]
    [TestCase("123", "121")]
    [TestCase("1000", "999")]
    [TestCase("999", "1001")]
    [TestCase("1283", "1331")]
    [TestCase("100000", "99999")]
    public void FindClosestPalindrome_ReturnsExpectedResult(string number, string expectedResult)
    {
        var result = ClosestPalindrome.FindClosestPalindrome(number);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}