namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestReverseBits
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

    private static IEnumerable<TestCaseData> InvertActualBitsTestCases()
    {
        yield return new TestCaseData("0001101", "0010");
        yield return new TestCaseData("1101", "0010");
        yield return new TestCaseData("0000", "1");
        yield return new TestCaseData("0", "1");
        yield return new TestCaseData("0001", "0");
        yield return new TestCaseData("001010", "0101");
    }

    [Test]
    [TestCaseSource(nameof(InvertActualBitsTestCases))]
    public void InvertActualBits_ReturnsTheInvertedBits(string input, string expected)
    {
        Assert.That(ReverseBits.InvertActualBits(input), Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> SetOddBitsToOneTestCases()
    {
        yield return new TestCaseData("0010100", "11110");
        yield return new TestCaseData("10100", "11110");
        yield return new TestCaseData("0", "0");
        yield return new TestCaseData("1", "1");
        yield return new TestCaseData("00000", "0");
        yield return new TestCaseData("0001", "1");
        yield return new TestCaseData("00010", "11");
        yield return new TestCaseData("000101", "111");
        yield return new TestCaseData("00", "0");
        yield return new TestCaseData("10", "11");
        yield return new TestCaseData("01", "1");
        yield return new TestCaseData("11", "11");
        yield return new TestCaseData("000", "0");
        yield return new TestCaseData("101", "111");
        yield return new TestCaseData("110", "110");
        yield return new TestCaseData("100", "110");
        yield return new TestCaseData("0000", "0");
        yield return new TestCaseData("1111", "1111");
        yield return new TestCaseData("1010", "1111");
        yield return new TestCaseData("0101", "111");
        yield return new TestCaseData("1000", "1101");
        yield return new TestCaseData("11111", "11111");
        yield return new TestCaseData("10000", "11010");
        yield return new TestCaseData("00000000", "0");
        yield return new TestCaseData("11111111", "11111111");
        yield return new TestCaseData("10101010", "11111111");
        yield return new TestCaseData("10000000", "11010101");
    }

    [Test]
    [TestCaseSource(nameof(SetOddBitsToOneTestCases))]
    public void SetOddBitsToOne_SetsOddPositionsToOne(string input, string expected)
    {
        Assert.That(ReverseBits.SetOddBitsToOne(input), Is.EqualTo(expected));
    }
}