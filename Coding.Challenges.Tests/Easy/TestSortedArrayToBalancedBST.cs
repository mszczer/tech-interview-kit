using System;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestSortedArrayToBalancedBst
{
    private static IEnumerable<TestCaseData> Cases()
    {
        yield return new TestCaseData(
            new[] { 1, 2, 3 },
            new List<int?> { 2, 1, 3 }
        ).SetName("ConvertArrToBst_WithThreeElements_ReturnsBalancedBst");

        yield return new TestCaseData(
            new[] { 1, 2, 3, 4 },
            new List<int?> { 3, 2, 4, 1 }
        ).SetName("ConvertArrToBst_WithFourElements_ReturnsBalancedBst_UpperMiddle");

        // Additional test cases
        yield return new TestCaseData(
            Array.Empty<int>(),
            new List<int?>()
        ).SetName("ConvertArrToBst_WithEmptyArray_ReturnsEmptyTree");

        yield return new TestCaseData(
            new[] { 5 },
            new List<int?> { 5 }
        ).SetName("ConvertArrToBst_WithSingleElement_ReturnsSingleNodeTree");

        yield return new TestCaseData(
            new[] { 1, 2 },
            new List<int?> { 2, 1 }
        ).SetName("ConvertArrToBst_WithTwoElements_ReturnsUpperMiddleRoot");

        yield return new TestCaseData(
            new[] { 1, 2, 3, 4, 5 },
            new List<int?> { 3, 2, 5, 1, 4 }
        ).SetName("ConvertArrToBst_WithFiveElements_ReturnsBalancedBst");

        yield return new TestCaseData(
            new[] { 1, 1, 1, 1 },
            new List<int?> { 1, 1, 1, 1 }
        ).SetName("ConvertArrToBst_WithDuplicates_DeterministicPlacement");

        yield return new TestCaseData(
            null,
            new List<int?>()
        ).SetName("ConvertArrToBst_WithNullInput_ReturnsEmptyTree");
    }

    [Test]
    [TestCaseSource(nameof(Cases))]
    public void ConvertArrToBst_ReturnsExpectedLevelOrder(int[] arr, List<int?> expected)
    {
        var tree = SortedArrayToBalancedBst.ConvertArrToBst(arr);
        var serialized = tree.SerializeLevelOrder();

        Assert.That(serialized, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Cases))]
    public void ConvertArrToBstIterative_ReturnsExpectedLevelOrder(int[] arr, List<int?> expected)
    {
        var tree = SortedArrayToBalancedBst.ConvertArrToBstIterative(arr);
        var serialized = tree.SerializeLevelOrder();

        Assert.That(serialized, Is.EqualTo(expected));
    }

    [Test]
    public void ConvertArrToBst_RecursiveAndIterative_AreConsistent()
    {
        var testArrays = new[]
        {
            Array.Empty<int>(),
            new[] { 1 },
            new[] { 1, 2 },
            new[] { 1, 2, 3, 4 },
            new[] { 1, 2, 3, 4, 5 },
            new[] { 1, 1, 1, 1 },
            new[] { -5, -3, 0, 2, 10 }
        };

        foreach (var arr in testArrays)
        {
            var recursive = SortedArrayToBalancedBst.ConvertArrToBst(arr).SerializeLevelOrder();
            var iterative = SortedArrayToBalancedBst.ConvertArrToBstIterative(arr).SerializeLevelOrder();
            Assert.That(iterative, Is.EqualTo(recursive), $"Mismatch for input: [{string.Join(',', arr)}]");
        }
    }

    [Test]
    public void ConvertArrToBst_LargeArray_ProducesConsistentResult()
    {
        const int n = 1000;
        var arr = new int[n];
        for (var i = 0; i < n; i++) arr[i] = i;

        var recursive = SortedArrayToBalancedBst.ConvertArrToBst(arr).SerializeLevelOrder();
        var iterative = SortedArrayToBalancedBst.ConvertArrToBstIterative(arr).SerializeLevelOrder();

        Assert.That(iterative, Is.EqualTo(recursive));
    }
}