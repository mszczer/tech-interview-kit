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

    private static IEnumerable<TestCaseData> SetEvenBitsToZeroTestCases()
    {
        yield return new TestCaseData("0010100", "00000");
        yield return new TestCaseData("10100", "00000");
        yield return new TestCaseData("0", "0");
        yield return new TestCaseData("1", "0");
        yield return new TestCaseData("00000", "0");
        yield return new TestCaseData("0001", "0");
        yield return new TestCaseData("00010", "00");
        yield return new TestCaseData("000101", "000");
        yield return new TestCaseData("00", "0");
        yield return new TestCaseData("10", "00");
        yield return new TestCaseData("01", "0");
        yield return new TestCaseData("11", "01");
        yield return new TestCaseData("000", "0");
        yield return new TestCaseData("101", "000");
        yield return new TestCaseData("110", "010");
        yield return new TestCaseData("100", "000");
        yield return new TestCaseData("0000", "0");
        yield return new TestCaseData("1111", "0101");
        yield return new TestCaseData("1010", "0000");
        yield return new TestCaseData("0101", "000");
        yield return new TestCaseData("1000", "0000");
        yield return new TestCaseData("11111", "01010");
        yield return new TestCaseData("10000", "00000");
        yield return new TestCaseData("00000000", "0");
        yield return new TestCaseData("11111111", "01010101");
        yield return new TestCaseData("10101010", "00000000");
        yield return new TestCaseData("10000000", "00000000");
    }

    [Test]
    [TestCaseSource(nameof(SetEvenBitsToZeroTestCases))]
    public void SetEvenBitsToZero_SetsEvenPositionsToZero(string input, string expected)
    {
        Assert.That(ReverseBits.SetEvenBitsToZero(input), Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> IsPalindromeTestCases()
    {
        yield return new TestCaseData(0, true);
        yield return new TestCaseData(1, true);
        yield return new TestCaseData(3, true);   // 11
        yield return new TestCaseData(5, true);   // 101
        yield return new TestCaseData(7, true);   // 111
        yield return new TestCaseData(9, true);   // 1001
        yield return new TestCaseData(15, true);  // 1111
        yield return new TestCaseData(21, true);  // 10101
        yield return new TestCaseData(31, true);  // 11111
        yield return new TestCaseData(45, true);  // 101101
        yield return new TestCaseData(99, true);  // 1100011
        yield return new TestCaseData(2, false);   // 10
        yield return new TestCaseData(4, false);   // 100
        yield return new TestCaseData(6, false);   // 110
        yield return new TestCaseData(8, false);   // 1000
        yield return new TestCaseData(10, false);  // 1010
        yield return new TestCaseData(13, false);  // 1101
        yield return new TestCaseData(100, false); // 1100100
    }

    [Test]
    [TestCaseSource(nameof(IsPalindromeTestCases))]
    public void IsPalindrome_ChecksIfBinaryRepresentationIsPalindrome(int input, bool expected)
    {
        Assert.That(ReverseBits.IsPalindrome(input), Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> RotateBitsOfNumberTestCases()
    {
        // Basic edge cases
        yield return new TestCaseData("0", 0, "0").SetName("Zero rotation of zero");
        yield return new TestCaseData("0", 1, "0").SetName("Right rotation of zero");
        yield return new TestCaseData("1", 1, "1").SetName("Single bit rotation");
        yield return new TestCaseData("1", 0, "1").SetName("Zero rotation of single bit");

        // Right rotations (k > 0)
        yield return new TestCaseData("1101", 1, "1110").SetName("Rotate right by 1: 1101 -> 1110");
        yield return new TestCaseData("1101", 2, "0111").SetName("Rotate right by 2: 1101 -> 0111");
        yield return new TestCaseData("1101", 3, "1011").SetName("Rotate right by 3: 1101 -> 1011");
        yield return new TestCaseData("1101", 4, "1101").SetName("Rotate right by 4 (full rotation): 1101 -> 1101");
        yield return new TestCaseData("10000000", 1, "01000000").SetName("Rotate right by 1: 10000000 -> 01000000");
        yield return new TestCaseData("10000000", 7, "00000001").SetName("Rotate right by 7: 10000000 -> 00000001");

        // Left rotations (k < 0)
        yield return new TestCaseData("1101", -1, "1011").SetName("Rotate left by 1: 1101 -> 1011");
        yield return new TestCaseData("1101", -2, "0111").SetName("Rotate left by 2: 1101 -> 0111");
        yield return new TestCaseData("1101", -3, "1110").SetName("Rotate left by 3: 1101 -> 1110");
        yield return new TestCaseData("1101", -4, "1101").SetName("Rotate left by 4 (full rotation): 1101 -> 1101");
        yield return new TestCaseData("10000000", -1, "00000001").SetName("Rotate left by 1: 10000000 -> 00000001");
        yield return new TestCaseData("10000000", -7, "01000000").SetName("Rotate left by 7: 10000000 -> 01000000");

        // Rotations larger than bit width
        yield return new TestCaseData("1101", 5, "1110").SetName("Rotate right by 5 (wraps around): 1101 -> 1110");
        yield return new TestCaseData("1101", 6, "0111").SetName("Rotate right by 6 (wraps around): 1101 -> 0111");
        yield return new TestCaseData("1101", -5, "1011").SetName("Rotate left by 5 (wraps around): 1101 -> 1011");
        yield return new TestCaseData("1101", -6, "0111").SetName("Rotate left by 6 (wraps around): 1101 -> 0111");

        // Leading zeros (should be trimmed)
        yield return new TestCaseData("0001101", 1, "1110").SetName("Leading zeros trimmed before rotation");
        yield return new TestCaseData("000101", -1, "011").SetName("Leading zeros trimmed: 000101 -> 101 -> 011");

        // Alternating patterns
        yield return new TestCaseData("10101010", 1, "01010101").SetName("Alternating pattern rotate right by 1");
        yield return new TestCaseData("10101010", -1, "01010101").SetName("Alternating pattern rotate left by 1");
        yield return new TestCaseData("10101010", 2, "10101010").SetName("Alternating pattern rotate right by 2 (back to same)");

        // All ones
        yield return new TestCaseData("1111", 1, "1111").SetName("All ones rotate right by 1");
        yield return new TestCaseData("1111", -1, "1111").SetName("All ones rotate left by 1");
        yield return new TestCaseData("11111111", 3, "11111111").SetName("All ones rotate by any amount");

        // Two bits
        yield return new TestCaseData("10", 1, "01").SetName("Two bits: 10 -> 01");
        yield return new TestCaseData("01", 1, "1").SetName("Two bits: 01 -> 1");
        yield return new TestCaseData("11", 1, "11").SetName("Two bits: 11 -> 11");

        // Three bits
        yield return new TestCaseData("101", 1, "110").SetName("Three bits rotate right by 1: 101 -> 110");
        yield return new TestCaseData("101", -1, "011").SetName("Three bits rotate left by 1: 101 -> 011");
        yield return new TestCaseData("111", 1, "111").SetName("Three bits all ones");

        // Empty string after trimming
        yield return new TestCaseData("00000", 5, "0").SetName("All zeros return 0");
    }

    [Test]
    [TestCaseSource(nameof(RotateBitsOfNumberTestCases))]
    public void RotateBitsOfNumber_RotatesBitsCorrectly(string input, int k, string expected)
    {
        Assert.That(ReverseBits.RotateBitsOfNumber(input, k), Is.EqualTo(expected));
    }
}