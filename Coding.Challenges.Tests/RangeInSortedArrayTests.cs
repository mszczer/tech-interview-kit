using Coding.Challenges.Easy;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class RangeInSortedArrayTests
{
    [Test]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 28, 37, 42 },5, new[] { 2, 5 })]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 7, 28, 37 },7, new[] { 6,6})]
    [TestCase(new[] { 5, 7, 7, 8, 8, 10 }, 6, new[] { -1,-1 })]
    public void GetRangeIndexes_ReturnsFirstAndLastIdx(int[] input,int target, int[] output)
    {
        Assert.That(RangeInSortedArray.GetRangeIndexes(input,target), Is.EqualTo(output));
    }

    [Test]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 28, 37, 42 }, 5, new[] { 2, 5 })]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 7, 28, 37 }, 7, new[] { 6, 6 })]
    [TestCase(new[] { 5, 7, 7, 8, 8, 10 }, 6, new[] { -1, -1 })]
    public void GetRangeIndexes_BinarySearch_ReturnsFirstAndLastIdx(int[] input, int target, int[] output)
    {
        Assert.That(RangeInSortedArray.GetRangeIndexes_BinarySearch(input, target), Is.EqualTo(output));
    }
}