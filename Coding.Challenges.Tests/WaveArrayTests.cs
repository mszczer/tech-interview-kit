namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class WaveArrayTests
{
    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 2, 1, 9, 4, 24, 21, 43 })]
    public void GetWaveArray_ReturnsLexicographicallySmallestWaveArray(int[] input, int[] expected)
    {
        Assert.That(WaveArray.GetWaveArray(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 5, 2, 9, 3, 2 })]
    [TestCase(new[] { 3, 2, 9, 6, 4, 1 })]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 })]
    public void GetWaveArray_ReturnsWaveArray(int[] input)
    {
        var testArr = WaveArray.GetWaveArray(input);

        var checkResult = true;

        for (var i = 0; i < testArr.Length - 1; i += 2)
            if ((i + 1) % 2 == 0)
                if (testArr[i] > testArr[i - 1] || testArr[i] > testArr[i + 1])
                {
                    checkResult = false;
                    break;
                }

        Assert.That(checkResult, Is.True);
    }

    [Test]
    [TestCase(new[] { 5, 2, 9, 3, 2 })]
    [TestCase(new[] { 3, 2, 9, 6, 4, 1 })]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 })]
    public void GetWaveArrayComparingNeighbors_ReturnsWaveArray(int[] input)
    {
        var testArr = WaveArray.GetWaveArrayComparingNeighbors(input);

        var checkResult = true;

        for (var i = 0; i < testArr.Length - 1; i += 2)
            if ((i + 1) % 2 == 0)
                if (testArr[i] > testArr[i - 1] || testArr[i] > testArr[i + 1])
                {
                    checkResult = false;
                    break;
                }

        Assert.That(checkResult, Is.True);
    }
}