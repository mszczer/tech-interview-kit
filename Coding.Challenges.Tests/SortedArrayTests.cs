namespace Coding.Challenges.Tests;

[TestFixture]
public class SortedArrayTests
{
    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void BubbleSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.BubbleSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void OptimizedBubbleSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.OptimizedBubbleSort(input), Is.EqualTo(expected));
    }
}