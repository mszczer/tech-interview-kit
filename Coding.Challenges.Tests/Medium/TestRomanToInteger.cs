using System;
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

    [TestCase(null, TestName = "ConvertRomanToInt_Null_ThrowsArgumentException")]
    [TestCase("", TestName = "ConvertRomanToInt_EmptyString_ThrowsArgumentException")]
    [TestCase("   ", TestName = "ConvertRomanToInt_Whitespace_ThrowsArgumentException")]
    public void ConvertRomanToInt_NullOrWhitespace_ThrowsArgumentException(string roman)
    {
        Assert.Throws<ArgumentException>(() => RomanToInteger.ConvertRomanToInt(roman));
    }

    [TestCase("ABC", TestName = "ConvertRomanToInt_InvalidCharacters_ThrowsArgumentException")]
    [TestCase("IXZ", TestName = "ConvertRomanToInt_InvalidCharZ_ThrowsArgumentException")]
    [TestCase("X1V", TestName = "ConvertRomanToInt_NumberInString_ThrowsArgumentException")]
    [TestCase("X@V", TestName = "ConvertRomanToInt_SpecialCharacter_ThrowsArgumentException")]
    public void ConvertRomanToInt_InvalidCharacters_ThrowsArgumentException(string roman)
    {
        Assert.Throws<ArgumentException>(() => RomanToInteger.ConvertRomanToInt(roman));
    }

    [TestCase(1, "I", TestName = "ConvertIntToRoman_1_ReturnsI")]
    [TestCase(3999, "MMMCMXCIX", TestName = "ConvertIntToRoman_3999_ReturnsMMMCMXCIX")]
    [TestCase(4, "IV", TestName = "ConvertIntToRoman_4_ReturnsIV")]
    [TestCase(5, "V", TestName = "ConvertIntToRoman_5_ReturnsV")]
    [TestCase(9, "IX", TestName = "ConvertIntToRoman_9_ReturnsIX")]
    [TestCase(10, "X", TestName = "ConvertIntToRoman_10_ReturnsX")]
    [TestCase(40, "XL", TestName = "ConvertIntToRoman_40_ReturnsXL")]
    [TestCase(50, "L", TestName = "ConvertIntToRoman_50_ReturnsL")]
    [TestCase(90, "XC", TestName = "ConvertIntToRoman_90_ReturnsXC")]
    [TestCase(100, "C", TestName = "ConvertIntToRoman_100_ReturnsC")]
    [TestCase(400, "CD", TestName = "ConvertIntToRoman_400_ReturnsCD")]
    [TestCase(500, "D", TestName = "ConvertIntToRoman_500_ReturnsD")]
    [TestCase(900, "CM", TestName = "ConvertIntToRoman_900_ReturnsCM")]
    [TestCase(1000, "M", TestName = "ConvertIntToRoman_1000_ReturnsM")]
    [TestCase(58, "LVIII", TestName = "ConvertIntToRoman_58_ReturnsLVIII")]
    [TestCase(1994, "MCMXCIV", TestName = "ConvertIntToRoman_1994_ReturnsMCMXCIV")]
    [TestCase(1984, "MCMLXXXIV", TestName = "ConvertIntToRoman_1984_ReturnsMCMLXXXIV")]
    [TestCase(3749, "MMMDCCXLIX", TestName = "ConvertIntToRoman_3749_ReturnsMMMDCCXLIX")]
    public void ConvertIntToRoman_ValidInputs_ReturnsExpected(int number, string expected)
    {
        var actual = RomanToInteger.ConvertIntToRoman(number);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0, TestName = "ConvertIntToRoman_0_ThrowsArgumentOutOfRangeException")]
    [TestCase(-1, TestName = "ConvertIntToRoman_Negative_ThrowsArgumentOutOfRangeException")]
    [TestCase(4000, TestName = "ConvertIntToRoman_4000_ThrowsArgumentOutOfRangeException")]
    [TestCase(5000, TestName = "ConvertIntToRoman_5000_ThrowsArgumentOutOfRangeException")]
    public void ConvertIntToRoman_InvalidInputs_ThrowsArgumentOutOfRangeException(int number)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => RomanToInteger.ConvertIntToRoman(number));
    }

    [TestCase(1, TestName = "RoundTrip_1")]
    [TestCase(7, TestName = "RoundTrip_7")]
    [TestCase(42, TestName = "RoundTrip_42")]
    [TestCase(444, TestName = "RoundTrip_444")]
    [TestCase(1234, TestName = "RoundTrip_1234")]
    [TestCase(2023, TestName = "RoundTrip_2023")]
    [TestCase(3999, TestName = "RoundTrip_3999")]
    public void RoundTrip_IntToRomanToInt_ReturnsOriginalValue(int original)
    {
        var roman = RomanToInteger.ConvertIntToRoman(original);
        var result = RomanToInteger.ConvertRomanToInt(roman);
        Assert.That(result, Is.EqualTo(original));
    }
}