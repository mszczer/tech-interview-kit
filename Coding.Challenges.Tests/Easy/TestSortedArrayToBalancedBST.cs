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
    }

    [Test]
    [TestCaseSource(nameof(Cases))]
    public void ConvertArrToBst_ReturnsExpectedLevelOrder(int[] arr, List<int?> expected)
    {
        var tree = SortedArrayToBalancedBst.ConvertArrToBst(arr);
        var serialized = tree.SerializeLevelOrder();

        Assert.That(serialized, Is.EqualTo(expected));
    }
}