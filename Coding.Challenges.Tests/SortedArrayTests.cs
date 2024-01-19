﻿using System.Collections.Generic;
using Coding.Challenges.Medium;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SortedArrayTests
{
    private static IEnumerable<TestCaseData> SortingAlgorithmTestCases()
    {
        yield return new TestCaseData(new[] { 4, 2, 9, 1, 21, 43, 24 }, new[] { 1, 2, 4, 9, 21, 24, 43 });
    }

    private static IEnumerable<TestCaseData> SortingAlgorithmTestCasesDouble()
    {
        yield return new TestCaseData(new[] { 0.78, 0.17, 0.39, 0.26, 0.72, 0.94, 0.21, 0.12, 0.23, 0.68 },
            new[] { 0.12, 0.17, 0.21, 0.23, 0.26, 0.39, 0.68, 0.72, 0.78, 0.94 });
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void BubbleSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.BubbleSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void OptimizedBubbleSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.OptimizedBubbleSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void SelectionSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.SelectionSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void InsertionSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.InsertionSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void ShellSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.ShellSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void CombSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.CombSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void MergeSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.MergeSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void QuickSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.QuickSort(input, 0, input.Length - 1), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void HeapSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.HeapSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCasesDouble))]
    public void BucketSort_ReturnsSortedArray(double[] input, double[] expected)
    {
        AssertSortedArray(SortedArray.BucketSort(input), expected);
    }

    [Test]
    [TestCaseSource(nameof(SortingAlgorithmTestCases))]
    public void CountingSort_ReturnsSortedArray(int[] input, int[] expected)
    {
        AssertSortedArray(SortedArray.CountingSort(input), expected);
    }

    private static void AssertSortedArray<T>(T[] actual, T[] expected)
    {
        Assert.That(actual, Is.EqualTo(expected));
    }
}