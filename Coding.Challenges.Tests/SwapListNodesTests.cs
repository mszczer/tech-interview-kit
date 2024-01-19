using System.Collections.Generic;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SwapListNodesTests
{
    private static IEnumerable<TestCaseData> TestData()
    {
        yield return new TestCaseData(new[] { 10, 20, 30, 40 }, new[] { 20, 10, 40, 30 });
        yield return new TestCaseData(new[] { 80, 20, 5, 9, 2 }, new[] { 20, 80, 9, 5, 2 });
    }

    [Test]
    [TestCaseSource(nameof(TestData))]
    public void SwapNodes_SwapsListNodesInPairs(int[] inputData, int[] expectedOutput)
    {
        var inputList = new LinkedList<int>(inputData);
        var expectedList = new List<int>(expectedOutput);

        var result = SwapListNodes.SwapNodes(inputList);

        Assert.That(result, Is.EqualTo(expectedList));
    }
}