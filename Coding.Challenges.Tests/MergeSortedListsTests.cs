namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MergeSortedListsTests
{
    private static IEnumerable<TestCaseData> TestData()
    {
        yield return new TestCaseData(new[] { 10, 12, 13, 42 }, new[] { 4, 11, 15 },
            new[] { 4, 10, 11, 12, 13, 15, 42 });
        yield return new TestCaseData(new[] { 8 }, new[] { 4, 12 }, new[] { 4, 8, 12 });
        yield return new TestCaseData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 });
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void MergeSortedListsAndSort_ReturnsExpectedResult(int[] firstInput, int[] secondInput,
        int[] expectedResults)
    {
        var firstList = new LinkedList<int>(firstInput);
        var secondList = new LinkedList<int>(secondInput);
        var expectedList = new LinkedList<int>(expectedResults);

        var result = MergeSortedLists.MergeSortedListsAndSort(firstList, secondList);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void MergeSortedListsUsingTwoPointers_ReturnsExpectedResult(int[] firstInput, int[] secondInput,
        int[] expectedResults)
    {
        var firstList = new LinkedList<int>(firstInput);
        var secondList = new LinkedList<int>(secondInput);
        var expectedList = new LinkedList<int>(expectedResults);

        var result = MergeSortedLists.MergeSortedListsUsingTwoPointers(firstList, secondList);

        Assert.That(result, Is.EqualTo(expectedList));
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void MergeSortedListUsingRecursion_ReturnsExpectedResult(int[] firstInput, int[] secondInput,
        int[] expectedResults)
    {
        var firstList = new LinkedList<int>(firstInput);
        var secondList = new LinkedList<int>(secondInput);
        var expectedList = new LinkedList<int>(expectedResults);

        var result = MergeSortedLists.MergeSortedListUsingRecursion(firstList, secondList);

        Assert.That(result, Is.EqualTo(expectedList));
    }
}