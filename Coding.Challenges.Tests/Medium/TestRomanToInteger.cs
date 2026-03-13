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

    [TestCase(0, "0", TestName = "ConvertIntToBinary_0_Returns0")]
    [TestCase(1, "1", TestName = "ConvertIntToBinary_1_Returns1")]
    [TestCase(2, "10", TestName = "ConvertIntToBinary_2_Returns10")]
    [TestCase(5, "101", TestName = "ConvertIntToBinary_5_Returns101")]
    [TestCase(8, "1000", TestName = "ConvertIntToBinary_8_Returns1000")]
    [TestCase(10, "1010", TestName = "ConvertIntToBinary_10_Returns1010")]
    [TestCase(15, "1111", TestName = "ConvertIntToBinary_15_Returns1111")]
    [TestCase(16, "10000", TestName = "ConvertIntToBinary_16_Returns10000")]
    [TestCase(42, "101010", TestName = "ConvertIntToBinary_42_Returns101010")]
    [TestCase(255, "11111111", TestName = "ConvertIntToBinary_255_Returns11111111")]
    [TestCase(256, "100000000", TestName = "ConvertIntToBinary_256_Returns100000000")]
    [TestCase(1024, "10000000000", TestName = "ConvertIntToBinary_1024_Returns10000000000")]
    public void ConvertIntToBinary_ValidInputs_ReturnsExpected(int number, string expected)
    {
        var actual = RomanToInteger.ConvertIntToBinary(number);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(-1, TestName = "ConvertIntToBinary_Negative1_ThrowsArgumentOutOfRangeException")]
    [TestCase(-100, TestName = "ConvertIntToBinary_Negative100_ThrowsArgumentOutOfRangeException")]
    [TestCase(int.MinValue, TestName = "ConvertIntToBinary_MinValue_ThrowsArgumentOutOfRangeException")]
    public void ConvertIntToBinary_NegativeInputs_ThrowsArgumentOutOfRangeException(int number)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => RomanToInteger.ConvertIntToBinary(number));
    }

    [TestCase(1230000, "1.23 × 10^6", TestName = "DecimalToExponentialNotation_1230000_Returns1Point23Times10Power6")]
    [TestCase(0.000045, "4.5 × 10^-5", TestName = "DecimalToExponentialNotation_0Point000045_Returns4Point5Times10PowerMinus5")]
    [TestCase(0, "0 × 10^0", TestName = "DecimalToExponentialNotation_0_Returns0Times10Power0")]
    public void DecimalToExponentialNotation_ValidInputs_ReturnsExpected(decimal number, string expected)
    {
        var actual = RomanToInteger.DecimalToExponentialNotation(number);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("0", "9", TestName = "NinesComplement_0_Returns9")]
    [TestCase("7", "2", TestName = "NinesComplement_7_Returns2")]
    [TestCase("1234", "8765", TestName = "NinesComplement_1234_Returns8765")]
    [TestCase("909", "090", TestName = "NinesComplement_909_Returns090")]
    [TestCase("456.20", "543.79", TestName = "NinesComplement_456Point20_Returns543Point79")]
    [TestCase("0019", "9980", TestName = "NinesComplement_0019_Returns9980")]
    [TestCase("99", "00", TestName = "NinesComplement_99_Returns00")]
    [TestCase("5", "4", TestName = "NinesComplement_5_Returns4")]
    [TestCase("123.456", "876.543", TestName = "NinesComplement_123Point456_Returns876Point543")]
    public void NinesComplement_ValidInputs_ReturnsExpected(string number, string expected)
    {
        var actual = RomanToInteger.NinesComplement(number);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("", TestName = "NinesComplement_EmptyString_ThrowsArgumentException")]
    [TestCase("   ", TestName = "NinesComplement_Whitespace_ThrowsArgumentException")]
    public void NinesComplement_InvalidInputs_ThrowsArgumentException(string number)
    {
        Assert.Throws<ArgumentException>(() => RomanToInteger.NinesComplement(number));
    }

    [Test]
    public void NinesComplement_Null_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => RomanToInteger.NinesComplement(null));
    }
}