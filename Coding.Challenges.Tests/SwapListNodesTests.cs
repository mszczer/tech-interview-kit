using System.Collections.Generic;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SwapListNodesTests
{
    [Test]
    public void SwapNodes_SwapsListNodesInPairs()
    {
        var inputData = new[] { 80, 20, 5, 9, 2 };
        var input = new LinkedList<int>(inputData);
        var outputData = new[] { 20, 80, 9, 5, 2 };
        var expected = new List<int>(outputData);

        Assert.That(SwapListNodes.SwapNodes(input), Is.EqualTo(expected));
    }
}