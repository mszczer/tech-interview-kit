using Coding.Challenges.Common;

namespace Coding.Challenges.Tests.Easy;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MergeTwoBinaryTreesTests
{
    private static readonly List<int> ExpectedSerialized = GetExpectedSerialized();

    [Test]
    public void MergeResult_MatchesExpectedStructure_LevelOrder()
    {
        var merged = MergeTwoBinaryTrees.GetMergedTree(BuildFirstTree(), BuildSecondTree());
        var actual = BinaryTree<int>.SerializeLevelOrder(merged?.Root);
        Assert.That(actual, Is.EqualTo(ExpectedSerialized));
    }

    [Test]
    public void MergeIterativeResult_MatchesExpectedStructure_LevelOrder()
    {
        var mergedIterative = MergeTwoBinaryTrees.GetMergedTreeIterative(BuildFirstTree(), BuildSecondTree());
        var actual = BinaryTree<int>.SerializeLevelOrder(mergedIterative?.Root);
        Assert.That(actual, Is.EqualTo(ExpectedSerialized));
    }

    [Test]
    public void GetMergedTree_BothNull_ReturnsInstance()
    {
        var result = MergeTwoBinaryTrees.GetMergedTree(null, null);
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void GetMergedTree_BothNull_RootIsNull()
    {
        var result = MergeTwoBinaryTrees.GetMergedTree(null, null);
        Assert.That(result?.Root, Is.Null);
    }

    [Test]
    public void GetMergedTree_FirstNull_ReturnsSecondInstance()
    {
        var second = new BinaryTree<int> { Root = new TreeNode<int>(42) };
        var result = MergeTwoBinaryTrees.GetMergedTree(null, second);
        Assert.That(result, Is.SameAs(second));
    }

    [Test]
    public void GetMergedTree_SecondNull_ReturnsFirstInstance()
    {
        var first = new BinaryTree<int> { Root = new TreeNode<int>(17) };
        var result = MergeTwoBinaryTrees.GetMergedTree(first, null);
        Assert.That(result, Is.SameAs(first));
    }

    [Test]
    public void GetMergedTree_SingleNodeTrees_SumRoots()
    {
        var a = new BinaryTree<int> { Root = new TreeNode<int>(3) };
        var b = new BinaryTree<int> { Root = new TreeNode<int>(4) };
        var merged = MergeTwoBinaryTrees.GetMergedTree(a, b);
        var serialized = BinaryTree<int>.SerializeLevelOrder(merged?.Root);
        Assert.That(serialized, Is.EqualTo(new List<int> { 7 }));
    }

    [Test]
    public void GetMergedTreeIterative_FirstNull_ReturnsSecondInstance()
    {
        var second = new BinaryTree<int> { Root = new TreeNode<int>(9) };
        var result = MergeTwoBinaryTrees.GetMergedTreeIterative(null, second);
        Assert.That(result, Is.SameAs(second));
    }

    private static BinaryTree<int> BuildFirstTree()
    {
        var firstTree = new BinaryTree<int> { Root = new TreeNode<int>(1) };
        firstTree.Root.LeftNode = new TreeNode<int>(6);
        firstTree.Root.RightNode = new TreeNode<int>(2);
        firstTree.Root.LeftNode.LeftNode = new TreeNode<int>(5);
        return firstTree;
    }

    private static BinaryTree<int> BuildSecondTree()
    {
        var secondTree = new BinaryTree<int> { Root = new TreeNode<int>(2) };
        secondTree.Root.LeftNode = new TreeNode<int>(1);
        secondTree.Root.RightNode = new TreeNode<int>(3);
        secondTree.Root.LeftNode.RightNode = new TreeNode<int>(4);
        secondTree.Root.RightNode.RightNode = new TreeNode<int>(7);
        return secondTree;
    }

    private static List<int> GetExpectedSerialized()
    {
        var expectedTree = new BinaryTree<int> { Root = new TreeNode<int>(3) };
        expectedTree.Root.LeftNode = new TreeNode<int>(7);
        expectedTree.Root.RightNode = new TreeNode<int>(5);
        expectedTree.Root.LeftNode.LeftNode = new TreeNode<int>(5);
        expectedTree.Root.LeftNode.RightNode = new TreeNode<int>(4);
        expectedTree.Root.RightNode.RightNode = new TreeNode<int>(7);

        return expectedTree.SerializeLevelOrder();
    }
}