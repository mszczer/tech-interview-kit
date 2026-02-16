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
        var serialized = tree.SerializeLevelOrderTraversal();

        Assert.That(serialized, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Cases))]
    public void ConvertArrToBstIterative_ReturnsExpectedLevelOrder(int[] arr, List<int?> expected)
    {
        var tree = SortedArrayToBalancedBst.ConvertArrToBstIterative(arr);
        var serialized = tree.SerializeLevelOrderTraversal();

        Assert.That(serialized, Is.EqualTo(expected));
    }

    [Test]
    [TestCaseSource(nameof(Cases))]
    public void SortedLinkedListToBalancedBst_ReturnsExpectedLevelOrder(int[] arr, List<int?> expected)
    {
        var list = arr == null ? null : new LinkedList<int>(arr);
        var tree = SortedArrayToBalancedBst.SortedLinkedListToBalancedBst(list);
        var serialized = tree.SerializeLevelOrderTraversal();

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
            var recursive = SortedArrayToBalancedBst.ConvertArrToBst(arr).SerializeLevelOrderTraversal();
            var iterative = SortedArrayToBalancedBst.ConvertArrToBstIterative(arr).SerializeLevelOrderTraversal();
            Assert.That(iterative, Is.EqualTo(recursive), $"Mismatch for input: [{string.Join(',', arr)}]");
        }
    }

    [Test]
    public void ConvertArrToBst_LargeArray_ProducesConsistentResult()
    {
        const int n = 1000;
        var arr = new int[n];
        for (var i = 0; i < n; i++) arr[i] = i;

        var recursive = SortedArrayToBalancedBst.ConvertArrToBst(arr).SerializeLevelOrderTraversal();
        var iterative = SortedArrayToBalancedBst.ConvertArrToBstIterative(arr).SerializeLevelOrderTraversal();

        Assert.That(iterative, Is.EqualTo(recursive));
    }

    private static IEnumerable<TestCaseData> FindKthSuccessCases()
    {
        yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 1, 1).SetName("FindKth_FirstElement");
        yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 3, 3).SetName("FindKth_MiddleElement");
        yield return new TestCaseData(new[] { 1, 2, 3, 4, 5 }, 5, 5).SetName("FindKth_LastElement");

        yield return new TestCaseData(new[] { 1, 1, 1, 1 }, 1, 1).SetName("FindKth_Duplicates_K1");
        yield return new TestCaseData(new[] { 1, 1, 1, 1 }, 2, 1).SetName("FindKth_Duplicates_K2");
        yield return new TestCaseData(new[] { 1, 1, 1, 1 }, 4, 1).SetName("FindKth_Duplicates_K4");

        yield return new TestCaseData(new[] { -5, -3, 0, 2, 10 }, 3, 0).SetName("FindKth_MixedValues");
    }

    [Test]
    [TestCaseSource(nameof(FindKthSuccessCases))]
    public void FindKthSmallestElementInBst_Succeeds(int[] arr, int k, int expected)
    {
        var bst = SortedArrayToBalancedBst.ConvertArrToBst(arr);
        var result = SortedArrayToBalancedBst.FindKthSmallestElementInBst(k, bst);

        Assert.That(result, Is.EqualTo(expected));
    }

    private static IEnumerable<TestCaseData> FindKthInvalidKCases()
    {
        yield return new TestCaseData(new[] { 1, 2, 3 }, 0).SetName("FindKth_InvalidK_Zero");
        yield return new TestCaseData(new[] { 1, 2, 3 }, 4).SetName("FindKth_InvalidK_GreaterThanCount");
    }

    [Test]
    [TestCaseSource(nameof(FindKthInvalidKCases))]
    public void FindKthSmallestElementInBst_InvalidK_ThrowsArgumentOutOfRange(int[] arr, int k)
    {
        var bst = SortedArrayToBalancedBst.ConvertArrToBst(arr);
        Assert.Throws<ArgumentOutOfRangeException>(() => SortedArrayToBalancedBst.FindKthSmallestElementInBst(k, bst));
    }

    private static IEnumerable<TestCaseData> FindKthInvalidBstCases()
    {
        yield return new TestCaseData(null, 1).SetName("FindKth_NullBst_Throws");
        yield return new TestCaseData(Array.Empty<int>(), 1).SetName("FindKth_EmptyBst_Throws");
    }

    [Test]
    [TestCaseSource(nameof(FindKthInvalidBstCases))]
    public void FindKthSmallestElementInBst_NullOrEmptyBst_ThrowsArgumentException(int[]? arr, int k)
    {
        var bst = arr is null ? null : SortedArrayToBalancedBst.ConvertArrToBst(arr);
        Assert.Throws<ArgumentException>(() => SortedArrayToBalancedBst.FindKthSmallestElementInBst(k, bst));
    }
}