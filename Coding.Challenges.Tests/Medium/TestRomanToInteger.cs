using Coding.Challenges.Medium;

namespace Coding.Challenges.Tests.Medium;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestRomanToInteger
{
    [TestCase("VII", 7, TestName = "ConvertRomanToInt_VII_Returns7")]
    [TestCase("IV", 4, TestName = "ConvertRomanToInt_IV_Returns4")]
    [TestCase("XC", 90, TestName = "ConvertRomanToInt_XC_Returns90")]
    [TestCase("XVII", 17, TestName = "ConvertRomanToInt_XVII_Returns17")]
    public void ConvertRomanToInt_Examples_ReturnExpected(string roman, int expected)
    {
        var actual = RomanToInteger.ConvertRomanToInt(roman);
        Assert.That(actual, Is.EqualTo(expected));
    }
}