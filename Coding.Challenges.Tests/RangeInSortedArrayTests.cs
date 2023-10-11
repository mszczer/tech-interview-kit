using System;
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

    [Test]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 7, 28, 37 }, new[] { 1,3,7,28,37})]
    [TestCase(new[] { 5, 7, 7, 8, 8, 10 }, new[] {5,10})]
    [TestCase(new[] { 7, 7, 8, 8}, new int[0])]
    public void GetElementsAppearingOnce_ReturnsArrayOfElements(int[] input, int[] expected)
    {
        Assert.That(RangeInSortedArray.GetElementsAppearingOnce(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 7, 28, 37 }, 1)]
    [TestCase(new[] { 10, 8,8,7,7, 5 }, 5)]
    [TestCase(new[] { 8}, 8)]
    [TestCase(new int[0], -1)]
    public void FindIdxOfTheMinimumInSortedArray_ReturnsIdx(int[] input, int expected)
    {
        Assert.That(RangeInSortedArray.FindIdxOfTheMinimumInSortedArray(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 7, 28, 37 }, 5)]
    [TestCase(new[] { 10, 8, 7, 5 }, int.MinValue)]
    [TestCase(new int[0], int.MinValue)]
    public void FindOnlyRepeatingElementInSortedArray_ReturnsRepeatingElement(int[] input, int expected)
    {
        Assert.That(RangeInSortedArray.FindOnlyRepeatingElementInSortedArray(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 1, 3, 5, 5, 5, 5, 7, 28, 37 }, 2)]
    [TestCase(new[] { 10, 9, 7, 5 }, 8)]
    [TestCase(new[] { 1, 2, 3 }, int.MinValue)]
    [TestCase(new[] { 12 }, int.MinValue)]
    [TestCase(new int[0], int.MinValue)]
    public void FindFirstMissingElementInSortedArray_ReturnsFirstMissingNumber(int[] input, int expected)
    {
        Assert.That(RangeInSortedArray.FindFirstMissingElementInSortedArray(input), Is.EqualTo(expected));
    }

}