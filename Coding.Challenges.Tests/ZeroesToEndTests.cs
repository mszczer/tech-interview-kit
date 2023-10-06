using Coding.Challenges.Easy;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ZeroesToEndTests
{
    [Test]
    [TestCase(new[] { 1, 8, 0, 2, 0, 1, 13, 0 }, new[] { 1, 8, 2, 1, 13, 0, 0, 0 })]
    [TestCase(new[] { 0, 0, 0, 23, 2 }, new[] { 23, 2, 0, 0, 0 })]
    public void MoveZeroesToEnd_ReturnsArrayWithZeroesAtEnd(int[] input, int[] expected)
    {
        Assert.That(ZeroesToEnd.MoveZeroesToEnd(input), Is.EqualTo(expected));
    }

}