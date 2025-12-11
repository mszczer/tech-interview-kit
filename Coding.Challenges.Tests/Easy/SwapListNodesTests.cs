namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SwapListNodesTests
{
    private static IEnumerable<TestCaseData> TestData()
    {
        yield return new TestCaseData(new int[] { }, new int[] { }); // Empty list
        yield return new TestCaseData(new[] { 1 }, new[] { 1 }); // Single node
        yield return new TestCaseData(new[] { 1, 2, 3 }, new[] { 2, 1, 3 }); // Odd length
        yield return new TestCaseData(new[] { 1, 2, 3, 4 }, new[] { 2, 1, 4, 3 }); // Even length
        yield return new TestCaseData(new[] { 5, 5, 5, 5 }, new[] { 5, 5, 5, 5 }); // Duplicate values
        yield return new TestCaseData(new[] { -1, -2, -3, -4 }, new[] { -2, -1, -4, -3 }); // Negative values
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void SwapNodes_SwapsListNodesInPairs(int[] inputData, int[] expectedOutput)
    {
        var inputList = new LinkedList<int>(inputData);
        var expectedList = new LinkedList<int>(expectedOutput);

        var result = SwapListNodes.SwapNodes(inputList);

        Assert.That(result, Is.EqualTo(expectedList));
    }
}