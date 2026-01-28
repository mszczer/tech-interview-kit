namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class TestMergeSortedLists
{
    private static IEnumerable<TestCaseData> TestData()
    {
        // Both lists non-empty, interleaved
        yield return new TestCaseData(new[] { 10, 12, 13, 42 }, new[] { 4, 11, 15 }, new[] { 4, 10, 11, 12, 13, 15, 42 });
        yield return new TestCaseData(new[] { 8 }, new[] { 4, 12 }, new[] { 4, 8, 12 });
        yield return new TestCaseData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 });
        // One list empty
        yield return new TestCaseData(new int[0], new[] { 1, 2, 3 }, new[] { 1, 2, 3 });
        yield return new TestCaseData(new[] { 1, 2, 3 }, new int[0], new[] { 1, 2, 3 });
        // Both lists empty
        yield return new TestCaseData(new int[0], new int[0], new int[0]);
        // Lists with negative numbers
        yield return new TestCaseData(new[] { -5, 0, 2 }, new[] { -3, 1, 3 }, new[] { -5, -3, 0, 1, 2, 3 });
        // All elements in one list less than the other
        yield return new TestCaseData(new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 1, 2, 3, 4, 5, 6 });
        yield return new TestCaseData(new[] { 4, 5, 6 }, new[] { 1, 2, 3 }, new[] { 1, 2, 3, 4, 5, 6 });
        // Lists with duplicates
        yield return new TestCaseData(new[] { 1, 2, 2 }, new[] { 2, 3, 3 }, new[] { 1, 2, 2, 2, 3, 3 });
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void MergeSortedListsAndSort_ReturnsExpectedResult(int[] firstInput, int[] secondInput, int[] expectedResults)
    {
        var firstList = new LinkedList<int>(firstInput);
        var secondList = new LinkedList<int>(secondInput);
        var expectedList = new LinkedList<int>(expectedResults);

        var result = Challenges.Easy.MergeSortedLists.MergeSortedListsAndSort(firstList, secondList);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void MergeSortedListsUsingTwoPointers_ReturnsExpectedResult(int[] firstInput, int[] secondInput, int[] expectedResults)
    {
        var firstList = new LinkedList<int>(firstInput);
        var secondList = new LinkedList<int>(secondInput);
        var expectedList = new LinkedList<int>(expectedResults);

        var result = Challenges.Easy.MergeSortedLists.MergeSortedListsUsingTwoPointers(firstList, secondList);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void MergeSortedListUsingRecursion_ReturnsExpectedResult(int[] firstInput, int[] secondInput, int[] expectedResults)
    {
        var firstList = new LinkedList<int>(firstInput);
        var secondList = new LinkedList<int>(secondInput);
        var expectedList = new LinkedList<int>(expectedResults);

        var result = Challenges.Easy.MergeSortedLists.MergeSortedListUsingRecursion(firstList, secondList);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    public void MergeSortedListsAndSort_NullInputs_ReturnsOtherOrNull()
    {
        LinkedList<int>? nullList = null;
        var nonEmpty = new LinkedList<int>(new[] { 1, 2, 3 });

        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListsAndSort(nullList, nullList), Is.Null);
        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListsAndSort(nonEmpty, nullList), Is.EqualTo(nonEmpty));
        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListsAndSort(nullList, nonEmpty), Is.EqualTo(nonEmpty));
    }

    [Test]
    public void MergeSortedListsUsingTwoPointers_NullInputs_ReturnsOtherOrNull()
    {
        LinkedList<int>? nullList = null;
        var nonEmpty = new LinkedList<int>(new[] { 1, 2, 3 });

        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListsUsingTwoPointers(nullList, nullList), Is.Null);
        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListsUsingTwoPointers(nonEmpty, nullList), Is.EqualTo(nonEmpty));
        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListsUsingTwoPointers(nullList, nonEmpty), Is.EqualTo(nonEmpty));
    }

    [Test]
    public void MergeSortedListUsingRecursion_NullInputs_ReturnsOtherOrNull()
    {
        LinkedList<int>? nullList = null;
        var nonEmpty = new LinkedList<int>(new[] { 1, 2, 3 });

        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListUsingRecursion(nullList, nullList), Is.Empty);
        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListUsingRecursion(nonEmpty, nullList), Is.EqualTo(nonEmpty));
        Assert.That(Challenges.Easy.MergeSortedLists.MergeSortedListUsingRecursion(nullList, nonEmpty), Is.EqualTo(nonEmpty));
    }
}