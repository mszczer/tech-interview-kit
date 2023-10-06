using Coding.Challenges.Medium;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
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

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void SelectionSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.SelectionSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void InsertionSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.InsertionSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void ShellSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.ShellSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void CombSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.CombSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void MergeSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.MergeSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void QuickSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.QuickSort(input,0,input.Length-1), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void HeapSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.HeapSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 0.78, 0.17, 0.39, 0.26, 0.72, 0.94, 0.21, 0.12, 0.23, 0.68 }, new[] { 0.12, 0.17, 0.21, 0.23, 0.26, 0.39, 0.68, 0.72, 0.78, 0.94 })]
    public void BucketSort_ReturnsSortedArray(double[] input, double[] expected)
    {
        Assert.That(SortedArray.BucketSort(input), Is.EqualTo(expected));
    }

    [Test]
    [TestCase(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 })]
    public void CountingSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        Assert.That(SortedArray.CountingSort(input), Is.EqualTo(expected));
    }
}