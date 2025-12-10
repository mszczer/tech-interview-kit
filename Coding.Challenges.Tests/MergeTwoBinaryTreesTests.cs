using Coding.Challenges.Common;

namespace Coding.Challenges.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MergeTwoBinaryTreesTests
{
    private BinaryTree<int>? _merged;

    [SetUp]
    public void SetUp()
    {
        // Arrange - firstTree
        var firstTree = new BinaryTree<int> { Root = new TreeNode<int>(1) };
        firstTree.Root.LeftNode = new TreeNode<int>(6);
        firstTree.Root.RightNode = new TreeNode<int>(2);
        firstTree.Root.LeftNode.LeftNode = new TreeNode<int>(5);

        // Arrange - secondTree
        var secondTree = new BinaryTree<int> { Root = new TreeNode<int>(2) };
        secondTree.Root.LeftNode = new TreeNode<int>(1);
        secondTree.Root.RightNode = new TreeNode<int>(3);
        secondTree.Root.LeftNode.RightNode = new TreeNode<int>(4);
        secondTree.Root.RightNode.RightNode = new TreeNode<int>(7);

        // Act
        _merged = MergeTwoBinaryTrees.GetMergedTree(firstTree, secondTree);
    }

    [Test]
    public void MergeResult_MatchesExpectedStructure_LevelOrder()
    {
        // Expected level-order representation for:
        //      3
        //     / \
        //    7   5
        //   / \   \
        //  5   4   7
        
        var expectedTree = new BinaryTree<int> { Root = new TreeNode<int>(3) };
        expectedTree.Root.LeftNode = new TreeNode<int>(7);
        expectedTree.Root.RightNode = new TreeNode<int>(5);
        expectedTree.Root.LeftNode.LeftNode = new TreeNode<int>(5);
        expectedTree.Root.LeftNode.RightNode = new TreeNode<int>(4);
        expectedTree.Root.RightNode.RightNode = new TreeNode<int>(7);

        var expected = expectedTree.SerializeLevelOrder();

        // Act 
        var actual = BinaryTree<int>.SerializeLevelOrder(_merged?.Root);


        // Assert - structure + values match
        Assert.That(actual, Is.EqualTo(expected));
    }
}